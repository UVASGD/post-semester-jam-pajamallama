using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorControl : MonoBehaviour {

    [Tooltip("What objects are allowed to open the door")]
    public string TagMask = "Player";

    private List<GameObject> people;
    private Animator anim;

    // Start is called before the first frame update
    void Start() {
        people = new List<GameObject>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        anim.SetBool("Active", people.Count > 0);
    }

    private void OnTriggerEnter(Collider other) {
        // Open the door if requirements met
        if (!people.Contains(other.gameObject) && other.CompareTag(TagMask))
            people.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other) {
        if (people.Contains(other.gameObject))
            people.Remove(other.gameObject);
    }


}
