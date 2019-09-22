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
    public bool playerDead = false;
    public float distance;
    public int lives = 3;
    Vector3 spawnNotInFloor = new Vector3 (0, 1, 0);
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
        // spawn player at playerstartpoint's position with no rotation
        clone = Instantiate(playerPrefab, playerStartPoint.position + spawnNotInFloor, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // call function
        GetClosestSpawnPoint();

        if (lives == 0)
        {
            playerDead = false;
            clone = Instantiate(playerPrefab, playerStartPoint.position + spawnNotInFloor, Quaternion.identity);
            lives = 3;
        }
        if (playerDead == true && lives > 0)
        {       
            Destroy(clone);
            Debug.Log("player has died");
            // instantiate player at the closestspawnpoint.position
            clone = Instantiate(playerPrefab, closestSpawnPoint.position + spawnNotInFloor, Quaternion.identity);
            playerDead = false;
        }
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
            distance = directionToTarget.sqrMagnitude;
            // if the distance between the player and the searched spawnpoint is less than infinity, 
            if (distance < MinDistance)
            {
                //set the originally infinite float to equal the distance between the player and the searched spawnpoint
                MinDistance = distance;
                // set closestspawnpoint to be the searched spawnpoint
               closestSpawnPoint = potentialSpawn;
            }
        }      
        // return the new closestspawnpoint to exit
        return closestSpawnPoint;
        
    }
}
