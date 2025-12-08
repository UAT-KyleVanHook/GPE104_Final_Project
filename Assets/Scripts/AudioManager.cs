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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
