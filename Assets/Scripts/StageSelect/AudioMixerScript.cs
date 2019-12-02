using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerScript : MonoBehaviour {

  //　SoundOptionキャンバスを設定
  [SerializeField]
  private GameObject soundOptionUI;
  [SerializeField]
  private AudioMixer audioMixer;
  //[SerializeField]
  //private GameObject BGMsliderObject;
  //private Slider BGMslider;
  //[SerializeField]
  //private GameObject SEsliderObject;
  //private Slider SEslider;
  AudioSource testSE;

  private void Start() {
    soundOptionUI.SetActive(false);
    testSE = GetComponent<AudioSource>();

    if (PlayerPrefs.HasKey("SEVolume")) {
      audioMixer.SetFloat("SE", PlayerPrefs.GetFloat("SEVolume"));
    }
    else {
      audioMixer.SetFloat("SE", 1);
    }
  }

  //public void SetMaster(float volume) {
  //  audioMixer.SetFloat("BGM", BGMslider.value);
  //  PlayerPrefs.SetFloat("BGM", BGMslider.value);
  //}

  public void SetSE(float volume) {
    audioMixer.SetFloat("SE", volume);
    PlayerPrefs.SetFloat("SEVolume", volume);
  }

  public void SeTest() {
    testSE.PlayOneShot(testSE.clip);
  }
}
