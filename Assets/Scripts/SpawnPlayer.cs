using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{


    //player prefab
    public GameObject prefabToCopy;
    //player controller
    public Controller controllerToConnect;

    //where to spawn the player in the level
    public Transform spawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        //if there is no playerPawn in the scen, spawn one
        if (GameManager.instance.playerPawn == null && GameManager.instance.playerLives > 0)
        {
            SpawnNewPlayer();
        }

    }

    public void SpawnNewPlayer()
    {
        if (GameManager.instance.playerLives > 0)
        {

            GameObject tempPawn;
            //Spawn at 0,0,0 with a rotation (Quaterion) that is unchanged. Type cast as a GameObject. If it can't type cast, it will make it null.
            tempPawn = Instantiate(prefabToCopy, spawnPoint.position, Quaternion.identity) as GameObject;


            //check that tempPawn is not null, then get the component of tempPawn, as a pawn. Check that the pawnComponent isn't null, then connect the controller to this pawn.
            if (tempPawn != null)
            {
                PlayerPawn pawnComponent = tempPawn.GetComponent<PlayerPawn>();
                if (pawnComponent != null)
                {
                    //controllerToConnect.pawn = pawnComponent;

                    //Use the Controller singleton to connect the pawnComponent to the controller
                    //We need to do this as on a level load, the PlayerCotntroller that is alreadty in the level gets deleted, meaning there is no Controller connected to the player on a new respawn.
                    PlayerController.instance.pawn = pawnComponent;

                    //set tempPawn to playerpawn in GameManager 
                    GameManager.instance.playerPawn = pawnComponent;
                }

            }

        }
    }
}
