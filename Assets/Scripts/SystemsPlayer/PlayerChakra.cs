using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class PlayerChakra : MonoBehaviour
{
    [SerializeField] Attributes _chakra = new Attributes("_chakra", 10);
    [SerializeField] TilemapWater tilemapWater;
    [SerializeField] float chakra;
    private void Start()
    {
        tilemapWater = GetComponent<TilemapWater>();
        CorrectChakra();
    }
    private void Update()
    {
        chakra = GetChakra();
        ShowChakra();
    }   
    public void ShowChakra()
    {
        Debug.Log($"tienes {chakra} de chakra");
    }
    public void SubstractChakra(float count)
    {
        _chakra.RemoveQuantity(count);
    }
    public void AddChakra(int count)
    {
        _chakra.AddQuantity(count);
        Debug.Log($"Has cargado {count} de chakra");
    }
    public float GetChakra()
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
    public IEnumerator ChakraDrain()
    {
        if (_chakra.GetAttQuantity() > 0)
        {
            while (true)
            {
                yield return new WaitForSeconds(1f); // Espera 1 segundo
                SubstractChakra(0.1f); // Resta 0.1 de chakra
                Debug.Log("Estas caminando sobre el agua, consume 0.1 chakra por segundo");
            }
        }
        else 
        {
            TilemapWater.ActivateWaterTrigger = false;
        }
    }
}
