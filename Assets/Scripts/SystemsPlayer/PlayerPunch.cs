using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerPunch : MonoBehaviour
    {
        private int _cost = 5;
        private Animator animator;
        private BoxCollider2D hitbox;
        private PlayerChakra playerChakra;
        public AudioSource audioSource;
        public AudioClip punchSound;

        private void Start()
        {
            playerChakra = GetComponent<PlayerChakra>();
            animator = GetComponent<Animator>();
            hitbox = transform.Find("Punch").GetComponent<BoxCollider2D>();
            audioSource = GetComponent<AudioSource>();
            hitbox.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L)) // Attack on Space key press.
            {
                if (playerChakra.GetChakra() >= _cost)
                {
                    playerChakra.SubstractChakra(_cost);
                    animator.SetBool("isPunching", true);
                    Invoke("ActivateHitbox", 0.2f); // Activate hitbox after 0.2 seconds.
                    Invoke("DeactivateHitbox", 0.4f); // Deactivate hitbox after 0.4 seconds 
                }
                else
                {
                    Debug.LogWarning("No tienes suficiente chakra!");
                }               
            }
        }

        void ActivateHitbox()
        {
            hitbox.gameObject.SetActive(true);
        }

        void DeactivateHitbox()
        {
            hitbox.gameObject.SetActive(false);
            animator.SetBool("isPunching", false);
        }
        public void PlayPunchSound()
        {
            audioSource.PlayOneShot(punchSound);
        }
    }
}