using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void InteractDel(Transform t);

public class Interactable : MonoBehaviour
{
    public InteractDel InteractEvent;

    public virtual void Interact(Transform t)
    {
        InteractEvent?.Invoke(t);
    }
}
