using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMoveJunScript : MonoBehaviour {

  public float ySpeed = 0f;
  public float xSpeed = 5.0f;
  public float verticalSinValue = 4.0f;//縦に動く距離
  Rigidbody2D rigid2d;
  public float time = 0;//初期位置0.5で真ん中0で一番下1で↑
  //ジェネレータから変数受け取るやつ
  GameObject generater;
  EnemyGeneraterScript generaterScript;

  void Start() {
    rigid2d = GetComponent<Rigidbody2D>();
    //親要素がありジェネレータならば変数を取得する
    if (transform.parent) {
      if (transform.parent.tag == "EnemyGenerater") {
        this.generater = transform.parent.gameObject;
        this.generaterScript = this.generater.GetComponent<EnemyGeneraterScript>();
        this.ySpeed = this.generaterScript.handOverFloat[0];
        this.xSpeed = this.generaterScript.handOverFloat[1];
        this.verticalSinValue = this.generaterScript.handOverFloat[2];
        this.time = this.generaterScript.handOverFloat[3];
      }
    }
  }

  private void FixedUpdate() {
    float vy = Mathf.Sin(time * verticalSinValue);
    rigid2d.velocity = new Vector2(vy * xSpeed, vy * ySpeed);
  }

  void Update() {
    time += Time.deltaTime;
  }
}
