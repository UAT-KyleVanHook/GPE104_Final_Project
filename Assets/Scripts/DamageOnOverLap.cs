using UnityEngine;

public class DamageOnOverLap : MonoBehaviour
{
    public bool isInstaKill;
    public int damageDone;
    //public int scoreAmount;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //get healthComponenet
        HealthComponent otherHealth = other.gameObject.GetComponent<HealthComponent>();

        //check that the object has the health component
        if (otherHealth != null)
        {
            // if instakill is true, immeadiatly kill on trigger
            if (isInstaKill == true)
            {
                //check that object has a death componenet
                DeathComponent otherDeath = other.gameObject.GetComponent<DeathComponent>();

                if (otherDeath != null)
                {
                   
                    otherHealth.Die();
                }

            }
            else
            {

                //otherwise just take damage
                otherHealth.TakeDamage(damageDone);

            }

        }

    }
}
