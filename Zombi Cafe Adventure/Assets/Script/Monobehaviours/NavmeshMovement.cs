using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;


[RequireComponent(typeof(NavMeshAgent))]   
public class NavmeshMovement : MonoBehaviour
{
    [SerializeField]
    private float agentSpeed;

    private NavMeshAgent agent;

    [SerializeField]
    private GameObject selectedTarget;

    public UnityEvent<bool> inAttackRange;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();   
        agent.speed = agentSpeed;
    }

    private void Start()
    {
        selectedTarget = SelectTargetPlayer();
    }

    private GameObject SelectTargetPlayer()
    {
        GameObject[] target;
        target = GameObject.FindGameObjectsWithTag("Player");
        return target[Random.Range(0, target.Length)];
    }

    private void Update()
    {
        agent.SetDestination(selectedTarget.transform.position);
        if (agent.destination != null) 
        {
            if(agent.remainingDistance <= 0.1f)
            {
                inAttackRange.Invoke(true);
            }
        }
    }







}
