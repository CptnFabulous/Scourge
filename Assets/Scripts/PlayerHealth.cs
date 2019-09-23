using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    PlayerController pc;
    GameStateHandler gsh;

    public override void Die()
    {
        pc.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        pc.enabled = false;
        gsh.ChangeGameState(GameState.Failed);
    }

    public void Respawn()
    {

    }
}
