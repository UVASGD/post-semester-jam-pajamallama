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
public class StoreManager : MonoBehaviour {
    //wyatt is holding me at gunpoint and this is the only way i can speak without him seeing

    public static StoreManager instance;

    public static float store_radius = 50f;


    Vector3 counterLocation;

    public BoxCollider waitingSpace;


    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
            return;
        }
        try { store_radius = GameObject.FindGameObjectWithTag("GasStation").
                GetComponent<Renderer>().bounds.size.magnitude; }
        catch (System.Exception e) { }
    }

    private void Start() {
        try
        {
            counterLocation = GameObject.FindGameObjectWithTag("Counter").transform.position;
        }
        catch (System.Exception e) { }
        try
        {
            waitingSpace = GameObject.FindGameObjectWithTag("WaitingArea").GetComponent<BoxCollider>();
        }
        catch (System.Exception e) { }
    }

    public Vector3 GetCounterLocation() {
        return counterLocation;
    }

    public Vector3 GetWaitingLocation() {
        if (!waitingSpace)
            return Vector3.zero;
        Vector3 randomSpot = new Vector3(
            Random.Range(waitingSpace.bounds.min.x, waitingSpace.bounds.max.x),
            waitingSpace.bounds.min.y,
            Random.Range(waitingSpace.bounds.min.z, waitingSpace.bounds.max.z));
        NavMeshHit hit;
        Vector3 finalPosition = randomSpot;
        if (NavMesh.SamplePosition(randomSpot, out hit, waitingSpace.bounds.extents.magnitude, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    public Item find_item_with_tag(Tag tag) {
        Slot[] slots = FindObjectsOfType<Slot>();
        foreach (Slot slot in slots) {
            if (!slot.isBackRoom && slot.item && slot.item.GetComponent<TagHandler>().HasTag(tag)) {
                return slot.item;
            }
        }

        return null;
    }

    public Item find_item_with_name(string name) {
        Slot[] slots = FindObjectsOfType<Slot>();
        foreach (Slot slot in slots) {
            if (!slot.isBackRoom && slot.item && slot.item.GetComponent<Item>().name == name) {
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

    public Vector3 RandomNavmeshLocation(float radius, Vector3 position) {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += position;
        NavMeshHit hit;
        Vector3 finalPosition = position;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
