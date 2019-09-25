using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public Enemy enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyWayPoint")
        {
            enemy.reachedDestination = true;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           --enemy.enemyHealth;
        }
    }
}
