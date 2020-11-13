using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float _speed;

    private int _damage = 1;
  

    void Update()
    {
        transform.Translate(0,0,_speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerCharacter>();
        var target = other.GetComponent<ReactiveTarget>();
        if (player != null)
        {
            player.Hurt(_damage);
        }

        if (target != null)
        {
            target.ReactToHit(_damage);
        }
        
        
        Destroy(this.gameObject);
    }
}
