using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthComponent : HealthComponent
{
    //variables for the attached health bar in the UI canvas
    public Slider healthBarSlider;
    public TextMeshProUGUI healthBarTextValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        healthBarTextValue.text = currentHealth.ToString() + "/" + maxHealth.ToString();

        healthBarSlider.value = currentHealth;
        healthBarSlider.maxValue = maxHealth;

    }

    public override void TakeDamage(int amount)
    {

        //AudioSource.PlayClipAtPoint(GameManager.instance.shipHurtSounds, transform.position);

        currentHealth = currentHealth - amount;


        //if object isn't alive, set health to zero and tell it to die.
        if (!isAlive())
        {

            currentHealth = 0;

            //set this here to make it so the zero value shows up on the health bar
            healthBarSlider.value = currentHealth;
            healthBarTextValue.text = currentHealth.ToString() + "/" + maxHealth.ToString();

            Die();
        }

    }

    public override bool isAlive()
    {
        //check that the health is more than zero
        if (currentHealth > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public override void Heal(int amount)
    {

        currentHealth = currentHealth + amount;

        //check that the current health isn't larger than the maxhealth. If true, set health to maxhealth
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

    }

    public override void Die()
    {

        //reset health for player respawning for health bar 
        //currentHealth = maxHealth;

        //TODO: handle death in the health component
        DeathComponent death = GetComponent<DeathComponent>();

        //check that the object can die
        if (death != null)
        {
            //AudioSource.PlayClipAtPoint(GameManager.instance.shipHurtSounds, transform.position);

            death.Die();
        }
    }
}
