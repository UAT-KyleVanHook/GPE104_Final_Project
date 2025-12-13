using UnityEngine;
using UnityEngine.UIElements;

public class MoveEnemy : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    //move speed
    public float moveSpeed;

    //next position the object should move towards
    private Vector3 nextPosition;

    public SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextPosition = pointB.position;

        //get sprite renderer for the player pawn
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);

        //Check if current transform.position is equal to the nextPosition
        if (transform.position == nextPosition)
        {
            //conditional if statement to check what the next position will be.
            //If nextPosition is already equal to pointA, set it to PointB. If it is not, set it to pointA.
            nextPosition = (nextPosition == pointA.position) ? pointB.position : pointA.position;

            //check if the object is omn the left side, if true flip the sprite 
            //if it is not true and is on the right side, reset the sprite to its original position
            if (transform.localPosition.x < 0)
            {
                Debug.Log("Target is on the LEFT");

                spriteRenderer.flipX = true;
            }
            else if (transform.localPosition.x > 0)
            {
                Debug.Log("Target is on the RIGHT");

                spriteRenderer.flipX = false;
            }

        }

    }
}
