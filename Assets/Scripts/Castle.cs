using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : GameSystem
{
    public float maxHealth = 100;
    public float currentHealth;

    public Hpbar healthBar;

    void TakeDamaged(float _dmg)
    {
        currentHealth -= _dmg;

        healthBar.SetHealth(currentHealth);
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

   
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
            TakeDamaged(20);
		}
    }
}
