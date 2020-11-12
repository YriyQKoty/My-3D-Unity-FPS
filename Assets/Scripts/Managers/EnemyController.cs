using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    private GameObject _enemy;
    private Vector3 _initialPosition;

    void Start()
    {
        _initialPosition = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemy == null)
        {
            CreateEnemy();
        }
    }

    void CreateEnemy()
    {
        _enemy = Instantiate(_enemyPrefab) as GameObject;
        _enemy.transform.position = _initialPosition;
        _enemy.transform.Rotate(0, Random.Range(0, 360), 0);
    }
}