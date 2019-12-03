using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KurukuruScript : MonoBehaviour {

  Vector2 defaultPosition;
  Rigidbody2D rigid2d;
  public float moveSpeed = 0.5f;
  GameControllerScript gameControllerScript;

  void Start() {
    this.rigid2d = GetComponent<Rigidbody2D>();
    defaultPosition = new Vector2(transform.position.x, transform.position.y);
    this.gameControllerScript = GameControllerScript.Instance;
  }

  private void FixedUpdate() {
    transform.Rotate(new Vector3(0f, 0f, moveSpeed));
  }

  private void Update() {
    if (this.gameControllerScript.reset) {
      transform.rotation = new Quaternion(0, 0, 0, 0);
    }
  }
}
