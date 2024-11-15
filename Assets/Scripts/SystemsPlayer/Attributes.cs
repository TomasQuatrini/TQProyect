using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Attributes
    {
        private string _attName;
        private int _attQuantity;
        public bool isEmpty = false;
        public Attributes (string attName, int attQuantity)
        {
            _attName = attName;
            _attQuantity = attQuantity;
        }
        private void Update()
        {
            Stablizeinzero();
        }
        private void Stablizeinzero()
        {
            if (_attQuantity < 0)
            {
                _attQuantity = 0;
            }
        }
        public int GetAttQuantity()
        {
            return _attQuantity;
        }
        public string GetAttName()
        {
            return _attName;
        }
        public void AddQuantity (int amount)
        {
            if (amount <= 0)
            {
                isEmpty = true;
                Debug.LogWarning("No se puede agregar 0");
            }
            else
            {
            _attQuantity += amount;
            }
        }
        public void RemoveQuantity (int amount)
        {
            if (amount <= 0)
            {
                isEmpty = true;
                Debug.LogWarning("No se puede agregar 0");
            }
            else
            {
            _attQuantity -= amount;
            }
        }
        public void ShowAtt()
        {
            if (isEmpty)
            {
                Debug.LogError($"No tiene nada de {_attName}");
                return;
            }
            Debug.Log($"tiene {_attQuantity} de {_attName}");
        }

        public void SetQuantity(int count)
        {
            _attQuantity = count;
        }
    }
}