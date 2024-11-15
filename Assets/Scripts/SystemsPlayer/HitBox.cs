using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
public class HitBox : MonoBehaviour
{
    PlayerPunch playerPunch;
    private int damage = 5;
    private void Start()
    {
        playerPunch = transform.parent.GetComponent<PlayerPunch>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destructible"))
        {
            playerPunch.PlayPunchSound();
            collision.GetComponent<Health>().TakeDamage(damage);        
        }
    }
}
