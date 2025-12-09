using UnityEngine;

public class PlayerPawn : Pawn
{
    public float dragAmount;

    [Header("BoxCast")]
    public Vector2 boxSize;
    public float boxAngle;
    public float castDistance;
    public LayerMask groundLayer;

    public static PlayerPawn playerInstance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //check that there is not another instance of PlayerPawn currently in the level. 
        //If we don't have a PlayerInstance, set this instance as the current instance. Otherwise, destroy the other instance.
        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //don't destroy object on scene load
        GameObject.DontDestroyOnLoad(gameObject);


        //get health componnt
        healthComp = gameObject.GetComponent<HealthComponent>();

        //get death component
        deathComp = gameObject.GetComponent<DeathComponent>();

        //get the rigidBody of the player pawn
        rigidBody2d = gameObject.GetComponent<Rigidbody2D>();

        //get sprite renderer for the player pawn
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        //TODO:change this when spawning the player later.
        //GameManager.instance.playerPawn = this;

    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(rigidBody2d.linearVelocityX);

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

            //flip sprite to the right
            spriteRenderer.flipX = true;

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

            //flip sprite to the left
            spriteRenderer.flipX = false;

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
        if (IsGrounded())
        {

            Debug.Log("Jumping");

            //add force to the pawns vertical transform, multiplied by the jump force.
            //Time.Deltatime is not needed as force accounts for it.
            rigidBody2d.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

            //set BIsJumping to true
           // bIsJumping = true;

        }

    }


    //Bool function used to detect if the player is connecting with the ground
    public bool IsGrounded()
    {
        //Box Raycast to detect if the player is off of the ground.
        if (Physics2D.BoxCast(transform.position, boxSize, boxAngle, -transform.up, castDistance, groundLayer))
        {
            //the player is touching the ground
            return true;

        }
        else
        {
            //the player is not touching the ground
            return false;
        }
    
    }

    //Function to allow the outline of the Box Raycast to be seen
    private void OnDrawGizmos()
    {

        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);

    }

    //Remove most of the velocity of the pawn by 40%
    public void DragLinearVelocityX()
    {

        rigidBody2d.linearVelocityX *= dragAmount;

    }


    //Abandoned method. Two colliders on an object messes with damage, double hitting sometimes.

    //Trigger collision for the box collider under the player.
    //Is used to detect if the player is connected to the ground.
    //void OnTriggerEnter2D(Collider2D collision)
    //{

    //    //check if the trigger collision is colliding with any object with the platform tag (A.K.A Ground)
    //    //we are checking if the player is connecting with the ground
    //    if (collision.gameObject.tag == "Platform")
    //    {

    //        //set the bIsJumping bool to false
    //        bIsJumping = false;

    //    }

    //}
}
