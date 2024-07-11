using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Enemy
{
    public class Spell : MonoBehaviour
    {
        //public Enemy_behaviour[] damage;
        public void OnTriggerEnter2D(Collider2D collision)
        {
            //Debug.Log("Hitbox collided with: " +collision.gameObject);
            if (collision.CompareTag("Enemy"))
            {

                Enemy_behaviour b = collision.gameObject.GetComponent<Enemy_behaviour>();


                b.SpellTakeDamage();
            }
        }
    }
}
