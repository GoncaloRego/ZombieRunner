using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;

    public bool IsDead
    {
        get
        {
            return isDead;
        }
    }

    public void TakeDamage(float damage)
    {
        GetComponent<EnemyController>().GotShot();
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead == true)
        {
            return;
        }
        GetComponent<Animator>().SetTrigger("isDead");
        isDead = true;
    }
}
