using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionFixedScript : MonoBehaviour {

  public float x = 0;
  public float y = 0;
  public float z = 0;

  void FixedUpdate() {
    gameObject.transform.rotation = Quaternion.Euler(x, y, z);
  }
}
