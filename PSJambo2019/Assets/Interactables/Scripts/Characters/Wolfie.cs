using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolfie : Character
{
    protected Vector3 target;
    public Tag item_tag = Tag.Default;
    protected TagCollider tc;

    protected override void Start()
    {
        base.Start();
        tc = GetComponentInChildren<TagCollider>();
        tc.item_tag = item_tag;
        tc.TagEvent += FoundItem;
        FindItem();
    }

    void FindItem()
    {
        Item i = StoreManager.instance.find_item_with_tag(item_tag);
        if (i)
        {
            target = i.transform.position;

            return;
        }
        Wander();
    }

    void Wander()
    {
        target = StoreManager.instance.RandomNavmeshLocation(StoreManager.store_radius, rb.transform.position);

        behavior = GoToDestination;
    }

    void FoundItem(Transform t)
    {
        Stop();
        TurnTo(t);
        if (t.GetComponent<Slot>())
        {
            t.GetComponent<Slot>().Swap(null).Collect(hand, true);
        }
        else if (t.GetComponent<Item>())
        {
            t.GetComponent<Item>().Collect(hand, true);
        }

        target = StoreManager.instance.GetWaitingLocation();
        behavior = GoToDestination;
    }

    void GoToDestination()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Stop();
        }
    }
}
