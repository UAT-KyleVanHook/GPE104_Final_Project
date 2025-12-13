using UnityEngine;

public class DestroyKey : MonoBehaviour
{
    public AudioClip keyClip;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //add this key to the list in LockKeyList
        LockKeyList.instance.keyList.Add(this);

        keyClip = AudioManager.instance.keyCollectionSoundClip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        //Remove this key from the list in LockKeyList
        LockKeyList.instance.keyList.Remove(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if the collider has a player tag
        if (collision.gameObject.CompareTag("Player"))
        {
            // play sound clip
            AudioSource.PlayClipAtPoint(keyClip, transform.position);

            //destroy object
            Destroy(gameObject);

        }

    }
}
