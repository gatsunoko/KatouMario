using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour {

  [SerializeField]
  GameObject textObject;
  float time = 0;

  void Start() {
    this.textObject.transform.position = new Vector3(-8.1f, -5.8f, 0);
  }

  void Update() {
    if (textObject.transform.position.y < 57.2f) {
      textObject.transform.Translate(new Vector2(0, 0.05f));
    }
    else {
      time += Time.deltaTime;
      if (time >= 5.0f) {
        PlayerPrefs.SetFloat("cameraY", 0.25f);
        SceneManager.LoadScene("stageSelect");
      }
    }
  }
}
