using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    DefaultInputActions defaultInputActions;

    Rigidbody rb;

    [SerializeField]
    private float moveSpeed;

    public bool stopPlayer = false;
    [SerializeField] private bool IsWalking = false;

    private Vector2 move; // tuþlara basýnca kaydolan
    private Vector3 moveForce; // anlýk
    private Vector3 throwDirection;


    private void Awake()
    {
        defaultInputActions = new DefaultInputActions();
        rb = GetComponent<Rigidbody>();

        defaultInputActions.Player.Move.started += Move;
        defaultInputActions.Player.Move.performed += Move;
        defaultInputActions.Player.Move.canceled += Move;
    }

    private void Move(InputAction.CallbackContext context)
    {
        //Debug.Log(context.ReadValue<Vector2>());
        move = context.ReadValue<Vector2>();

        moveForce.x = move.x;
        moveForce.z = move.y;

        stopPlayer= move.x != 0 || move.y  != 0;
    }
    private void FixedUpdate()
    {
        if (stopPlayer)
        {
            rb.MovePosition(transform.position + moveForce.normalized * moveSpeed * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        defaultInputActions.Player.Enable();
    }

    private void OnDisable()
    {
        defaultInputActions.Player.Disable();
    }

    public int GetPlayerStealthProfile()
    {
        if (IsWalking)
        {
            return 0;
        }else
        {
            return 1;
        }
    }
}
