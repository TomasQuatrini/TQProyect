using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class PlayerChakra : MonoBehaviour
{
    private Attributes _chakra = new Attributes("_chakra", 10);

    private void Start()
    {
        CorrectChakra();
    }

    public void SubstractChakra(int count)
    {
        _chakra.RemoveQuantity(count);
    }
    public void AddChakra(int count)
    {
        _chakra.AddQuantity(count);
        Debug.Log($"Has cargado {count} de chakra");
    }
    public int GetChakra()
    {
        return _chakra.GetAttQuantity();
    }

    private void CorrectChakra()
    {
        if (_chakra.GetAttQuantity() >= 100)
        {
            _chakra.SetQuantity(100);
        }
    }  
    
}
