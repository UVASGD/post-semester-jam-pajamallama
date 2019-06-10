using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AroundTheBend;

public delegate bool Behavior();

public class Character : MonoBehaviour, IPausable
{
    protected Animator anim;
    protected NavMeshAgent agent;
    protected HeadController hc;
    protected Rigidbody rb;
    protected Rotator rotator;

    public Transform hand;

    float turn_speed = 5f;

    int forward_hash;
    float speed_factor = 0.1f;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rotator = GetComponentInChildren<Rotator>();
        anim = GetComponentInChildren<Animator>();
        agent = GetComponentInChildren<NavMeshAgent>();
        hc = GetComponentInChildren<HeadController>();
        rb = GetComponentInChildren<Rigidbody>();
        GetComponentInChildren<Interactable>().InteractEvent += TurnTo;
        if (!hand) hand = transform;
        forward_hash = Animator.StringToHash("Forward");
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat(forward_hash, agent.velocity.magnitude * speed_factor);

    }

    protected void Stop()
    {
        agent.isStopped = true;
    }

    protected void TurnTo(Transform t)
    {
        hc.BeginLookAt(t.gameObject);
        rotator.TurnTo(t.gameObject, lockY:false);
    }
}