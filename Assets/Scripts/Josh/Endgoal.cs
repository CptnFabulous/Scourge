using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endgoal : MonoBehaviour
{
    PlayerHandler ph;     
    private void OnTriggerEnter(Collider other)
    {
        ph = other.GetComponent<PlayerHandler>();
        if (other.tag == "Player")
        {
            Debug.Log("the player should win");
            ph.gsh.ChangeGameState(GameState.Won);
        }                  
    }   
}
