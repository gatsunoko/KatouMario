using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdControllerScript : SingletonMonoBehaviourFast<AdControllerScript> {

  public float adIntervalTime = 150.0f;

  void Start() {
    DontDestroyOnLoad(this);
    adIntervalTime = 150.0f;
  }

  void Update() {
    this.adIntervalTime += Time.deltaTime;
  }
}
