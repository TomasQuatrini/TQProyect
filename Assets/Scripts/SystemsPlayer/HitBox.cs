using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
public class HitBox : MonoBehaviour
{
    [SerializeField] PlayerPunch playerPunch;
    [SerializeField] int damage = 5;
    [SerializeField] void Start()
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
