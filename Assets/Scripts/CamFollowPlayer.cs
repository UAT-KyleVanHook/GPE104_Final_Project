using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{

    public float followSpeed;
    //public PlayerPawn target; Not needed now that the GameManager has a reference to the current PlayerPawn that is spawned
    public float yOffSet;

    public static CamFollowPlayer instance;


    void Awake()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //check that there is not another instance of CamFollowPlayer currently in the level. 
        //If we don't have a PlayerInstance, set this instance as the current instance. Otherwise, destroy the other instance.
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        //don't destroy object on scene load
        GameObject.DontDestroyOnLoad(gameObject);

        //NOTE:Make sure that the playerController is empty as for some reason if it has an object assigned to control at the start of game, the camera will not work.

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("CamFollowPlayer target:" + target);

        //make a new vector position for the camera. The -10 in the Z position is to make sure that camera stays on the right layer for a 2D game.
        Vector3 newPosition = new Vector3(GameManager.instance.playerPawn.gameObject.transform.position.x, GameManager.instance.playerPawn.gameObject.transform.position.y + yOffSet, -10f);

        //set the transform position of the camera to the players
        transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed * Time.deltaTime);

    }
}
