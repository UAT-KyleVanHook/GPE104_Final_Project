using System.Collections;
using UnityEngine;

public class SpringJumpBox : MonoBehaviour
{
    [Header("Sprite")]
    public SpriteRenderer spriteRenderer;
    public Sprite extendedSprite;
    public Sprite normalSprite;

    [Header ("Values")]
    //int for the reset timer for the spring
    public float resetWait;
    public int launchForce;

    [Header("Audio")]
    public AudioClip springClip;

    //Make sure this component is on it own seperate child trigger box, if you wish to do a Mario Goomba stomp for example.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get SpriteRenderer in the parent object
        spriteRenderer = gameObject.GetComponentInParent<SpriteRenderer>();

        //set spring audio clip
        springClip = AudioManager.instance.springSoundClip;

    }

    // Update is called once per frame
    void Update()
    {

    }

    //trigger for the top spring
    private void OnTriggerEnter2D(Collider2D other)
    {


        //check that the other object is a player object
        if (other.gameObject.CompareTag("Player"))
        {

            PlayerPawn playPawn = other.gameObject.GetComponent<PlayerPawn>();

            Rigidbody2D play2DBody = other.gameObject.GetComponent<Rigidbody2D>();

            //check that the player object is jumping, we use the grounded function in the player pawn. 
            //If it is false, then they are jumping/ in the air and we want to allow this to happpen.
            //We also check that the playerPawns linear velocity in the y axis is in the negatives.
            if (!playPawn.IsGrounded() && play2DBody.linearVelocityY < 0)
            {

                AudioSource.PlayClipAtPoint(springClip, transform.position);

                play2DBody.AddForce(transform.up * launchForce, ForceMode2D.Impulse);

                //set the current sprite to the new Sprite, a large extended spring
                spriteRenderer.sprite = extendedSprite;

                //go to the coroutine, spring
                StartCoroutine(Spring());

            }

        }

    }

    //Making a Coroutine to wait a few seconds before setting the rigidbody2D to dynamic, allowing gravity ot affect it.
    //After a wait time, the gameObject will destroy itself.
    private IEnumerator Spring()
    {

        //yield acts as a pause point in processing, WaitForSeconds has the Coroutine wait for a inputted amount of seconds
        yield return new WaitForSeconds(resetWait);

        spriteRenderer.sprite = normalSprite;


    }

}
