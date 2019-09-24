using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [HideInInspector] public PlayerHealth ph;
    [HideInInspector] public PlayerController pc;
    [HideInInspector] public GameStateHandler gsh;

    private void Awake()
    {
        ph = GetComponent<PlayerHealth>();
        pc = GetComponent<PlayerController>();
        gsh = GetComponent<GameStateHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
