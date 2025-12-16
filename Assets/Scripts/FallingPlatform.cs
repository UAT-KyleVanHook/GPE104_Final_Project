using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallWait;
    //public float destroyWait;
    public float respawnWait;

    bool bIsFalling;

    Rigidbody2D rb2D;

    //transform of the starting block
    private Vector2 startLocation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //get the rigidbody2D form gameObject
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        startLocation = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //If the collided object is the player, start a Coroutine to start a timer
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!bIsFalling && collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    //Making a Coroutine to wait a few seconds before setting the rigidbody2D to dynamic, allowing gravity ot affect it.
    //After a wait time, the gameObject will destroy itself.
    private IEnumerator Fall()
    {
        bIsFalling = true;

        //yield acts as a pause point in processing, WaitForSeconds has the Coroutine wait for a inputted amount of seconds
        yield return new WaitForSeconds(fallWait);

        //set the rigidbody type to dynamic, making it affected by gravity
        rb2D.bodyType = RigidbodyType2D.Dynamic;


        //wait a few seconds before destroying the object
        //Destroy(gameObject, destroyWait);



        //wait before reseting the vector position
        yield return new WaitForSeconds(respawnWait);

        //reset the gameObjects rigidBody3D type
        //set the rigidbody type to dynamic, making it affected by gravity
        rb2D.bodyType = RigidbodyType2D.Static;

        //reset bIsFalling to false
        bIsFalling = false;

        //reset gameObject transform
        gameObject.transform.position = startLocation;  

    }
}
