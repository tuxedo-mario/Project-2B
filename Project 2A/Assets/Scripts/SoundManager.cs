using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {
    public AudioSource music;
    public AudioSource sfx;
    public ButtonManager b;
    public SoundManager s;
    public Slider sl1;
    public Slider sl2;
    public GameObject g;
    public GameObject button;
    // Use this for initialization
    void Start () {
        if (!PlayerPrefs.HasKey("Music Volume"))
        {
            PlayerPrefs.SetFloat("Music Volume", music.volume);
        }
        if (!PlayerPrefs.HasKey("SFX Volume"))
        {
            PlayerPrefs.SetFloat("SFX Volume", music.volume);
        }
        Debug.Log(PlayerPrefs.GetFloat("Music Volume"));
        sl1.value = PlayerPrefs.GetFloat("Music Volume");
        Debug.Log(sl1.value);
        sl2.value= PlayerPrefs.GetFloat("SFX Volume");
        music.volume = sl1.value;
        Debug.Log(music.volume);
        sfx.volume = sl2.value;
        PlayerPrefs.SetFloat("Music Volume", music.volume);
        PlayerPrefs.SetFloat("SFX Volume", sfx.volume);
        DontDestroyOnLoad(music);
        DontDestroyOnLoad(sfx);
        b = button.GetComponent<ButtonManager>();
        Debug.Log(b);
        DontDestroyOnLoad(b);
        DontDestroyOnLoad(g);
    }

	// Update is called once per frame
	void Update () {
    }
}
