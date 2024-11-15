using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapWater : MonoBehaviour
{
    Collider2D collider2D; 
    public static bool ActivateWaterTrigger = true;
    void Start()
    {
        collider2D = GetComponent<Collider2D>();
    }
    private void Update()
    {
        if(ActivateWaterTrigger is true)
        {
        collider2D.isTrigger = true;
        }
        else
        {
        collider2D.isTrigger = false;
        }
    }
}
   
