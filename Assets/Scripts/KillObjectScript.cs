using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObjectScript : MonoBehaviour {

  public bool enemyDestroyer = true;

  private void OnTriggerEnter2D(Collider2D col) {
    if (col.gameObject.tag == "Player") {
      PlayerScript.Instance.dead = true;
    }
    else if (col.gameObject.tag == "Enemy" && enemyDestroyer) {
      Destroy(col.gameObject);
    }
  }
}
