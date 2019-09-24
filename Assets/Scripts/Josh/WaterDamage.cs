using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDamage : MonoBehaviour
{
    public int waterDamage = 1;
    private Resource resource;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth ph = other.GetComponent<PlayerHealth>();
        if (ph != null)
        {
            ph.Damage(waterDamage);         
        }
    }
}
