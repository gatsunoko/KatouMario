using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAfterSpriteScript : MonoBehaviour {

  float time = 0;
  Vector3 smallSize;
  Vector3 BigSize;
  PlayerScript playerScript;
  SpriteRenderer sprite;

  void Start() {
    smallSize = new Vector3(0.1f, 0.1f,0.1f);
    BigSize = new Vector3(10.0f, 10.0f, 10.0f);
    transform.localScale = smallSize;
    this.playerScript = PlayerScript.Instance;
    this.sprite = GetComponent<SpriteRenderer>();
    this.sprite.enabled = false;
  }

  void Update() {
    if (this.playerScript.dead) {
      time += Time.deltaTime;
      transform.localScale = Vector3.Lerp(smallSize, BigSize, time / 2.0f);
      this.sprite.enabled = true;
    }
    else {
      time = 0;
      transform.localScale = smallSize;
      this.sprite.enabled = false;
    }
  }
}
