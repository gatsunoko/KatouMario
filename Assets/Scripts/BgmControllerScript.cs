using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmControllerScript : MonoBehaviour {

  public AudioClip[] audioClip;
  AudioSource audioSource;
  int i = 0;
  int clipLength;

  void Start() {
    audioSource = GetComponent<AudioSource>();
    clipLength = audioClip.Length;
  }

  void Update() {
    if (!audioSource.isPlaying) {
      audioSource.clip = audioClip[i];
      audioSource.PlayOneShot(audioSource.clip);
      i++;
      if (i >= clipLength) {
        i = 0;
      }
    }
  }
}
