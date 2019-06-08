using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public float interact_distance = 1;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * interact_distance);
    }

    public void Interact(Interactable i)
    {
        if (i)
        {
            i.Interact();
        }
        else if (Physics.Raycast(transform.position, transform.forward * interact_distance, out RaycastHit hit))
        {
            i = hit.transform.GetComponent<Interactable>();
            if (i)
            {
                i.Interact();
            }
        }
    }
}
