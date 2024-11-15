using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class HealthGeneral : MonoBehaviour
    {
        [SerializeField] int life = 10;

        void Update()
        {
            Destruct();
        }
        public void TakeDamage(int damage)
        {
            life -= damage;        
        }
        public void Destruct()
        {
            if (life <= 0)
            {
            Destroy(gameObject);
            }
        }
        public int GetLife()
        {
            return life;
        }
    }
}

