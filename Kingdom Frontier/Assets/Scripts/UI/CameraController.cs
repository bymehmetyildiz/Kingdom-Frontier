using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CameraController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private float moveSpeed;
    private Rigidbody rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (!UIPanelManager.Instance.isPanelActive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }
        else
        {
            horizontalInput = 0.0f;
            verticalInput = 0.0f;
        }

        
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        Vector3 rotatedMoveDirection = Quaternion.Euler(0, 90.0f, 0) * moveDirection;

        rb.velocity = new Vector3(rotatedMoveDirection.x * moveSpeed, 0, rotatedMoveDirection.z * moveSpeed);
    }
}
