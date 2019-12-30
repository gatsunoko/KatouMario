using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTachStartScript : MonoBehaviour {

  public GameObject[] startObject;
  List<MoveObjectScript> moveObjectScripts = new List<MoveObjectScript>();
  public float speed = 5.0f;
  bool firstAction = true;

  void Start() {
    foreach (GameObject controleObject in startObject) {
      if (controleObject.GetComponent<MoveObjectScript>()) {
        moveObjectScripts.Add(controleObject.GetComponent<MoveObjectScript>());
      }
    }
    foreach (MoveObjectScript moveObjectScript in moveObjectScripts) {
      moveObjectScript.speed = 0;
    }
  }

  private void OnTriggerEnter2D(Collider2D col) {
    if (col.gameObject.tag == "Player" && this.firstAction) {
      this.firstAction = false;
      foreach (MoveObjectScript moveObjectScript in moveObjectScripts) {
        moveObjectScript.speed = this.speed;
      }
    }
  }
}
