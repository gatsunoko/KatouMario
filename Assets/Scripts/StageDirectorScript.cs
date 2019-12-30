using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageDirectorScript : MonoBehaviour {

  public bool clear = false;
  float clearAfterTime = 0;
  public bool goEnding = false;

  void Update() {
    if (this.clear) {
      this.clearAfterTime += Time.deltaTime;
      if (this.clearAfterTime >= 3.0f) {
        if (goEnding) {
          SceneManager.LoadScene("EndingScene");
        }
        else {
          SceneManager.LoadScene("StageSelect");
        }
      }
    }
    //R押したらリセット
    if (Input.GetKey(KeyCode.R)) {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  }
}
