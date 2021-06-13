using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseButton : MonoBehaviour, iInteractable
{
    protected bool wasPressed = false;

    public void Interact()
    {
        if (!wasPressed)
        {
            ButtonInteract();
        }
    }

    public virtual void ButtonInteract()
    {
        Debug.Log("Button Has Been Pressed");
    }
}

