using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public List<Transform> enemyWaypoints;
    public Transform wayPoint1;
    public Transform wayPoint2;
    public bool reachedDestination;
    public GameObject enemy;
    private void Start()
    {
        enemy = this.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (reachedDestination == true)
        {
           enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, wayPoint2.position, .1f);
        }
        if (reachedDestination == false)
        {
           enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, wayPoint1.position, .1f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("WayPoint1"))
        {
            reachedDestination = true;
        }
        if (other.tag == ("WayPoint2"))
        {
            reachedDestination = false;
        }
    }

}
