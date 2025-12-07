using UnityEngine;

public class PlayerController : Controller
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        MakeDecisions();


    }

    //method for when the player provides input
    public override void MakeDecisions()
    {
        //If the D key is pressed down, tell the player pawn to move right
        if (Input.GetKey(KeyCode.D))
        {
            //go into the pawn and move the player to the right
            pawn.MoveRight();

        }

        //If the A key is pressed down, tell the player pawn to move left
        if (Input.GetKey(KeyCode.A))
        {
            //go into the pawn and move the player to the left
            pawn.MoveLeft();

        }


        //If the W key is pressed down, tell the player pawn to jump
        if (Input.GetKeyDown(KeyCode.W))
        {
            //go into the pawn and move the player to jump
            pawn.Jump();

        }
    }
}
