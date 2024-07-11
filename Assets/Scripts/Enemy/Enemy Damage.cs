using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public HealthSystem healthSystem;
    public int damage;
    public Collider2D WeaponCollider;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.otherCollider != WeaponCollider) return;
        if (collision.gameObject.tag == "Player")
        {
            healthSystem.TakeDamage(damage);

            WeaponCollider.gameObject.SetActive(false);
            WeaponCollider.enabled = false;

            Invoke("EnableCollider", 2f); // Re-enable collider after 1 second

        }
    }
    private void EnableCollider()
    {
        WeaponCollider.gameObject.SetActive(true);
        WeaponCollider.enabled = true;
    }
}