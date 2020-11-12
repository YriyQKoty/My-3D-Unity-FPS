using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _obstacleRange;
    [SerializeField] private GameObject _bulletPrefab;
    private GameObject _bullet;
    private Ray _ray;

    public bool IsAlive { get; set; }

    void Start()
    {
        IsAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        Wander();
    }

    void Wander()
    {
        if (IsAlive)
        {
            Move();
        }

        Observe();
    }

    void Move()
    {
        transform.Translate(0, 0, _speed * Time.deltaTime);
    }

    void Observe()
    {
        _ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(_ray, 0.25f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>())
            {
                _bullet = Instantiate(_bulletPrefab) as GameObject;
                _bullet.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                _bullet.transform.rotation = transform.rotation;
            }

            else if (hit.distance < _obstacleRange)
            {
                var angle = Random.Range(-120, 120);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}