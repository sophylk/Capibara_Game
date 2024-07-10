using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Enemy_behaviour : MonoBehaviour
    {

        #region Public Variables
        public float attackDistance; // Minimum distance for attacks
        public float moveSpeed;
        public float timer; // Timer for cooldown between attacks
        public Transform leftLimit;
        public Transform rightLimit;
        [HideInInspector] public Transform target;
        [HideInInspector] public bool inRange; // Check if Player is in range
        public GameObject triggerArea;
        public GameObject hotZone;
        public float health;


        public Coolscript _damage;
        public HealthSystem hero_hp;

        #endregion

        #region Private Variables
        private Animator anim;
        private float distance; // Store the distance between enemy and player
        private bool attackMode;
        private bool cooling; // Check if Enemy is cooling after attack
        private float intTimer;
        #endregion

        void Awake()
        {
            SelectTarget();
            intTimer = timer; // Store the initial value of timer
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            if (!attackMode)
            {

                Move();
                Cooldown();
            }

            if (!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_bringer_of_death"))
            {
                SelectTarget();
            }

            if (inRange)
            {
                EnemyLogic();
            }
        }



        void EnemyLogic()
        {
            distance = Vector2.Distance(transform.position, target.position);

            if (distance > attackDistance)
            {
                attackMode = false;
                StopAttack();
            }
            else if (attackDistance >= distance && cooling == false)
            {

                Attack();
            }

            if (cooling)
            {
                Cooldown();
                anim.SetBool("Attack", false);

            }
        }

        void Move()
        {
            anim.SetBool("canWalk", true);

            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_bringer_of_death"))
            {
                Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

                transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }
        }

        void Attack()
        {
            timer = intTimer; //Resets Timer when Player enters Attack Range
            attackMode = true; // To check if Enemy can still attack or not
            timer = intTimer;


            anim.SetBool("canWalk", false);
            anim.SetBool("Attack", true);
        }

        void Cooldown()
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                cooling = false;

            }
            else
            {
                cooling = true;

            }
        }

        void StopAttack()
        {
            cooling = false;
            attackMode = false;
            anim.SetBool("Attack", false);
        }

        public void TriggerCooling()
        {
            cooling = true;
        }

        private bool InsideofLimits()
        {
            return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
        }

        public void SelectTarget()
        {
            float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
            float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

            if (distanceToLeft > distanceToRight)
            {
                target = leftLimit;
            }
            else
            {
                target = rightLimit;
            }

            Flip();
        }

        public void Flip()
        {
            Vector3 rotation = transform.eulerAngles;
            if (transform.position.x < target.position.x)
            {
                rotation.y = 180f;
            }
            else
            {
                rotation.y = 0f;
            }

            transform.eulerAngles = rotation;
        }

        public void TakeDamage()
        {

            if (health <= 0)
            {
                //anim.SetBool("canDie", true);
                Destroy(this.gameObject, 0.75f);
                anim.Play("Death_bringer_of_death");
                hero_hp.health += 1;

            }
            else
            {
                health -= _damage.damage;
                anim.Play("Hurt_bringer_of_death");
            }
        }

    }
}