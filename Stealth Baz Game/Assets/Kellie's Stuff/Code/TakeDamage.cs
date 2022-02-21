using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public int maxHealth;
    public float currentHealth;

    public GameObject woops;

    public HealthBar healthBar;
    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            currentHealth -= 10;

            healthBar.SetHealth(currentHealth);
        }

    }
    

    void Update()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            currentHealth -= 10;

            healthBar.SetHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            woops.SetActive(true);
        }
    }
}
