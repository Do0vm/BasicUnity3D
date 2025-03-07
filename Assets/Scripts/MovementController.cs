using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 500f;

    Quaternion targetRotation;
    CameraController cameraController;
    Animator animator;
    CharacterController characterController;

    private void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");


        float moveAmount = Mathf.Clamp01(Mathf.Abs(h) + Mathf.Abs(v));

        var moveInput = (new Vector3 (h, 0, v)).normalized;


        var moveDir = cameraController.PlanarRotation* moveInput;



        if (moveAmount > 0)
        {
            characterController.Move(moveDir * moveSpeed * Time.deltaTime);

            
            targetRotation = Quaternion.LookRotation(moveDir);
        }

      

        transform.rotation = Quaternion.RotateTowards(transform.rotation, 
            targetRotation, rotationSpeed * Time.deltaTime);



        animator.SetFloat("MoveAmount", moveAmount,0.3f, Time.deltaTime);

    }



}
