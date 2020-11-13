using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private float _currentHealth;
    public bool IsAlive { get; set; }

    void Start()
    {
        IsAlive = true;
        _currentHealth = _maxHealth;
    }

    public void Hurt(int damage)
    {
        _currentHealth -= damage;
        Debug.Log($"Health is damaged at {damage}. Now {_currentHealth}");
        
        if (_currentHealth.Equals(0.0f))
        {
            IsAlive = false;
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        Debug.Log("You`re dead.");
        yield return new WaitForSeconds(2.0f);
    }
}