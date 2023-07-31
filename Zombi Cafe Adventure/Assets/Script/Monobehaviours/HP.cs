using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class HP : MonoBehaviour
{
    [SerializeField]
    private int totalHP;
    [SerializeField]
    private int currentHP;
    void Start()
    {
        
    }

    private void OnEnable()
    {
        currentHP = totalHP;
    }

    public void ReduceHP(int damageAmount)
    {
        currentHP -= damageAmount;

        if (currentHP < 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        // Detemine wat happens after ee die. #NoBiggie
    }
}
