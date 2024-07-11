using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 5;
    [SerializeField] private Animator animator;

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
        else
            {
                
                animator.SetBool("Hurt", true);
                StartCoroutine(ResetHurtAnimation());

            }
        }

        private IEnumerator ResetHurtAnimation()
        {
            yield return new WaitForSeconds(0.5f);
            animator.SetBool("Hurt", false);
        }
    }

