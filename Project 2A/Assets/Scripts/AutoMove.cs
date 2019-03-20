using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// This script will handle moving the spawner automatically as well as spawning objects that fall
/// from the spawner handling the case where the player's health reaches 0.
/// </summary>
public class AutoMove : MonoBehaviour {
    private int speed = 9; //speed spawner will move at
    private float chance = .02f; //used for changing direction
    private float screenEdge = 7.25f; //x-pos of screen, -screenEdge is other side
    public bool gameStart = false; //used for starting/stopping game.
    private bool atEdge = false; //checks if object is at edge
    public GameObject prefab; //prefab
    private GameObject prefabInstance; //instance of prefab
    //public GameObject storage; //stores instances of prefab
    public Collide c; //used to call variables/functions from Collide script
    public ButtonManager b;
    public SoundManager s;
    // Use this for initialization
    private void SpawnObject() //creates instances of the prefab
    {
        prefabInstance = Instantiate(prefab, transform.position, Quaternion.identity); //Instantiates instance at center of spawner
        prefabInstance.transform.SetParent(GameManager.Instance.storage.transform); //places the instance into the storage
    }
    private void Spawn() //spawns instances at intervals
    {
        InvokeRepeating("SpawnObject", 1, 1);
    }

    void Start()
    {      
        c = FindObjectOfType<Collide>(); //initializes the collide instance.
        //InvokeRepeating("SpawnObject", 2, 2);
        s = FindObjectOfType<SoundManager>();
        //DontDestroyOnLoad(prefabInstance);
    }

    // Update is called once per frame
    void Update () {
       if (!gameStart && Input.GetMouseButtonDown(0)) //will start game when the left mouse button is pressed
        {
            gameStart = true;
            Spawn();
        }
        atEdge = false;
        float xval = Mathf.Clamp(transform.position.x, -screenEdge, screenEdge); //sets the boundaries for the object
        transform.position = new Vector3(xval, transform.position.y, transform.position.z); //sets position of the object with the boundaries
        if (transform.position.x == screenEdge || transform.position.x == -screenEdge) //changes direction if the object hits an edge
        {
            atEdge = true;
            speed *= -1;
        }
        if (Random.value <= chance && !atEdge) //will change the direction if the random value (between 0 and 1) is less than the chance
        //as long the object is not at an edge.
        {
            speed *= -1;
            atEdge = false;
        }
        if (gameStart) //will only move if the game is running
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (c.getHealth() == 0) //when the player's health reaches 0
        {
            CancelInvoke("SpawnObject"); //stop spawning objects
            SceneManager.LoadScene(2);
            Destroy(prefabInstance); //destroy remaining prefabs.
            transform.position = new Vector3(0, transform.position.y, transform.position.z); //set object to its original location
            s.music.Stop();
            gameStart = false;
        }
        
	}
}
