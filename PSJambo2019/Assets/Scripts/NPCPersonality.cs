using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Personality {
    Generic,
    Feminine,
    Manager,
    Chad,
    OldMan,
    Glitch,
    Drunk,
}


[RequireComponent(typeof(Animator))]
public class NPCPersonality : MonoBehaviour {

    [Tooltip("Style of animations to be played for this NPC")]
    public Personality personality;
    Animator anim;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        anim.SetFloat("Personality", (float)personality);
    }
}
