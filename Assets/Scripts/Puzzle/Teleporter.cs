using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private Transform dropOff;



    // Start is called before the first frame update
    void Start()
    {
        dropOff = transform.GetChild(0);
    }

    public Transform RendernDropOffLocation()
    {
        return dropOff;
    }

}
