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

    public Behavior behavior;

    float turn_speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Interactable>().InteractEvent += TurnTo;
        anim = GetComponentInChildren<Animator>();
        agent = GetComponentInChildren<NavMeshAgent>();
        hc = GetComponentInChildren<HeadController>();
        rb = GetComponentInChildren<Rigidbody>();
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
        StopAllCoroutines();
        if (hc) hc.BeginLookAt(t.gameObject);
        print(t);
        StartCoroutine(CoTurnTo(t));
    }

    IEnumerator CoTurnTo(Transform t)
    {
        Vector3 target = (t.position - transform.position).normalized;
        while ((target.y - transform.forward.y) > 1f)
        {
            target = (t.position - transform.position).normalized;
            Quaternion current_forward = Quaternion.LookRotation(rb.transform.forward);
            Vector3 desiredForward = Vector3.RotateTowards(rb.transform.forward, target, turn_speed * Time.deltaTime, 0f);
            Quaternion rot = Quaternion.LookRotation(desiredForward);
            rot = new Quaternion(current_forward.x, rot.y, current_forward.z, current_forward.w);
            rb.transform.rotation = rot;
            yield return null;
        }
        if (hc) hc.StopLookAt();
    }
}
