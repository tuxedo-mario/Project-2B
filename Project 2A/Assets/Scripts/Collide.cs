using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script handles the display and the collision of the catcher and falling objects
/// </summary>
public class Collide : MonoBehaviour {
    private int ground = -5; //y-value where the bottom of the screen is.
    public int maxHealth = 3; //max health
    private int health;
    public Text txtLives; //the text that displays the health
    public Text txtScore; //the text that displays the score
    public AutoMove a; //used for calling variables from AutoMove
    public SoundManager s;
    public GameObject g;

    void Start()
    { //sets up display
        s = FindObjectOfType<SoundManager>();
        a = FindObjectOfType<AutoMove>();
        DontDestroyOnLoad(s);
        DontDestroyOnLoad(g);
        health = maxHealth;
        txtLives.text = "" + health;
        txtScore.text = "" + GameManager.Instance.score;
    }

    private void PlaySFX()
    {
        s.sfx.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision) //destroys the object the catcher collides with on contact
    {
        Destroy(collision.gameObject);
        GameManager.Instance.score += 1;
        txtScore.text = "" + GameManager.Instance.score; //updates score text
        PlaySFX();
    }

    public int getHealth() //returns the current health
    {
        return health;
    }
    // Use this for initialization

	// Update is called once per frame
	void Update () {
        GameObject instance = GameObject.Find("Falling(Clone)"); //the prefab instance
        if (instance != null && instance.transform.position.y <= ground) //if the instance has been set and hits the ground
        {
            Destroy(instance);
            health -= 1;
            txtLives.text = "" + health;
        }
        if (!a.gameStart) //resets the score and health if the player reaches 0 health.
        {
            health = maxHealth;
            txtLives.text = "" + health;
            txtScore.text = "" + GameManager.Instance.score;
        }

    }
}
