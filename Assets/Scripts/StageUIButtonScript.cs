using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageUIButtonScript : MonoBehaviour {

  PlayerScript playerScript;

  void Start() {
    this.playerScript = PlayerScript.Instance;
  }

  public void LeftButtonDown() {
    playerScript.leftButton = true;
  }

  public void LeftButtonUp() {
    playerScript.leftButton = false;
  }

  public void RightButtonDown() {
    playerScript.rightButton = true;
  }

  public void RightButtonUp() {
    playerScript.rightButton = false;
  }

  public void JumpButtonDown() {
    playerScript.jumpButton = true;
  }

  public void JumpButtonUp() {
    playerScript.jumpButton = false;
  }
}
