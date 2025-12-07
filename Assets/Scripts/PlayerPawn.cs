using UnityEngine;

public class PlayerPawn : Pawn
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        //get health componnt
        //healthComp = gameObject.GetComponent<HealthComponent>();

        //get death component
        //deathComp = gameObject.GetComponent<DeathComponent>();

        //get the rigidBody of the player pawn
        rigidBody2d = gameObject.GetComponent<Rigidbody2D>();

        //get the box collider for jump collider
        jumpCollider = gameObject.GetComponent<BoxCollider2D>();

        //TODO:change this when spawning the player later.
        //GameManager.instance.playerPawn = this;

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(rigidBody2d.linearVelocityX);

        /*
        //limit the velocity of the player pawn when moving in wither direction
        if (rigidBody2d.linearVelocity.magnitude > maxSpeed || rigidBody2d.linearVelocity.magnitude < maxSpeed * -1)
        {

            rigidBody2d.linearVelocity = Vector2.ClampMagnitude(rigidBody2d.linearVelocity, maxSpeed);

        }
        */



    }

    //Move the pawn right
    public override void MoveRight()
    {

        //set limits on how much velocity the player pawn amy gain in the right direction
        if (rigidBody2d.linearVelocityX < maxSpeed)
        {

            //get the right vector and multiply it by the movespeed. Time.Deltatime is not needed as force accounts for it.
            rigidBody2d.AddForce(transform.right * moveSpeed, ForceMode2D.Impulse);

        }
        //get the right vector and multiply it by the movespeed. Time.Deltatime is not needed as force accounts for it.
        //rigidBody2d.AddForce(transform.right * moveSpeed, ForceMode2D.Impulse);

       
    }

    //Move the pawn left
    public override void MoveLeft()
    {

        //set limits on how much velocity the player pawn may gain in the left direction
        if (rigidBody2d.linearVelocityX > maxSpeed * -1)
        {

            //get the right vector and multiply it by the movespeed. Time.Deltatime is not needed as force accounts for it.
            rigidBody2d.AddForce(-transform.right * moveSpeed, ForceMode2D.Impulse);

        }

        //get the left vector and multiply it by the movespeed. Time.Deltatime is not needed as force accounts for it.
        //rigidBody2d.AddForce(-transform.right * moveSpeed, ForceMode2D.Impulse);

    }

    //Make the pawn jump.
    public override void Jump()
    {

        //Check if the bIsJumping bool is false. If it is false, allow the player to jump.
        //If it is true, do not allow the player to jump.
        if (bIsJumping == false)
        {

            Debug.Log("Jumping");

            //add force to the pawns vertical transform, multiplied by the jump force.
            //Time.Deltatime is not needed as force accounts for it.
            rigidBody2d.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

            //set BIsJumping to true
            bIsJumping = true;

        }



    }

    //Trigger collision for the box collider under the player.
    //Is used to detect if the player is connected to the ground.
    void OnTriggerEnter2D(Collider2D collision)
    {

        //check if the trigger collision is colliding with any object with the platform tag (A.K.A Ground)
        //we are checking if the player is connecting with the ground
        if (collision.gameObject.tag == "Platform")
        {

            //set the bIsJumping bool to false
            bIsJumping = false;

        }

    }
}
