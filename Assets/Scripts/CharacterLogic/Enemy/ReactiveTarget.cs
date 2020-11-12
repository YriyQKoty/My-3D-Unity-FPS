using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/Reactive Target")]
public class ReactiveTarget : MonoBehaviour
{
    private CharacterController _character;
    private WanderingAI _ai;


    void Start()
    {
        _character = GetComponent<CharacterController>();
    }


    public void ReactToHit()
    {
        FallingDead();
    }


    void FallingDead()
    {
        _ai = GetComponent<WanderingAI>();
        if (_ai != null)
        {
            _ai.IsAlive = false;
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