using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDamage : MonoBehaviour
{
    PlayerHealth ph;   
    public int waterDamage = 1;
    private void OnTriggerEnter(Collider other)
    {
        ph = other.GetComponent<PlayerHealth>();
        if (other.tag == "Player")
        {            
            Debug.Log("i should be damaging the player");         
            ph.Damage(waterDamage);           
        }

    }
   
}
