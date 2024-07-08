using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public HealthSystem healthSystem;
    public int damage;
    public Collider2D HeroCollider;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            healthSystem.TakeDamage(damage);
            HeroCollider.enabled = false;
            Invoke("EnableCollider", 1.0f); // Re-enable collider after 1 second
            
        }
    }

    private void EnableCollider()
    {
        HeroCollider.enabled = true;
    }

}
