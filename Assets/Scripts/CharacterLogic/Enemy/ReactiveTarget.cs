using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/Reactive Target")]
public class ReactiveTarget : MonoBehaviour
{
    private NavMeshAgent _navAgent;
    private CharacterController _character;
    private PlayerCharacter _player;

    private Collider[] _withinAggroColliders;

    private readonly int _maxColliders = 4;
    private float _currentHealth;

    [SerializeField] private float _detectionRadius;
    [SerializeField] private float _maxHealth;
    [SerializeField] private LayerMask _aggroLayerMask;

    public bool IsAlive { get; set; }
    public bool PlayerIsDetected { get; set; }


    void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        _withinAggroColliders = new Collider[_maxColliders];
        _character = GetComponent<CharacterController>();

        this._currentHealth = this._maxHealth;
        IsAlive = true;
        PlayerIsDetected = false;
    }


    private void FixedUpdate()
    {
        if (Physics.OverlapSphereNonAlloc(this.gameObject.transform.position, _detectionRadius, _withinAggroColliders,
            _aggroLayerMask) > 0)
        {
            PlayerIsDetected = true;
            ChasePlayer(_withinAggroColliders[0].GetComponent<PlayerCharacter>());
        }
        else
        {
            PlayerIsDetected = false;
        }
    }

    public void ReactToHit(int damage)
    {
        _currentHealth -= damage;
        Debug.Log($"Health is damaged at {damage}. Now {_currentHealth}");

        if (_currentHealth.Equals(0.0f))
        {
            FallingDead();
        }
    }

    private void ChasePlayer(PlayerCharacter player)
    {
        _player = player;
        _navAgent.SetDestination(player.transform.position);
    }


    void FallingDead()
    {
        if (this.gameObject != null)
        {
            IsAlive = false;
        }

        StartCoroutine(Die());
    }


    IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.75f);

        Destroy(this.gameObject);
    }
}