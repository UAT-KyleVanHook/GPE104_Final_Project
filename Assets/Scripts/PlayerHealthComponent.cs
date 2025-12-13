using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthComponent : HealthComponent
{
    //variables for the attached health bar in the UI canvas
    //public Slider healthBarSlider;
    //public TextMeshProUGUI healthBarTextValue;

    public AudioClip hurtSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;

        hurtSound =  AudioManager.instance.playerDamageClip;

    }

    // Update is called once per frame
    void Update()
    {

        //healthBarTextValue.text = currentHealth.ToString() + "/" + maxHealth.ToString();

        //get the current health and max health over to the UIManager
        UIManager.instance.currentHealth = currentHealth;
        UIManager.instance.maxHealth = maxHealth;

    }

    public override void TakeDamage(int amount)
    {

        AudioSource.PlayClipAtPoint(hurtSound, transform.position);

        currentHealth = currentHealth - amount;


        //if object isn't alive, set health to zero and tell it to die.
        if (!isAlive())
        {

            currentHealth = 0;

            //set this here to make it so the zero value shows up on the health bar
            UIManager.instance.currentHealth = currentHealth;
            UIManager.instance.maxHealth = maxHealth;

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
