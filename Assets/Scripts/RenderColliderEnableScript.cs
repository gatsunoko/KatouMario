using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderColliderEnableScript : MonoBehaviour {

  SpriteRenderer spriteRender;
  PolygonCollider2D polygonCollider;

  void Start() {
    this.spriteRender = GetComponent<SpriteRenderer>();
    this.polygonCollider = GetComponent<PolygonCollider2D>();
  }

  void Update() {
    if (this.spriteRender.isVisible) {
      this.polygonCollider.enabled = true;
    }
    else {
      this.polygonCollider.enabled = false;
    }
  }
}
