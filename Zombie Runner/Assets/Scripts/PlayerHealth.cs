using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    DeathHandler deathHandler;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        deathHandler = GetComponent<DeathHandler>();
        deathHandler.HandleDeath();
    }
}
