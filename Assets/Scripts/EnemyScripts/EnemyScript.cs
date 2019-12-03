using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

  GameControllerScript gameControllerScript;

  void Start() {
    this.gameControllerScript = GameControllerScript.Instance;
  }

  void Update() {
    if (this.gameControllerScript.reset) {
      Destroy(gameObject);
    }
  }
}
