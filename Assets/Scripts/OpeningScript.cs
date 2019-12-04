﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningScript : MonoBehaviour {
  [RuntimeInitializeOnLoadMethod()]
  static void Init() {
    Screen.SetResolution(1600, 960, true);
    QualitySettings.vSyncCount = 0;     //垂直同期OFF
    Application.targetFrameRate = 60; // ターゲットフレームレートを60に設定
  }
}
