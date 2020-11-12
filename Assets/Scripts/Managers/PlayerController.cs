using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    private GameObject _player;
    private Vector3 _initialPosition;

    void Start()
    {
        _initialPosition = this.gameObject.transform.position;

        CreatePlayer();
    }


    void CreatePlayer()
    {
        _player = Instantiate(_playerPrefab) as GameObject;
        _player.transform.position = _initialPosition;
        _player.transform.Rotate(0, Random.Range(0, 360), 0);
    }
}