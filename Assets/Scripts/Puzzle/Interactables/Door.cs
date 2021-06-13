using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : BaseSwitch
{
    public GameObject doorObject;

    public override void SwitchOff()
    {
        doorObject.SetActive(true);
        base.SwitchOff();
        
    }

    public override void SwitchOn()
    {
        doorObject.SetActive(false);
        base.SwitchOn();
    }

}
