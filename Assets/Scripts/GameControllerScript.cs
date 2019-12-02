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

  void Start() {
    this.playerScript = PlayerScript.Instance;
    this.player = PlayerScript.Instance.gameObject;
    this.mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
  }

  void Update() {
    if (this.playerScript.dead) {
      this.player.transform.position = this.restartPoint;
      this.mainCamera.transform.position = new Vector3(this.restartPoint.x, this.restartPoint.y, -10.0f);
    }
  }

  private void LateUpdate() {
    if (this.playerScript.dead) {
      this.playerScript.dead = false;
    }
  }
}
