using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public override void Damage(int damage)
    {
        base.Damage(damage);
        // play pain animations and other stuff
    }

    public override void Heal(int healing)
    {
        base.Heal(healing);
        // play healing animations and other stuff
    }

    public override void Die()
    {
        base.Die();
        // play death animations and other stuff
    }

}
