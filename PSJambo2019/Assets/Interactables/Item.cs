using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{

    public override void Interact(Transform t)
    {
        print("gaga");
        transform.parent = t;
        transform.position = t.position;
        gameObject.SetActive(false);
    }
}
