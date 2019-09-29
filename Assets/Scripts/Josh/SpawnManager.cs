using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Transforms")]
    public List<Transform> playerSpawnPoints;
    public Transform playerStartPoint;
    public Transform closestSpawnPoint = null;
    [Header("Instantiated Entities")]
    public List<GameObject> enemies;
    public GameObject playerPrefab;
    GameObject clone;
    [Header("PlayerInfo")]  
    public float distance;
    Vector3 spawnNotInFloor = new Vector3(0, 1, 0);
    // ref to marcus's scripts
    public PlayerHealth ph;
    public Health h;
    public PlayerController playercon;
    private void Awake()
    {
        // search through all object with tag
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("PlayerSpawnPoint"))
        {
            // add object transforms to the list
            playerSpawnPoints.Add(go.GetComponent<Transform>());

        }
        // get the player prefab in the assest/resources/prefabs/player folders
        playerPrefab = (GameObject)Resources.Load("Prefabs/Player/Player", typeof(GameObject));
        
    }
    // Start is called before the first frame update
    void Start()
    {
        // first transform in list (first in heirarchy) == the player start point
        playerStartPoint = playerSpawnPoints[0];
        playerStartPoint.position = playerStartPoint.position + spawnNotInFloor;

        // spawn player at playerstartpoint's position with no rotation
        clone = Instantiate(playerPrefab, playerStartPoint.position + spawnNotInFloor, Quaternion.identity);
    }
    private void FixedUpdate()
    {
        // call function
        GetClosestSpawnPoint();
    }
    // Update is called once per frame
    void Update()
    {            
        /* // This stuff happening in Update() is commented out for now so I can test stuff
        // if the lives current in the health script is 0 
        if (ph.lives.current == 0)
        {
            // player dies and loses a life
            ph.Die();
            Debug.Log("player has died for the final time... jk");
            // respawn player at the playerstartpoint.position   
            ph.Respawn(playerStartPoint);

        }
        // if the player has died but has more than 0 lives
        if (playercon.isDead == true && ph.lives.current > 0)
        {
            // player dies and loses a life
            ph.Die();
            // respawn player at the closestspawnpoint.position   
            ph.Respawn(closestSpawnPoint);
            Debug.Log("player has died");
        }
        */
    }
    // returns a transform (The closest spawnpoint to the player)
    Transform GetClosestSpawnPoint()
    {
        // mindistance between player and closest spawnpoint set to infinity at first
        float MinDistance = Mathf.Infinity;
        // search through all the transforms (spawnpoints) in the playerspawnpoints list
        foreach (Transform potentialSpawn in playerSpawnPoints)
        {
            // a v3 coordinate equal to the value of the v3 of the spawnpoint it has searched - the players v3 position
            Vector3 directionToTarget = potentialSpawn.position - clone.transform.position;
            // distance float is equal to the v3 coord squared so it can be 1 value.
           float distanceToTarget = directionToTarget.sqrMagnitude;
            // if the distance between the player and the searched spawnpoint is less than infinity, 
            if (distanceToTarget < MinDistance)
            {
                //set the originally infinite float to equal the distance between the player and the searched spawnpoint
                MinDistance = distanceToTarget;
                // set closestspawnpoint to be the searched spawnpoint
                closestSpawnPoint = potentialSpawn;
                // for debug purposes
                distance = distanceToTarget;
               
            }
          
        }
        // return the new closestspawnpoint to exit
        //Debug.Log(closestSpawnPoint.ToString());
        return closestSpawnPoint;

    }


}
