using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AroundTheBend;

public delegate void Behavior();

public class Character : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    HeadController hc;
    Rigidbody rb;
    Rotator rotator;

    public Behavior behavior;

    float turn_speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rotator = GetComponentInChildren<Rotator>();
        anim = GetComponentInChildren<Animator>();
        agent = GetComponentInChildren<NavMeshAgent>();
        hc = GetComponentInChildren<HeadController>();
        rb = GetComponentInChildren<Rigidbody>();
        GetComponentInChildren<Interactable>().InteractEvent += TurnTo;
    }

    // Update is called once per frame
    void Update()
    {
        behavior?.Invoke();
    }

    void Stop()
    {
        agent.isStopped = true;
        behavior = null;
    }

    void TurnTo(Transform t)
    {
        hc.BeginLookAt(t.gameObject);
        rotator.TurnTo(t.gameObject, lockY:false);
    }
}
