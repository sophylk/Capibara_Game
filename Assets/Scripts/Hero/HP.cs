using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthSystem : MonoBehaviour
{
    public int health;
    public int numberofLives;
    public Image[] lives;
    public Sprite fullLife;
    public Sprite emptyLife;

    public void Update()
    {
        if (health > numberofLives) 
        {
            health = numberofLives;
        }


        for (int i = 0; i < lives.Length; i++)
        {
            if (i < health)
            {
                lives[i].sprite = fullLife;
            }
            else
            {
                lives[i].sprite = emptyLife;
            }

            if (i < numberofLives)
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }
        }
    
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}