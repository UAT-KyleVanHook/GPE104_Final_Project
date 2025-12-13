using UnityEngine;

public class CollectGem : MonoBehaviour
{

    public int scoreAmount;
    public AudioClip gemClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set audio clip
        gemClip = AudioManager.instance.gemCollectionSoundClip;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //get the player pawn component
        PlayerPawn collidedObject = other.gameObject.GetComponent<PlayerPawn>();



        if (collidedObject != null)
        {

            AudioSource.PlayClipAtPoint(gemClip, transform.position);

            //increment score
            GameManager.instance.score += scoreAmount;

            //destroy object after collection
            Destroy(gameObject);
        }



    }
}
