using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float throwForce;

    public bool stopPlayer = false;

    private Vector2 move;
    private Vector3 moveForce;
    private Vector3 throwDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OmMove(InputValue value)
    {
        move = value.Get<Vector2>();
        moveForce =new Vector3(-move.x,0.0f,-move.y);
    }

    void OnToggle()
    {
        // TODO: Add Food Projectile toggle code
    }

    void OnThrow()
    {

    }

    private void FixedUpdate()
    {
        rb.velocity = moveForce * moveSpeed;
        if (!stopPlayer) return;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

}
