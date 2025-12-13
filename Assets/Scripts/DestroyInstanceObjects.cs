using UnityEngine;

public class DestroyInstanceObjects : MonoBehaviour
{

    /// <summary>
    /// This was originally made to destroy all static objects, singletons, and objects marked with don't destroy on load. 
    /// //However, that seesm to make too many errors. So we will just reset the variables that need pto be reset on death.
    /// </summary>


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //destroy all instace objects 
        Destroy(UIManager.instance.gameObject);
        Destroy(PlayerPawn.playerInstance.gameObject);
        Destroy(PlayerController.instance.gameObject);
        Destroy(CamFollowPlayer.instance.gameObject);
        Destroy(PlayerPawn.playerInstance.gameObject);
        Destroy(GameManager.instance.gameObject);


    }

    // Update is called once per frame
    void Update()
    {

        ////destroy player again because its stubborn
        //if(PlayerPawn.playerInstance != null)
        //{
        //    Destroy(PlayerPawn.playerInstance.gameObject);
        //    Destroy(UIManager.instance.gameObject);
        //    Destroy(GameManager.instance.gameObject);
        //    Destroy(PlayerController.instance.gameObject);
        //    Destroy(CamFollowPlayer.instance.gameObject);
        //}
        
    }
}
