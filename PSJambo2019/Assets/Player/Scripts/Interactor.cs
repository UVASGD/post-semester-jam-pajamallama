using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public float interact_distance = 1;
    LayerMask lm;

    public Item p_item;

    public void Start()
    {
        lm = ~LayerMask.GetMask("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * interact_distance);
    }

    public void Interact()
    {
        QueryTriggerInteraction qti = (p_item) ? QueryTriggerInteraction.Collide : QueryTriggerInteraction.Ignore;
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interact_distance, lm, qti))
        {
            if (hit.transform.GetComponent<Slot>())
            {
                Slot slot = hit.transform.GetComponent<Slot>();
                p_item = slot.Swap(p_item);
                if (p_item) p_item.Collect(transform);
                return;
            }
            else if (hit.transform.GetComponent<Item>())
            {
                Item item = hit.transform.GetComponent<Item>();
                if (p_item) p_item.Drop();
                p_item = item.Collect(transform);
                return;
            }
            else if (hit.transform.GetComponent<Interactable>())
            {
                hit.transform.GetComponent<Interactable>().Interact(transform);
                return;
            }
        }

        if (p_item) p_item = p_item.Drop();
    }
}
