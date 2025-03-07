using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] Transform followTarget;

    [SerializeField] float distance = 5;
    [SerializeField] float height = 2;
    [SerializeField] float shoulder = 2;
    [SerializeField] float MinVertAngle = -45;
    [SerializeField] float MaxVertAngle = 45;
    [SerializeField] float MouseSensitivity = 2;
    [SerializeField] Vector2 framingOffset;

    float rotationX;
    float rotationY;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        rotationY += Input.GetAxis("Mouse X")*MouseSensitivity;

        rotationX = Mathf.Clamp(rotationX,MinVertAngle,MaxVertAngle);

        rotationX += Input.GetAxis("Mouse Y") * MouseSensitivity;

        var targetRotation = Quaternion.Euler(-rotationX, rotationY, 0);

        var FocusPosition = followTarget.position + new Vector3 (framingOffset.x, framingOffset.y);

        transform.position = FocusPosition- targetRotation* new Vector3(shoulder, height, distance);

        transform.rotation = targetRotation;

    }


    public Quaternion PlanarRotation => Quaternion.Euler(0, rotationY, 0);



}
