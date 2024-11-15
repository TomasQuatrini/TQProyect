using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Player
{
    public class Health : MonoBehaviour
    {
        public int life = 10;
        public Animator animator;
        AudioSource audioSource;
        void Start()
        {
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
        }

        void Update()
        {
            VerifyLife();
        }

        public void TakeDamage(int damage)
        {
            animator.SetBool("TakingDamage", true);
            life -= damage;
        }
        public void DamageFinish()
        {
            animator.SetBool("TakingDamage", false);
        }

        public void VerifyLife()
        {
            if (life <= 0)
            {
                animator.SetBool("Destroy", true);
            }
        }
        void DestroyObject()
            {
                Destroy(gameObject);
            }
        public int GetLife()
        {
            return life;
        }
    }
}

