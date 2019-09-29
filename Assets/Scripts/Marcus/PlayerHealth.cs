using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHandler))]
public class PlayerHealth : Health
{
    PlayerHandler ph;

    public Resource lives = new Resource { max = 3, current = 3, critical = 1 };
    public float invincibilityPeriod = 1;
    float invincibilityTimer;

    public void Awake()
    {
        ph = GetComponent<PlayerHandler>();
    }

    public override void Update()
    {
        invincibilityTimer -= Time.deltaTime;
        base.Update();
    }

    public override void Damage(int damage)
    {
        if (invincibilityTimer > 0)
        {
            print("Player is invincible");
            return;
        }
        base.Damage(damage);
        print("Player is damaged");
        invincibilityTimer = invincibilityPeriod;
    }

    public override void Die()
    {
        invincibilityTimer = 0;
        ph.pc.isDead = true;
        --lives.current;
        ph.gsh.ChangeGameState(GameState.Failed);
    }

    public void Respawn()
    {
        print("Player is respawning");
        ph.pc.isDead = false; //re-enables player movement
        if (lives.current <= 0)
        {
            lives.current = lives.max;
        }
        health.current = health.max; // Replenishes health
        ph.gsh.ChangeGameState(GameState.Active); // Sets game state to active
        Transform spawnPoint = GameObject.FindGameObjectWithTag("PlayerSpawnPoint").transform;
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("PlayerSpawnPoint"))
        {
            Transform sp = g.transform;
            if (Vector3.Distance(transform.position, sp.position) <= Vector3.Distance(transform.position, spawnPoint.position))
            {
                spawnPoint = sp;
            }
        }
        transform.SetPositionAndRotation(spawnPoint.position, Quaternion.Euler(0, spawnPoint.rotation.y, 0));
    }
    
}
