using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{ 
    public List<Transform> playerSpawnPoints;
    public Transform playerStartPoint;
    public GameObject playerPrefab;
    public Player player;
  public  Transform closestSpawnPoint = null;
    public float distance;
    private void Awake()
    {
        // search through all object with tag
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("PlayerSpawnPoint"))
        {
            // add object transforms to the list
            playerSpawnPoints.Add(go.GetComponent<Transform>());
        }
       
    }
    // Start is called before the first frame update
    void Start()
    {     
        // first transform in list (first in heirarchy) == the player start point
        playerStartPoint = playerSpawnPoints[0];
        // get the player prefab in the assest/resources/prefabs/player folders
        playerPrefab = (GameObject)Resources.Load("Prefabs/Player/Player", typeof(GameObject));
        // spawn player at playerstartpoint's position with no rotation
        Instantiate(playerPrefab, playerStartPoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //if player is dead
        if (player.playerDead == true)
        {
           
            float minDistance = Mathf.Infinity;
            // search through playerspawnpoints 
            for (int i = 0; i < playerSpawnPoints.Count; i++)
            {
                
                // float = distance between selected playerspawnpoint.position and player
                 distance = Vector3.Distance(playerSpawnPoints[i].position, player.gameObject.transform.position);
                
                // if the distance is shorter, make that playerspawnpoint the new closestspawnpoint
                if (distance < minDistance)
                {
                    closestSpawnPoint = playerSpawnPoints[i];
                    // the new mindistance to compare the other spawnpoints to.
                    minDistance = distance;
                }
            }
            // instantiate player at the closestspawnpoint.position
            Instantiate(playerPrefab, closestSpawnPoint.position, Quaternion.identity);
        }
        if (player.lives == 0)
        {
            Instantiate(playerPrefab, playerStartPoint.position, Quaternion.identity);
            player.health = 2;
            player.lives = 3;
            player.playerDead = false;
        }
    }
}
