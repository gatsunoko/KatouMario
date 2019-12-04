using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunBoScript : MonoBehaviour {

  Rigidbody2D rigid2d;
  Animator animator;
  GameObject player;
  public float speed = 5.0f;
  float key;
  Vector2 direction;
  SpriteRenderer spriteRender;
  //ジェネレータから変数受け取るやつ
  GameObject generater;
  EnemyGeneraterScript generaterScript;

  void Start() {
    this.rigid2d = GetComponent<Rigidbody2D>();
    this.animator = GetComponent<Animator>();
    this.player = PlayerScript.Instance.gameObject;
    this.key = 0;
    this.spriteRender = GetComponent<SpriteRenderer>();
    //親要素がありジェネレータならば変数を取得する
    if (transform.parent) {
      if (transform.parent.tag == "EnemyGenerater") {
        this.generater = transform.parent.gameObject;
        this.generaterScript = this.generater.GetComponent<EnemyGeneraterScript>();
        this.speed = this.generaterScript.handOverFloat[0];
      }
    }
  }

  private void FixedUpdate() {
    //歩行処理
    float dx = Mathf.Abs(direction.x);
    if (dx > 0.3) {
      this.rigid2d.velocity = new Vector2(key * speed, rigid2d.velocity.y);
    }

    //動く方向に応じて反転
    if (key != 0) {
      transform.localScale = new Vector3(key, 1, 1);
    }
  }

  void Update() {
    if (spriteRender.isVisible) {
      //プレイヤーの方向を求める
      this.direction = player.transform.position - transform.position;

      if (direction.x > 0) {
        key = 1.0f;
      }
      else if (direction.x < 0) {
        key = -1.0f;
      }
      else {
        key = 0;
      }
    }
  }
}
