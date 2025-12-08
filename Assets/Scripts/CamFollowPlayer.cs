using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{

    public float followSpeed;
    public Transform target;
    public float yOffSet;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //make a new vector position for the camera. The -10 in the Z position is to make sure that camera stays on the right layer for a 2D game.
        Vector3 newPosition = new Vector3(target.transform.position.x, target.transform.position.y + yOffSet, -10f);

        //set the transform position of the camera to the players
        transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed * Time.deltaTime);
        
    }
}
