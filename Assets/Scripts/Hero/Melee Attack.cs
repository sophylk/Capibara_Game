using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    
    private BoxCollider2D hitBox;

    [SerializeField] private Animator animator;

    private void Start()
    {
        
        hitBox = transform.Find("hitBox").GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Attack on Space key press.
        {
            animator.SetBool("Player_Attack", true);
            Invoke("ActivateHitbox", 0.2f); // Activate hitbox after 0.2 seconds.
            Invoke("DeactivateHitbox", 0.4f); // Deactivate hitbox after 0.4 seconds.
        }
        
    }

    void ActivateHitbox()
    {
        hitBox.gameObject.SetActive(true);
    }

    void DeactivateHitbox()
    {
        hitBox.gameObject.SetActive(false);
    }
}