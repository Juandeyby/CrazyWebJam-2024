using System;
using UnityEngine;

public class MainMovementPlayer : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 750f;
    private Rigidbody _rb;
    private Vector3 _movementInput;
    private Transform _mainCameraTransform;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        if (Camera.main == null)
        {
            throw new Exception("Main camera not found");
        }
        _mainCameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        
        _movementInput = new Vector3(moveHorizontal, 0f, moveVertical);

        RotateMovementToCamera();
        RotateLookForward();
    }

    private void FixedUpdate()
    {
//        _rb.angularVelocity = _movementInput * speed;
        _rb.linearVelocity = _movementInput * _speed;
    }
    
    private void RotateMovementToCamera()
    {
        var cameraRotationY = _mainCameraTransform.eulerAngles.y;
        var rotation = Quaternion.Euler(0, cameraRotationY, 0);
        _movementInput = rotation * _movementInput;
    }

    private void RotateLookForward()
    {
        var targetDirection = _movementInput.normalized;

        if (targetDirection != Vector3.zero)
        {
            var targetRotation = Quaternion.LookRotation(targetDirection);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }
 
}