using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : SingletonMonoBehaviourFast<GameControllerScript>
{

  GameObject player;
  PlayerScript playerScript;
  GameObject mainCamera;
  CameraScript cameraScript;
  public Vector2 restartPoint;
  float deadAfterTime = 0;
  public bool reset = false;

  void Start() {
    this.playerScript = PlayerScript.Instance;
    this.player = PlayerScript.Instance.gameObject;
    this.mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    this.cameraScript = this.mainCamera.GetComponent<CameraScript>();
  }

  void Update() {
    if (this.playerScript.dead) {
      this.deadAfterTime += Time.deltaTime;
      if (this.deadAfterTime >= 2.0f) {
        this.deadAfterTime = 0;
        this.player.transform.position = this.restartPoint;
        this.mainCamera.transform.position = new Vector3(Mathf.Clamp(this.restartPoint.x,
                                                                                                         this.cameraScript.xLower,
                                                                                                         this.cameraScript.xUpper),
                                                                                     Mathf.Clamp(this.restartPoint.y,
                                                                                                         this.cameraScript.yLower,
                                                                                                         this.cameraScript.yUpper),
                                                                                     -10.0f);
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
