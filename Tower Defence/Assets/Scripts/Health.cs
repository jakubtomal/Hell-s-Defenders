using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int StartingHealth = 100;
    [SerializeField] GameObject particleEffectPrefab;
    [SerializeField] private int health;

    private void Start()
    {
        health = StartingHealth;
    }

    public void DealDamage(int damege)
    {
        health -= damege;

        if (health <= 0)
        {
            Die();
        }
    }



    private void Die()
    {
        GameObject deathVFX = Instantiate(particleEffectPrefab, transform.position, transform.rotation);
        Destroy(deathVFX, 2f);
        Destroy(gameObject);
    }
}
