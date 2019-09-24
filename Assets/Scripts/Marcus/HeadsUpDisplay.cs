using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerHandler))]
public class HeadsUpDisplay : MonoBehaviour
{
    PlayerHandler ph;

    public Text healthMeter;

    public Color statNormal;
    public Color statCritical;

    private void Awake()
    {
        ph = GetComponent<PlayerHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthMeter.text = ph.ph.health.current + "/" + ph.ph.health.max;
        if (ph.ph.health.IsCritical() == true)
        {
            healthMeter.color = statCritical;
        }
        else
        {
            healthMeter.color = statNormal;
        }
    }
}
