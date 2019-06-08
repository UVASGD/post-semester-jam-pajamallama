using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactor : MonoBehaviour
{
    float interact_distance = 10;
    LayerMask lm;

    public Item p_item;

    public TextMeshProUGUI interactDisplay;

    public void Start()
    {
        lm = ~LayerMask.GetMask("Player");
        CloseDisplay();
    }

    public void Update()
    {
        QueryTriggerInteraction qti = (p_item) ? QueryTriggerInteraction.Collide : QueryTriggerInteraction.Ignore;
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interact_distance, lm, qti))
        {
            if (hit.transform.GetComponent<Slot>())
            {
                Slot slot = hit.transform.GetComponent<Slot>();
                if(slot.item) {
                    Display("Press \"F\" to pick up");
                } else if(p_item) {
                    Display("Press \"F\" to place item");
                }
            }
            else if (hit.transform.GetComponent<Item>())
            {
                Display("Press \"F\" to pick up");
            }
            else if (hit.transform.GetComponent<Interactable>())
            {
                Display("Press \"F\" to interact");
            }
        } else {
            CloseDisplay();
        }
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

    public void Display(string message) {
        interactDisplay.gameObject.SetActive(true);
        interactDisplay.text = message;
    }

    public void CloseDisplay() {
        interactDisplay.gameObject.SetActive(false);
    }
}
