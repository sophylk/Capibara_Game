using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float smoothTime = 0.05f;
    private float velocity = 0.0f;

    [SerializeField] private Transform target;

    private void Update()
    {
        float newPos = Mathf.SmoothDamp(transform.position.y, target.position.y + 2f, ref velocity, smoothTime);
        transform.position = new Vector3(target.position.x, newPos, -10f);
    }
}
