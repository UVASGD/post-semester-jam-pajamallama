using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagCollider : MonoBehaviour
{
    public InteractDel TagEvent;
    public Tag item_tag;
    public float interact_distance;

    private void Start()
    {
        interact_distance = GetComponent<CapsuleCollider>().radius;

    }

    public void OnTriggerEnter(Collider other)
    {
        TagHandler th = other.GetComponent<TagHandler>();
        if (th)
        {
            if (th.HasTag(item_tag))
            {
                TagEvent?.Invoke(other.transform);
            }
        }
    }
}
