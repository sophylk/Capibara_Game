using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class HealthSystem : MonoBehaviour
{
    public int health;
    public int numberofLives;
    public Image[] lives;
    public Sprite fullLife;
    public Sprite emptyLife;

    [SerializeField] private Animator animator;

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
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            animator.SetBool("Damage", true);
            StartCoroutine(ResetHurtAnimation());
        }
    }

    public void ReverseDamage(int amount, GameObject gameObject2)
    {
        health += amount;
        Destroy(gameObject2);
    }

    private IEnumerator ResetHurtAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Damage", false);
    }

}
