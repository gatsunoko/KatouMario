using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleStartChangeScript : MonoBehaviour {
  //ステージセレクト画面スタートした時SE音量調整トグルの初期チェック状態をセットするスクリプト

  public float myValue = 1.0f;

  void Start() {
    if (PlayerPrefs.HasKey("SEVolume")) {
      if (PlayerPrefs.GetFloat("SEVolume") == myValue) {
        GetComponent<Toggle>().isOn = true;
      }
    }
  }
}
