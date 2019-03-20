using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will handle the movement of the catcher object.
/// </summary>
public class MoveObject : MonoBehaviour {
    private int speed = 8; //speed of catcher
    private float screenEdge = 7.25f; 
    public AutoMove a;
    private void move() //moves the catcher
    {
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -screenEdge)
            //if the left arrow is pressed and the catcher is not at the left edge.
        {
            transform.position += Vector3.left * speed * Time.deltaTime; //move left
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < screenEdge)
            //if the right arrow is pressed and the catcher is not at the right edge.
        {
            transform.position += Vector3.right * speed * Time.deltaTime; //move right
        }
    }
    // Use this for initialization
    void Start () {
        a = FindObjectOfType<AutoMove>();
	}
	
	// Update is called once per frame
	void Update () {
        if (a.gameStart) //if the game is running
        {
            move();
        }
        else
        {
            //set the catcher back to its original position
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
	}
}
