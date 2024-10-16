using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _currentHealth = 1;
    private int _damageFall = 1;
    private int _takeHealth = 1;
    private int _limitHealth = 3;
    private bool _checkHealthDead = false;
    public int health = 1;
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
        CheckInputs();
    }

    private void CheckInputs()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerTakeDamage();
            return;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            PlayerTakeHealth();
            return;
        }
    }

    public void PlayerTakeDamage()
    {
        if (_checkHealthDead == false)
        {
            _currentHealth -= _damageFall;
            Debug.Log($"El Jugador perdio {_damageFall} vida");
            CheckHealth();

            if (_checkHealthDead == true)
            {
                _currentHealth = 0;
                PlayerIsDead();
                return;
            }
            else
            {
                Debug.Log($"Al jugador le quedan {_currentHealth} vidas");
                return;
            }
        }
        if (_checkHealthDead == true)
        {
            Debug.LogError("El jugador no tiene vidas, recarga con la V");
        }
    }

    private void PlayerIsDead()
    {
        Debug.LogError("El Jugador ha muerto");
        return;
    }

    private void PlayerTakeHealth()
    {
        if (_currentHealth < _limitHealth)
        {
            _currentHealth += _takeHealth;
            Debug.Log($"El Jugador cargo una vida, ahora tiene {_currentHealth}");
            return;
        }
        if (_currentHealth >= _limitHealth)
        {
            _currentHealth = _limitHealth;
            Debug.LogError($"El Jugador ya tiene {_limitHealth} vidas, no puede recargar mas"); 
        }
    }

    private void CheckHealth()
    {
        if (_currentHealth <= 0)
        {
            _checkHealthDead = true;
        }
        else
        {
            _checkHealthDead = false;
        }
    }
}
