using UnityEngine;

public class DeathDestroy : DeathComponent
{

    //destroy the gameObject this script is attached to.
    public override void Die()
    {

        //destroy this object
        Destroy(gameObject);

    }

}
