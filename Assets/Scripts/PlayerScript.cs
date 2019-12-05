using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : SingletonMonoBehaviourFast<PlayerScript> {

  Rigidbody2D rigid2d;
  Animator animator;
  public GameObject groundCollider;
  public GameObject jumpCollider;
  public bool leftButton = false;
  public bool rightButton = false;
  public bool jumpButton = false;
  public Vector2 velocityMin;
  public Vector2 velocityMax;
  float key = 0;
  public float walkForce = 10.0f;
  public float jumpForce = 10.0f;
  int jumpCount = 0;//ジャンプボタンを押している時間に応じてジャンプの高さを変える為、ジャンプ中ADDForceされた回数を保持する
  bool[] grounded = new bool[3] { false, false, false };
  public bool grounded_result = false;
  public LayerMask groundLayer;
  public bool dead = false;
  StageDirectorScript stageDirectorScript;
  bool deadOne = true; //死んだら一回だけ実行するやつの判定
  AudioSource deadSound;
  public AudioClip[] deadSounds;
  int clipLength = 0;

  void Start() {
    this.rigid2d = GetComponent<Rigidbody2D>();
    this.animator = GetComponent<Animator>();
    this.dead = false;
    this.stageDirectorScript = GameObject.Find("StageDirector").GetComponent<StageDirectorScript>();
    this.deadSound = GetComponent<AudioSource>();
    this.clipLength = deadSounds.Length;
    this.deadOne = true;
  }

  private void FixedUpdate() {
    if (this.dead) {
      this.rigid2d.velocity = new Vector2(0, 0);
    }
    else {
      if (!this.stageDirectorScript.clear) {
        //スピード制限
        float vy = Mathf.Clamp(rigid2d.velocity.y, velocityMin.y, velocityMax.y);
        //歩行処理
        this.rigid2d.velocity = new Vector2(key * walkForce, vy);

        //動く方向に応じて反転
        if (key != 0) {
          transform.localScale = new Vector3(key, 1, 1);
        }

        //ジャンプ処理
        if (this.jumpButton && this.grounded_result) {
          this.rigid2d.velocity = new Vector2(this.rigid2d.velocity.x, this.jumpForce);
          this.jumpCount++;
        }
      }
      else {
        this.rigid2d.velocity = new Vector2(1 * walkForce, 0);
      }
    }
  }

  void Update() {
    //------------------PCデバッグ用---------------------------------
    if (Input.GetKeyDown(KeyCode.LeftArrow)) {
      this.leftButton = true;
    }
    if (Input.GetKeyUp(KeyCode.LeftArrow)) {
      this.leftButton = false;
    }

    if (Input.GetKeyDown(KeyCode.RightArrow)) {
      this.rightButton = true;
    }
    if (Input.GetKeyUp(KeyCode.RightArrow)) {
      this.rightButton = false;
    }

    if (Input.GetKeyDown(KeyCode.Space)) {
      this.jumpButton = true;
    }
    if (Input.GetKeyUp(KeyCode.Space)) {
      this.jumpButton = false;
    }
    //------------------PCデバッグ用ここまで-------------------------
    //死んでたら速度ゼロ
    if (this.dead) {
      this.rigid2d.velocity = new Vector2(0, 0);
      this.rigid2d.bodyType = RigidbodyType2D.Kinematic;
      if (this.deadOne) {
        this.animator.SetTrigger("Dead");
        int i = Random.Range(0, clipLength);
        this.deadSound.clip = this.deadSounds[i];
        this.deadSound.PlayOneShot(deadSound.clip);
        this.deadOne = false;
      }
    }
    else {
      this.animator.SetTrigger("Reset");
      this.rigid2d.bodyType = RigidbodyType2D.Dynamic;
      this.deadOne = true;
    }
    //ジャンプできるかどうかの接地判定
    Vector2 linePos = transform.position;
    linePos.y -= 0.06f;
    grounded[0] = Physics2D.Linecast(transform.position, linePos, groundLayer);
    linePos.x -= 0.305f;
    grounded[1] = Physics2D.Linecast(transform.position, linePos, groundLayer);
    linePos.x += 0.305f;
    linePos.x += 0.185f;
    grounded[2] = Physics2D.Linecast(transform.position, linePos, groundLayer);
    //接地判定をして結果をgourended_result変数に入れる
    if ((grounded[0]) || (grounded[1]) || (grounded[2])) {
      grounded_result = true;
    }
    else {
      grounded_result = false;
    }
    //ボタンおしっぱでジャンプし続けないための処理
    if (!grounded_result) {
      this.jumpButton = false;
    }
    //入力状況に応じてkey決定
    if (this.leftButton) {
      this.key = -1;
    }
    else if (this.rightButton) {
      this.key = 1;
    }
    else {
      this.key = 0;
    }
    //クリアしてたら→入力状態
    if (this.stageDirectorScript.clear) {
      this.key = 1;
    }
    //地面に接地しているかどうかでわける処理
    if (grounded_result) {
      //アニメーション処理
      this.groundCollider.SetActive(true);
      this.jumpCollider.SetActive(false);
      this.animator.SetBool("Grounded", true);
    }
    else {
      this.groundCollider.SetActive(false);
      this.jumpCollider.SetActive(true);
      this.animator.SetBool("Grounded", false);
    }
    if (this.rigid2d.velocity.x != 0 && this.key != 0) {
      this.animator.SetFloat("Speed", 1);
    }
    else {
      this.animator.SetFloat("Speed", 0);
    }
  }

  private void OnTriggerEnter2D(Collider2D col) {
    //動く床に乗った時動く要素を親オブジェクトにする
    if (col.gameObject.tag == "MoveFloor") {
      transform.SetParent(col.transform);
    }
  }

  private void OnTriggerExit2D(Collider2D col) {
    //動く床から離れたら床との親子関係を解消する
    if (col.gameObject.tag == "MoveFloor") {
      transform.SetParent(null);
      //親オブジェクトが回転していた場合自分の角度も狂っているので、０にする
      transform.rotation = Quaternion.Euler(0, 0, 0);
    }
  }

  //private void OnCollisionEnter2D(Collision2D col) {
  //  //動く床に乗った時動く要素を親オブジェクトにする
  //  if (col.gameObject.tag == "MoveFloor") {
  //    transform.SetParent(col.transform);
  //  }
  //}

  //private void OnCollisionExit2D(Collision2D col) {
  //  //動く床から離れたら床との親子関係を解消する
  //  if (col.gameObject.tag == "MoveFloor") {
  //    transform.SetParent(null);
  //    //親オブジェクトが回転していた場合自分の角度も狂っているので、０にする
  //    transform.rotation = Quaternion.Euler(0, 0, 0);
  //  }
  //}
}