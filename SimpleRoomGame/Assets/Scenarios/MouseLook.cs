using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Control Script/MouseLook")]
public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        mouseXAndY =0,
        mouseX = 1,
        mouseY =2
    }
    public RotationAxes axes = RotationAxes.mouseXAndY;
    public float sensivityHor = 9.0f;
    public float sensivityVert = 9.0f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    private float _rotationX = 0;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if(body != null)
        {
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(axes == RotationAxes.mouseX)
        {
            transform.Rotate(0,Input.GetAxis("Mouse X")* sensivityHor, 0);
        }
        else if(axes == RotationAxes.mouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            //vertical
            _rotationX -= Input.GetAxis("Mouse Y") * sensivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            //horizontal
            float delta = Input.GetAxis("Mouse X") * sensivityHor;
            float rotationY = transform.localEulerAngles.y+delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
