using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    //Singleton variable
    public static AudioManager instance;


    [Header("SoundClips")]
    public AudioClip jumpingSound;
  

    [Header("Audio Sources")]
    public AudioSource backgroundMusicSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //check that there is not another instance of UIManager currently in the level. 
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
