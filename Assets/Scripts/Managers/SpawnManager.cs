using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{ 
    public List<Transform> playerSpawnPoints;
    public Transform playerStartPoint;
    public GameObject playerPrefab;
  
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
        
    }
}
