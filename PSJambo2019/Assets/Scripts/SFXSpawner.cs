using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSpawner : MonoBehaviour
{

    public static SFXSpawner instance;

    #region effects
    //Add sound effect vars here


    #endregion

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    public void SpawnEffect(GameObject obj, Vector3 location) {
        Instantiate(obj, location, Quaternion.identity, null);
    }
}
