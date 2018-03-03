using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _rotationX = 0;
    private float _rotationY = 0;
    private float _delta = 0;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update ()
    {
        if (axes == RotationAxes.MouseX) // это поворот в горизонтальной плоскости
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY) // это поворот в вертикальной плоскости
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            _rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
        else // это комбинированный поворот Сюда поместим код для комбинированного вращения.
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            _delta = Input.GetAxis("Mouse X") * sensitivityHor;
            _rotationY = transform.localEulerAngles.y + _delta;
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
    }
}
