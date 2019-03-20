using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text[] scoresTexts = new Text[10];
    private int[] scores = new int[10];
    public static ScoreManager Instance;
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
    }
    private void ChangeScores(int index, int[] scores)
    {
        for (int i = scores.Length - 1; i > index; i--)
        {
            PlayerPrefs.SetInt("Score " + (i + 1), scores[i - 1]);
            scores[i] = PlayerPrefs.GetInt("Score " + (i + 1));
            scoresTexts[i].text = "" + scores[i];
        }
    }
    private void UpdateScores()
    {
        for (int i = 0; i < 10; i++)
        {
            if (GameManager.Instance != null && GameManager.Instance.score >= scores[i])
            {
                ChangeScores(i, scores);
                PlayerPrefs.SetInt("Score " + (i + 1), GameManager.Instance.score);
                scores[i] = PlayerPrefs.GetInt("Score " + (i + 1));
                scoresTexts[i].text = "" + scores[i];
                break;
            }
        }
    }
    void Start () {
        for (int i = 0; i < 10; i++)
        {
            if (!PlayerPrefs.HasKey("Score " + (i + 1)))
            {
                PlayerPrefs.SetInt("Score " + (i + 1), 0);
            }
            scores[i] = PlayerPrefs.GetInt("Score " + (i + 1));
            scoresTexts[i].text = "" + scores[i];
        }
        UpdateScores();
        if (GameManager.Instance != null)
        {
            GameManager.Instance.score = 0;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
