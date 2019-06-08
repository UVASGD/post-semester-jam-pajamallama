using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pauser : MonoBehaviour
{
    public static Pauser instance;
    HashSet<IPausable> pausables = new HashSet<IPausable>();

    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void Pause()
    {
        pausables = new HashSet<IPausable>(FindObjectsOfType<MonoBehaviour>().OfType<IPausable>());
    }
}
