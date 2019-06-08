using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : MonoBehaviour
{

    public static FXSpawner instance;

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
