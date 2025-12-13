using UnityEngine;
using UnityEngine.SceneManagement;

public class ForLoopSpawn : MonoBehaviour
{
    public GameObject spawnObject;
    public Transform spawnPoint;

    public int spawnCount;
    bool bIsButtonPressed;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    public AudioClip switchClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();



        //set bIsButtonPressed to false
        bIsButtonPressed = false;

        switchClip = AudioManager.instance.switchSoundClip;

    }

    // Update is called once per frame
    void Update()
    {

        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the colliding object is a player, go to the spawn method
        if (collision.gameObject.CompareTag("Player"))
        {
           SpawnObjects();
        }

    }


    private void SpawnObjects()
    {

        //if the bool bIsButtonPressed is false, 
        if (!bIsButtonPressed)
        {
            //spawn point for the spawn object
            Vector3 spawnPos = spawnPoint.position;

            //until i equals spawnCount, spawn an object
            for (int i = 0; i < spawnCount; i++)
            {
                //spawn object
                Instantiate(spawnObject, spawnPos, Quaternion.identity);

                //set the spawn point to the right one unit.
                spawnPos = new Vector3(spawnPos.x + 1, spawnPos.y, spawnPos.z);
            }

            //bIsButtonPressed is now true, set it true to this method only happens once
            bIsButtonPressed = true;

            //set the current sprite to the new Sprite
            spriteRenderer.sprite = newSprite;

            //play sound clip
            AudioSource.PlayClipAtPoint(switchClip, transform.position);

        }

    }
}
