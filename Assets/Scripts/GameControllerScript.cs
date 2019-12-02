using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : SingletonMonoBehaviourFast<GameControllerScript>
{

  GameObject player;
  PlayerScript playerScript;
  GameObject mainCamera;
  public Vector2 restartPoint;
  float deadAfterTime = 0;
  public bool reset = false;

  void Start() {
    this.playerScript = PlayerScript.Instance;
    this.player = PlayerScript.Instance.gameObject;
    this.mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
  }

  void Update() {
    if (this.playerScript.dead) {
      this.deadAfterTime += Time.deltaTime;
      if (this.deadAfterTime >= 2.0f) {
        this.deadAfterTime = 0;
        this.player.transform.position = this.restartPoint;
        this.mainCamera.transform.position = new Vector3(this.restartPoint.x, this.restartPoint.y, -10.0f);
        this.reset = true;
      }
    }
    else {
      this.reset = false;
    }
  }

  private void LateUpdate() {
    if (this.reset) {
      this.playerScript.dead = false;
    }
  }
}
