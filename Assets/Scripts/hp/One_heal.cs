using UnityEngine;
namespace Assets.Scripts.Hero
{
    public class One_Heal : MonoBehaviour
    {

        public HealthSystem healthSystem;
        public int redamage;
        public GameObject HEAL;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                healthSystem.ReverseDamage(redamage, HEAL);


            }
        }
    }
}