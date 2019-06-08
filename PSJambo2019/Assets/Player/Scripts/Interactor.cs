using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public float interact_distance = 1;
    LayerMask lm;

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
            print("a");
            print(hit.transform);
            i = hit.transform.GetComponent<Interactable>();
            if (i)
            {
                print("Gotem");
                i.Interact(transform);
            }
        }
    }
}
