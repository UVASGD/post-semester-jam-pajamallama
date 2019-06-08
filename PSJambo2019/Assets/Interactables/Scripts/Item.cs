using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Rigidbody rb;
    Collider c;

    Transform holder;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb) rb.isKinematic = true;
        c = GetComponent<Collider>();
        if (c) c.enabled = false;
        holder = transform.parent;
        transform.parent = null;
    }

    public virtual void Update()
    {
        if (holder && gameObject.activeSelf)
        {
            transform.position = holder.position;
            transform.rotation = holder.rotation;
        }
    }

    public virtual Item Collect(Transform t, bool active = false)
    {
        if (rb) rb.isKinematic = true;
        if (c) c.enabled = false;
        holder = t;
        gameObject.SetActive(active);
        return this;
    }

    public virtual Item Drop(bool ret = false)
    {
        if (rb) rb.isKinematic = false;
        if (c) c.enabled = true;
        gameObject.SetActive(true);
        transform.position = holder.position;
        transform.rotation = holder.rotation;
        if (holder) transform.position += Vector3.Scale(holder.forward, transform.lossyScale);
        holder = null;
        return (ret) ? this : null;
    }
    
}
