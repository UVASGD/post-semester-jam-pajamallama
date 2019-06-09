using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class store_manager : MonoBehaviour
{
    //wyatt is holding me at gunpoint and this is the only way i can speak without him seeing

    public static store_manager instance;

    private void Awake()
    {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Item find_item_with_tag(Tag tag) {
        Slot[] slots = FindObjectsOfType<Slot>();
        foreach(Slot slot in slots) {
            if(!slot.isBackRoom && slot.item && slot.item.gameObject.GetComponent<TagHandler>().HasTag(tag)) {
                return slot.item;
            }
        }

        return null;
    } 
}
