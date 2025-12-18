using UnityEngine;

public class StompableEnemyOverlap : MonoBehaviour
{
    //clip fro squash sound
    public AudioClip squishClip;

    //Make sure this component is on it own seperate child trigger box, if you wish to do a Mario Goomba stomp for example.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        squishClip = AudioManager.instance.squishSoundClip;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {

    }

    //trigger for the top of the enemies head, must check that object colliding is a player and is above zero on the Y axis. 
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
            if(!playPawn.IsGrounded() && play2DBody.linearVelocityY < 0)
            {
                //get the Enemy Overlap in the parent object
                EnemyDamageOnOverlap overlap = gameObject.GetComponentInParent<EnemyDamageOnOverlap>();

                //set damage to zero so the player doesn't take any unecessary damage
                overlap.damageDone = 0;

                DeathComponent deathComp = gameObject.GetComponentInParent<DeathComponent>();

                //play squish sound effect
                AudioSource.PlayClipAtPoint(squishClip, transform.position);

                deathComp.Die();

            }

        }

    }
}

