using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Rigidbody rb;
    Collider c;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb) rb.isKinematic = true;
        c = GetComponent<Collider>();
        if (c) c.enabled = false;
    }

    public virtual Item Collect(Transform t, bool active = false)
    {
        if (rb) rb.isKinematic = true;
        if (c) c.enabled = false;
        gameObject.SetActive(active);
        transform.parent = t;
        transform.position = t.position;
        transform.rotation = t.rotation;
        return this;
    }

    public virtual Item Drop(bool ret = false)
    {
        if (rb) rb.isKinematic = false;
        if (c) c.enabled = true;
        gameObject.SetActive(true);
        if (transform.parent) transform.position += transform.parent.forward;
        transform.parent = null;
        return (ret) ? this : null;
    }
    
}
