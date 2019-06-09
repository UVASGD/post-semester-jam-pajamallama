using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public Item item;
    public bool isBackRoom = false;
    Collider c;

    public virtual void Awake()
    {
        item = GetComponentInChildren<Item>();
        c = GetComponent<Collider>();
        if (!item && c) c.isTrigger = true;
    }

    public Item Swap(Item i)
    {
        Item drop = item;
        item = (i) ? i.Collect(transform, true) : null;
        c.isTrigger = (!item);
        return (drop) ? drop.Drop(true) : null;
    }
}
