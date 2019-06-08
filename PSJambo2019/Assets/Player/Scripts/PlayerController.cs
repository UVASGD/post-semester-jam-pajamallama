using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Interactor interactor;
    // Start is called before the first frame update
    void Start()
    {
        interactor = GetComponentInChildren<Interactor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            interactor.Interact();
        }
    }
}
