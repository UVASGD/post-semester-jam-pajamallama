using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    [SerializeField]
    private Animator animatorController;

    [SerializeField]
    private TextMesh interactText;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float interactDistance = 1.0f;

    [SerializeField]
    [Header("Interaction String")]
    private string interactStringFormat = "Press the interact button to {0}.";

    [SerializeField]
    private string interactStringClose = "close";

    [SerializeField]
    private string interactStringOpen = "open";

    private const string OPENED_NAME = "Opened";

    private const string CLOSED_NAME = "Closed";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo currentState = animatorController.GetCurrentAnimatorStateInfo(0);

        bool opened = currentState.IsName(OPENED_NAME);

        bool closed = currentState.IsName(CLOSED_NAME);

        bool interact = Input.GetButtonDown("Interact");
    
        if (opened)
        {
            if (IsWithinInteractRange())
            {
                SetInteractText(string.Format(interactStringFormat, interactStringClose));
                if (interact)
                {
                    Interact();
                }
            } else
            {
                DeactivateInteractText();
            }
        } else if (closed)
        {
            if (IsWithinInteractRange())
            {
                SetInteractText(string.Format(interactStringFormat, interactStringOpen));
                if (interact)
                {
                    Interact();
                }
            } else
            {
                DeactivateInteractText();
            }
        } else
        {
            DeactivateInteractText();
        }
    }

    bool IsWithinInteractRange()
    {
        Vector3 doorPos = gameObject.transform.position;

        Vector3 playerPos = player.transform.position;

        return (doorPos - playerPos).magnitude < interactDistance;
    }

    void Interact()
    {
        animatorController.SetTrigger("Interact");
    }

    void SetInteractText(string text)
    {
        interactText.text = text;
        if (!interactText.gameObject.activeInHierarchy)
        {
            interactText.gameObject.SetActive(true);
        }
    }

    void DeactivateInteractText()
    {
        if (interactText.gameObject.activeInHierarchy)
        {
            interactText.gameObject.SetActive(false);
        }
    }
}
