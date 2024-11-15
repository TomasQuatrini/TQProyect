using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private float jumpForce = 5f;
        [SerializeField] private LayerMask Ground;
        [SerializeField] private byte jumpsMust = 2;
        [SerializeField] bool isGrounded;
        [SerializeField] bool isJumping = false;
        [SerializeField] byte jumpsRemaining;
        [SerializeField] Rigidbody2D rigidbody2D;
        [SerializeField] Collider2D Collider;
        [SerializeField] Animator animator;
        [SerializeField] PlayerChakra playerChakra;
        [SerializeField] bool lookRight = true;
        private void Start()
        {
            Collider = GetComponent<Collider2D>();
            rigidbody2D = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            JumpRestart();
        }
        private void Update()
        {
            CheckforGrounded();
            Moving();
            Jumping();
        }
        private void Moving()
        {
            float inputMove = Input.GetAxis("Horizontal");

            if (Collider.IsTouchingLayers(LayerMask.GetMask("Trunk")) && rigidbody2D.velocity.y < 0)
            {
                // Reset velocity when trunk collide
                isCollising();
            }
            else
            {
                if (inputMove != 0)
                {
                    rigidbody2D.velocity = new Vector2(inputMove * movementSpeed, rigidbody2D.velocity.y);
                    animator.SetFloat("Horizontal", Mathf.Abs(inputMove));
                    animator.SetBool("isWalking", true);
                    Orientation(inputMove);
                }
                else
                {
                    animator.SetBool("isWalking", false);
                    rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
                    animator.SetFloat("Horizontal", 0);
                }
            }
        }
        private void Orientation(float inputMove)
        {
            if ((lookRight && inputMove < 0) || (!lookRight && inputMove > 0))
            {
                lookRight = !lookRight;
                transform.localScale = new Vector2(Mathf.Sign(inputMove), transform.localScale.y);
            }
        }
        private void Jumping()
        {
            animator.SetFloat("Vertical", rigidbody2D.velocity.y);
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {            
                rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpsRemaining--;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && jumpsRemaining > 0)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
                rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpsRemaining--;
            }
        }
        private void JumpRestart()
        {
            jumpsRemaining = jumpsMust;
            isJumping = false;
        }
        private void CheckforGrounded()
        {
            float distancia = 0.5f; // Distancia del raycast
            LayerMask layerMask = LayerMask.GetMask("Ground"); // Capa del suelo
            LayerMask layerMask1 = LayerMask.GetMask("Water");
            RaycastHit2D hit = Physics2D.Raycast(
                transform.position + new Vector3(0, -Collider.bounds.size.y / 2), 
                Vector2.down, 
                distancia, 
                layerMask);
            
            if (hit.collider != null)
            {
                Debug.Log("Collider detectado: " + hit.collider.name);
                isGrounded = true;
                animator.SetBool("isGrounded", true);
                JumpRestart();
                jumpsRemaining = jumpsMust;
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Water"))
                {
                    playerChakra.ChakraDrain(); // Llama a la función ChakraDrain
                }
            }
            else
            {
                Debug.Log("No se detectó collider");
                isGrounded = false;
                animator.SetBool("isGrounded", false);
            }
        }
        private void isCollising()
        {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
        }
    }
}