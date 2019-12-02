using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaruoScript : MonoBehaviour {

  AudioSource audioSource;
  public AudioClip[] yaruos;

  void Start() {
    audioSource = GetComponent<AudioSource>();
    audioSource.clip = yaruos[Random.Range(0, yaruos.Length)];
    audioSource.PlayOneShot(audioSource.clip);
  }
}
