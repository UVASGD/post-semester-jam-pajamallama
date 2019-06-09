﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ConvoHandler : MonoBehaviour {

    public Flowchart flowchart;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public bool HasItem(ItemType _item) {
        return Random.value > 0.5f;
    }

    public void Continue() {
        Debug.Log("CONTINUE");
    }

    public void Get() {
        Debug.Log("GET");
    }

    public void Give() {
        Debug.Log("GIVE");
    }

    public void Leave() {
        Debug.Log("LEAVE");
        flowchart.ExecuteBlock("s-RESET-s");
    }

    public void Finish() {
        Debug.Log("FINISH");
    }

    public void Talk() {
        flowchart.ExecuteBlock("s-TALK");
    }
}