using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Ramen : MonoBehaviour
{
    [SerializeField] int chakraAmount = 5; // Cantidad de chakra que se proporciona
    [SerializeField] Collider2D Collider2D;
    [SerializeField] PlayerChakra playerChakra; // Referencia al script de chakra del PJ
    void Start()
    {
        Collider2D = GetComponent<Collider2D>();
        playerChakra = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerChakra>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerChakra.AddChakra(chakraAmount);
            Destroy(gameObject); // Destroy object
        }
    }
}

