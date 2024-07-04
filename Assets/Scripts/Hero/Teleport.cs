using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform point;
    private Vector3 pos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pos = point.position;
            pos.z = -5;
            collision.transform.position = Vector3.Lerp(transform.position, pos, 1);


        }
    }
}