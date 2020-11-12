using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] private float _reloadDelay = 2.0f;
    [SerializeField] private GameObject _bulletPrefab;

    private GameObject _bullet;

    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 4;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    void Update()
    {
        RayCast();
    }

    void RayCast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            var ray = _camera.ScreenPointToRay(point);

            if (Physics.Raycast(ray))
            {
                _bullet = Instantiate(_bulletPrefab) as GameObject;
                _bullet.transform.position = transform.TransformPoint(Vector3.forward * 0.1f);
                _bullet.transform.rotation = transform.rotation;

                StartCoroutine(Reload());
            }
        }
    }

    private IEnumerator Reload()
    {
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(_reloadDelay);
    }
}