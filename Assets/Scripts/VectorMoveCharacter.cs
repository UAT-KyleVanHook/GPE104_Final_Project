using UnityEngine;

public class VectorMoveCharacter : MonoBehaviour
{
    //Move the character in a square using vector math.

    [Header("Speed")]
    public int moveSpeed;

    [Header("Timers")]
    public float Left_and_Right_Side_Timer_Amount;
    public float Up_and_Down_Timer_Amount;

    //keeps track of the increment count for the timer.
    private int trackerCount;

    //acutal timer
    private float Timer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //tracker for which timer should be counting down
        trackerCount = 1;
        Timer = Up_and_Down_Timer_Amount;
        //1 and 3, bottom and top of the square
        //2 and 4 , sides
    }

    // Update is called once per frame
    void Update()
    {
        //MOVMENT

        //1 is going right on the x-axis
        //bottom
        if(trackerCount == 1)
        {
            //timer
            Timer -= Time.deltaTime;

            transform.position += transform.right * (moveSpeed * Time.deltaTime);

            //check that the timer isn't zero
            if (Timer <= 0)
            {
                //increment trackerCount
                trackerCount++;

                //reset timer for next side
                Timer = Left_and_Right_Side_Timer_Amount;

            }

        }

        //2 is going up on the y axis
        //Right side
        if (trackerCount == 2)
        {
            //timer
            Timer -= Time.deltaTime;

            transform.position += transform.up * (moveSpeed * Time.deltaTime);

            //check that the timer isn't zero
            if (Timer <= 0)
            {
                //increment trackerCount
                trackerCount++;

                //reset timer for next side
                Timer = Up_and_Down_Timer_Amount;

            }

        }

        //3 is going left and the x-axis
        //Top
        if (trackerCount == 3)
        {
            //timer
            Timer -= Time.deltaTime;

            transform.position += -transform.right * (moveSpeed * Time.deltaTime);

            //check that the timer isn't zero
            if (Timer <= 0)
            {
                //increment trackerCount
                trackerCount++;

                //reset timer for next side
                Timer = Left_and_Right_Side_Timer_Amount;

            }

        }

        //4 is going down on the y-axis
        //Left side
        //full circle, get ready to reset
        if (trackerCount == 4)
        {
            //timer
            Timer -= Time.deltaTime;

            transform.position += -transform.up * (moveSpeed * Time.deltaTime);

            //check that the timer isn't zero
            if (Timer <= 0)
            {
                //reset trackerCount
                trackerCount = 1;

                //reset timer for next side
                Timer = Up_and_Down_Timer_Amount;

            }

        }



    }
}
