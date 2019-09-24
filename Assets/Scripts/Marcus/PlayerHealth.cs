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

    public void Respawn(Transform spawnPoint)
    {
        ph.pc.isDead = false;
        ph.gsh.ChangeGameState(GameState.Active);
        health.current = health.max;
        transform.SetPositionAndRotation(spawnPoint.position, Quaternion.Euler(0, spawnPoint.rotation.y, 0));
    }
}
