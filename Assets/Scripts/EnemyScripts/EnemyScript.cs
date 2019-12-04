using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

  private void OnTriggerEnter2D(Collider2D col) {
    if (col.gameObject.tag == "Player") {
      PlayerScript.Instance.dead = true;
    }
  }
}
