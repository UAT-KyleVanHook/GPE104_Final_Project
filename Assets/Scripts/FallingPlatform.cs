using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallWait;
    public float destroyWait;

    bool bIsFalling;

    Rigidbody2D rb2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //get the rigidbady2D form gameObject
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        
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
        Destroy(gameObject, destroyWait);
    }
}
