using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSwitch : MonoBehaviour, iInteractable
{
    protected bool isOn = false;

    public void Interact()
    {
        if (isOn)
        {
            SwitchOff();
        }
        else
        {
            SwitchOn();
        }
    }

    public virtual void SwitchOn()
    {
        isOn = true;
        Debug.Log("Switch Has Been Turned On");
    }

    public virtual void SwitchOff()
    {
        isOn = false;
        Debug.Log("Switch Has Been Turned Off");
    }
}
