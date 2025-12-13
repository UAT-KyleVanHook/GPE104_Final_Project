using UnityEngine;

public class SetPlayerEntryPoint : MonoBehaviour
{

    public Transform entryPoint;

    public PlayerPawn player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //find the player that has loaded between the level load.
        //player = FindAnyObjectByType(typeof(PlayerPawn)) as PlayerPawn;
        player = GameManager.instance.playerPawn;

        //set the players transform to the level entryPoint.
        player.gameObject.transform.position = entryPoint.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
