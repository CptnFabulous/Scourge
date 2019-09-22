using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject enemy;
    public List<Transform> enemyWaypoints;
    public bool reachedDestination;
    public float enemySpeed;
    public int waypointCount;
    private void Start()
    {
        // get the gameobject this script is attatched to.
        enemy = this.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        // if the waypointcount goes over the length of the list it is equal to zero
        if (waypointCount >= enemyWaypoints.Count)
        {
            waypointCount = 0;
        }
        // if the enemy has reached the waypoint it is moving towards, waypointcount increments and reachedDestination = false as it has a new destination
        if (reachedDestination == true)
        {
           ++waypointCount;
            reachedDestination = false;
        }
        // if reachedDestination = false, move the enemy to the targeted waypoint
        else { enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, enemyWaypoints[waypointCount].position, enemySpeed); }
       
    }
    // if the enemy enters a trigger tagged EnemyWayPoint, it will set reachedDestination to true
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyWayPoint")
        {
            reachedDestination = true;
        }
       
    }
  
}
