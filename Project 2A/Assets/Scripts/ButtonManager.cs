using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
    public int index;
    public SoundManager s;
    public static ButtonManager Instance;
    // Use this for initialization

    private void Awake()
    {
        s = FindObjectOfType<SoundManager>();
        DontDestroyOnLoad(s);       
    }
    private void Start()
    {
        
    }
    public void LoadGame()
    {
        s.music.Play();
        index = 1;
        SceneManager.LoadScene(1);
    }
    public void LoadMenu()
    {
        index = 0;
        SceneManager.LoadScene(0);

    }
    public void LoadLeaderboard()
    {
        index = 2;
        SceneManager.LoadScene(2);       
    }

    public void Quit()
    {
        Application.Quit();
    }
}
