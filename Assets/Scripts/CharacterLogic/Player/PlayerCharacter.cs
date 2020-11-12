using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private float _health;

    void Start()
    {
        _health = 5;
    }

    public void Hurt(float damage)
    {
        _health -= damage;
        Debug.Log($"Health is damaged at {damage}. Now {_health}");
    }
}