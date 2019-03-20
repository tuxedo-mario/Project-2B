using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public int score;
    public GameObject storage;
    // Use this for initialization
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
