using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public float interact_distance = 1;
    LayerMask lm;

    public Item pocket_item;

    public void Start()
    {
        lm = ~LayerMask.GetMask("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * interact_distance);
    }

    public void Interact(Interactable i = null)
    {
        if (i)
        {
            i.Interact(transform);
        }
        else if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interact_distance, lm))
        {
            i = hit.transform.GetComponent<Interactable>();
            if (i)
            {
                i.Interact(transform);
            }
        }
    }
}
