using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private enum RotationAxes
    {
        MouseXY = 0,
        MouseX = 1,
        MouseY = 2,
    }
    
    [SerializeField] float horizontalSpeed = 2.0f;
    [SerializeField] float verticalSpeed = 2.0f;

    [SerializeField] float minVert = -45.0f;
    [SerializeField] float maxVert = 45.0f;

    private float _rotationAroundX = 0;

    [SerializeField] private RotationAxes axes = RotationAxes.MouseXY;

    void Start()
    {
        
        var body = GetComponent<Rigidbody>();
        body.freezeRotation = body != null;
    }
    
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0,Input.GetAxis("Mouse X")*horizontalSpeed,0, Space.Self);
        }
        
        else if (axes == RotationAxes.MouseY)
        {
            _rotationAroundX -= Input.GetAxis("Mouse Y") * verticalSpeed;
            _rotationAroundX = Mathf.Clamp(_rotationAroundX, minVert, maxVert);

            float _rotationAroundY = transform.localEulerAngles.y;
            
            transform.localEulerAngles = new Vector3(_rotationAroundX, _rotationAroundY, 0);
        }
        else
        {
            _rotationAroundX -= Input.GetAxis("Mouse Y") * verticalSpeed;
            _rotationAroundX = Mathf.Clamp(_rotationAroundX, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * horizontalSpeed;
            float _rotationAroundY = transform.localEulerAngles.y + delta;
            
            transform.localEulerAngles = new Vector3(_rotationAroundX, _rotationAroundY, 0);

        }
    }
}
