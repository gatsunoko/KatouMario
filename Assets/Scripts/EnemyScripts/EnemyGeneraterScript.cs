using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneraterScript : MonoBehaviour {
  public GameObject enemy;
  SpriteRenderer sprite;
  bool generated = false;
  bool oldVisible = false;
  GameObject player;
  GameObject enemyInstance;
  public Vector2[] handOverVector2;
  public float[] handOverFloat;

  void Start() {
    this.player = PlayerScript.Instance.gameObject;
    this.sprite = GetComponent<SpriteRenderer>();
    this.sprite.color = new Color(1, 1, 1, 0);
  }

  void Update() {
    if (this.sprite.isVisible && !this.oldVisible) {
      if (!generated) {
        var parent = this.transform;
        enemyInstance = Instantiate(enemy, parent) as GameObject;
        enemyInstance.transform.position = new Vector2(transform.position.x, transform.position.y);

        generated = true;
      }
    }

    this.oldVisible = this.sprite.isVisible;

    if (enemyInstance == null) {
      generated = false;
    }
  }
}
