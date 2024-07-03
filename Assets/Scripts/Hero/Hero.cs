using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] public float speed;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetButton("Running"))
            Running();
    }

    private void Running()
    {
        Vector3 dir = transform.right * Input.GetAxis("Running");
        speed = 8;
        sprite.flipX = dir.x < 0.0f;
    }
}



