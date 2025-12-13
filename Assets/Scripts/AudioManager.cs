using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    //Singleton variable
    public static AudioManager instance;


    [Header("SoundClips")]
    public AudioClip jumpingSoundClip;
    public AudioClip keyCollectionSoundClip;
    public AudioClip coinCollectionSoundClip;
    public AudioClip gemCollectionSoundClip;
    public AudioClip springSoundClip;
    public AudioClip backgroundMusicClip;
    public AudioClip playerDamageClip;
    public AudioClip switchSoundClip;


    //[Header("Audio Sources")]
   // public AudioSource backgroundMusicSource;

    void Awake()
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


        //backgroundMusicSource.clip = backgroundMusicClip;
        //backgroundMusicSource.Play();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
