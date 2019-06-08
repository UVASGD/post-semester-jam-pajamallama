using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingObject : MonoBehaviour
{
    [SerializeField]
    private Renderer appearingRenderer;

    [SerializeField]
    private float distanceToAppear = 1.0f;

    [SerializeField]
    private GameObject target;

    // Update is called once per frame
    void Update()
    {
        if (null != target)
        {
            float distance = (target.transform.position - gameObject.transform.position).magnitude;

            if (distance < distanceToAppear)
            {
                appearingRenderer.enabled = true;
            } else
            {
                appearingRenderer.enabled = false;
            }
        }
    }
}
