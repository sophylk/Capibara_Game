using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public GameObject leftBorder;
    public GameObject rightBorder;
    public bool isRightDirecthion;
    public Rigidbody2D ribody;

    private void Update()
    {
        if (isRightDirecthion)
        {
            ribody.velocity = Vector2.right * speed;
            if (transform.position.x > rightBorder.transform.position.x)
                isRightDirecthion = !isRightDirecthion;
        }
        else
        {
            ribody.velocity = Vector2.left * speed;
            if (transform.position.x < leftBorder.transform.position.x)
                isRightDirecthion = !isRightDirecthion;
        }
    }
}