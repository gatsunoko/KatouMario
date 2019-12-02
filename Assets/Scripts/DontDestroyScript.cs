using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyScript : MonoBehaviour {

  public string tagName = "BGM";

  private void Awake() {
    if (GameObject.FindGameObjectsWithTag(tagName).Length > 1) {
      Destroy(this.gameObject);
      return;
    }
  }

  void Start() {
    DontDestroyOnLoad(this);
  }

  private void Update() {
    if (SceneManager.GetActiveScene().name == "StageSelect") {
      Destroy(this.gameObject);
    }
  }
}
