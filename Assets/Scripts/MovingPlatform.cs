using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    //move speed
    public float moveSpeed;

    //next position the object should move towards
    private Vector3 nextPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set the start point for the platform
        nextPosition = pointB.position;


    }

    // Update is called once per frame
    void Update()
    {
        //move the platform towards the nextPosition (next point in path)
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);

        //Check if current transform.position is equal to the nextPosition
        if (transform.position == nextPosition)
        {
            //conditional if statement to check what the next position will be.
            //If nextPosition is already equal to pointA, set it to PointB. If it is not, set it to pointA.
            nextPosition = (nextPosition == pointA.position) ? pointB.position : pointA.position;

        }
        
    }

    //detect the collision of the playerPawn.
    //If the player lands on the platform, they will follow the platforms transform.
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            //set colliding pawns transform to the same as platforms
            collision.gameObject.transform.parent = transform;

            //lowers the velocity on the playerPawn, making them less likely to fly off 
            collision.gameObject.GetComponent<PlayerPawn>().DragLinearVelocityX();

        }

    }

    //detect the collision of the playerPawn.
    //If the player leaves the platform, they will not have the platforms transform.
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            //reverse the pawns transform to normal
            collision.gameObject.transform.parent = null;

        }

    }

}
