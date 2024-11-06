using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class MainMovementPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 750f;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody _rb;
    private NavMeshAgent _navMeshAgent;
    private Vector3 _movementInput;
    private Transform _mainCameraTransform;
    private Camera _mainCamera;
    private bool _isMoving;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        if (Camera.main == null)
        {
            throw new Exception("Main camera not found");
        }
        _mainCameraTransform = Camera.main.transform;
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        KeyboardMovement();
        MouseMovement();
        
        RotateMovementToCamera();
        RotateLookForward();
    }
    
    private void KeyboardMovement()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        
        _isMoving = moveHorizontal != 0 || moveVertical != 0;
        if (_isMoving)
        {
            _navMeshAgent.ResetPath();
        }
        
        _movementInput = new Vector3(moveHorizontal, 0f, moveVertical);
    }
    
    private void MouseMovement()
    {
        if (Input.GetMouseButton(1))
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, groundLayer))
            {
                var targetPosition = hit.point;
                _navMeshAgent.SetDestination(targetPosition);
            }
        }
    }

    private void FixedUpdate()
    {
//        _rb.angularVelocity = _movementInput * speed;
        _rb.linearVelocity = _movementInput * speed;
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

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
 
}