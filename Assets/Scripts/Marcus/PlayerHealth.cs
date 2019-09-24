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
        ph.pc.isDead = true;
        ph.gsh.ChangeGameState(GameState.Failed);
    }

    public void Respawn()
    {
        ph.pc.isDead = false;
        ph.pc.transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
        ph.gsh.ChangeGameState(GameState.Active);
        health.current = health.max;
    }
}
