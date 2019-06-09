using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void InputEvent();

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    public InputEvent Pause;

    Interactor interactor;
    // Start is called before the first frame update
    void Start()
    {
        interactor = GetComponentInChildren<Interactor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            interactor.Interact();
        }

        if (Input.GetButtonDown("Pause"))
            Pause.Invoke();
    }
}
