using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTrigger : MonoBehaviour
{

    public GameObject[] outputObjects;
    private iInteractable[] outputs;

    private bool buttonUsed = false;
    private bool isActive = false;

    public enum InputTypes
    {
        Button,
        Switch
    }

    public InputTypes inputType;

    private void Awake()
    {
        outputs = new iInteractable[outputObjects.Length];

        for (int i = 0; i < outputObjects.Length; i++)
        {
            outputs[i] = outputObjects[i].GetComponent<iInteractable>();
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.Space))
    //    {
    //        if (inputType == InputTypes.Button && buttonUsed == true)
    //        {
    //            return;
    //        }

    //        interactWithObjects();
    //        buttonUsed = true;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isActive = false;
        }
    }

    private void Update()
    {

        if (isActive && Input.GetKeyDown(KeyCode.Space))
        {
            interactWithObjects();
        }
       // if (Input.GetKeyDown(KeyCode.Space))
       // {
       //     interactWithObjects();
       // }
    }



    public void interactWithObjects()
    {
        for(int i = 0; i < outputs.Length; i++)
        {
            outputs[i].Interact();
        }
    }
}
