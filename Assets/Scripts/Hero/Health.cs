using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 5;

    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
