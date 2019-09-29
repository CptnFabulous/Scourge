using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Resource health = new Resource { max = 3, current = 3, critical = 1 };
    public virtual void Update()
    {
        if (health.current <= 0)
        {
            Die();
        }
    }

    public virtual void Damage(int damage) // Declare Damage() and Heal() from another script to damage or heal the thing with this health script. E.g. enemy.GetComponent<Health>().Damage(attackDamage);
    {
        health.current -= damage;
    }

    public virtual void Heal(int healing) // The Heal() function may seem redundant, but I made it separate from the Damage() function so that they can be overidden with unique effects e.g. pain/heal animations
    {
        health.current += healing;
    }

    public virtual void Die() // Override this to include functions such as death animations, game over screen etc.
    {      
        Destroy(gameObject);
    }

    public bool IsDead()
    {
        if (health.current <= 0)
        {
            return true;
        }
        return false;
    }
}
