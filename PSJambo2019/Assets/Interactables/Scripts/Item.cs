using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    Rigidbody rb;
    Collider c;

    public override void Start()
    {
        rb.isKinematic = true;
        c.enabled = false;
    }
    public override void Interact(Transform t, bool active = false)
    {
        transform.parent = t;
        transform.position = t.position;
        rb.isKinematic = true;
        c.enabled = false;
        gameObject.SetActive(active);
    }

    public void Drop()
    {
        rb.isKinematic = false;
        c.enabled = true;
        gameObject.SetActive(true);
    }
}
