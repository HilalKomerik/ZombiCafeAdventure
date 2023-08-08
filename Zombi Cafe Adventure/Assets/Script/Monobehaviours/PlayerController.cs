using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    DefaultInputActions defaultInputActions;

    Rigidbody rb;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float throwForce; // fýrlatma kuvveti

    [SerializeField] private AmmoInventory characterAmmoInventory;
    [SerializeField] private Dictionary<string, int> characterAmmoDict;
    [SerializeField] private GameObject placeHolderPizzaStall; // pizza tezgahý

    public bool stopPlayer = false;
    [SerializeField] private bool IsWalking = false;
    private bool isInteractable;


    private Vector2 move; // tuþlara basýnca kaydolan
    private Vector3 moveForce; // anlýk
    private Vector3 throwDirection;


    private void Awake()
    {
        defaultInputActions = new DefaultInputActions();
        rb = GetComponent<Rigidbody>();

        characterAmmoInventory = GetComponent<AmmoInventory>();
        characterAmmoDict = characterAmmoInventory.GetAmmoDict();

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

    private void OnCollisionEnter(Collision collision)
    {
       // if (collision.transform != placeHolderPizzaStall.transform);
    }

    private void OnInteract()
    {
        //if (!isInteractable) return;
        //var go = Object.Instantiate(placeHolderPizzaStall, transform);
        //if (go != null) return;
        Debug.Log(characterAmmoInventory.AddAmmoToDict("pizza", 1));
        //go.transform.position = transform.position;
        //go.SetActive(false);
        Debug.Log("Triggering Interact");
    }
    void OnThrow()
    {
        //var go = pizzasToThrow[0];
        //go.SetActive(true);
        //var goRb = go.GetComponent<Rigidbody>();
        //goRb.velocity = Vector3.forward * throwForce;
        isInteractable = false;
    }
    private void FixedUpdate()
    {
        if (stopPlayer)
        {
            rb.MovePosition(transform.position + moveForce.normalized * moveSpeed * Time.deltaTime);
        }
    }

    //private void FixedUpdate()
    //{
    //    //if (isInteractable)
    //    //{
    //    //    foreach (var pizza in pizzasToThrow)
    //    //    {
    //    //        pizza.transform.position = transform.position;
    //    //    }
    //    //}

    //}


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
