using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHandler))]
public class PlayerHealth : Health
{
    PlayerHandler ph;

    public void Awake()
    {
        ph = GetComponent<PlayerHandler>();
    }

    public override void Die()
    {
        ph.pc.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        ph.pc.enabled = false;
        ph.gsh.ChangeGameState(GameState.Failed);
    }

    public void Respawn()
    {

    }
}
