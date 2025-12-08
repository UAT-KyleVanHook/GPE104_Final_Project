using UnityEngine;

public class AddScore : MonoBehaviour
{

    public int scoreAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnTriggerEnter2D(Collider2D other)
    {

        PlayerPawn collidedObject = other.gameObject.GetComponent<PlayerPawn>();

        if (collidedObject != null)
        {

            //AudioSource.PlayClipAtPoint(GameManager.instance.pickupSound, transform.position);

            //increment score
            GameManager.instance.score += scoreAmount;

            //destroy object after collection
            Destroy(gameObject);
        }



    }
}
