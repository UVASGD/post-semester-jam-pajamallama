using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ItemType {
    Default,
    SpiderEyes,
    Car,
    ToyCar,
    ToastChee,
}
public class store_manager : MonoBehaviour {
    //wyatt is holding me at gunpoint and this is the only way i can speak without him seeing

    public static store_manager instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public Item find_item_with_tag(Tag tag) {
        Slot[] slots = FindObjectsOfType<Slot>();
        foreach (Slot slot in slots) {
            if (!slot.isBackRoom && slot.item && slot.item.gameObject.GetComponent<TagHandler>().HasTag(tag)) {
                return slot.item;
            }
        }

        return null;
    }

    public Item find_item_with_name(string name) {
        Slot[] slots = FindObjectsOfType<Slot>();
        foreach (Slot slot in slots) {
            if (!slot.isBackRoom && slot.item && slot.item.gameObject.GetComponent<Item>().name == name) {
                return slot.item;
            }
        }

        return null;
    }

    public Item findItemOfType(ItemType type) {
        Slot[] slots = FindObjectsOfType<Slot>();
        foreach (Slot slot in slots) {
            if (!slot.isBackRoom && slot.item && slot.item.gameObject.GetComponent<Item>().type == type) {
                return slot.item;
            }
        }
        return null;
    }

    public int numberOfItem(ItemType type) {
        int num = 0;
        Slot[] slots = FindObjectsOfType<Slot>();
        foreach (Slot slot in slots) {
            if (!slot.isBackRoom && slot.item && slot.item.gameObject.GetComponent<Item>().type == type) {
                num++;
            }
        }
        return num;
    }

    public bool itemOnShelves(ItemType type) {
        Slot[] slots = FindObjectsOfType<Slot>();
        foreach (Slot slot in slots) {
            if (!slot.isBackRoom && slot.item && slot.item.gameObject.GetComponent<Item>().type == type) {
                return true;
            }
        }
        return false;
    }

    public Vector3 RandomNavmeshLocation(float radius) {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
