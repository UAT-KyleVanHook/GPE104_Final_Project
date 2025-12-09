using UnityEngine;

public class PlayerDeath : DeathComponent
{
    //destroy the gameObject this script is attached to.
    public override void Die()
    {
        //de-increment playerlives
        GameManager.instance.playerLives -= 1;

        //destroy this object
        Destroy(gameObject);

    }
}
