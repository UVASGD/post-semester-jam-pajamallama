using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolfie : Character
{
    protected Vector3 target;
    public Tag item_tag = Tag.Default;

    protected override void Start()
    {
        base.Start();
        TagCollider tc = GetComponentInChildren<TagCollider>();
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
            agent.SetDestination(target);
            return;
        }
        Wander();
    }

    void Wander()
    {
        target = StoreManager.instance.RandomNavmeshLocation(StoreManager.store_radius, rb.transform.position);
        agent.SetDestination(target);
    }

    void FoundItem(Transform t)
    {
        Stop();
        TurnTo(t);
        t.GetComponent<Item>().Collect(hand, true);
        timer = 5f;
        target = StoreManager.instance.GetWaitingLocation();
        behavior = GoToCounter;
    }

    void GoToCounter()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Stop();
        }
    }
}
