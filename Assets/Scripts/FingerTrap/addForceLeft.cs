using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addForceLeft : MonoBehaviour
{
   Rigidbody2D m_Rigidbody;
    public float launchForce = 2000f;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            LaunchLeft();
        }
    }
    void LaunchLeft()
    {
        Vector2 launchR = new Vector2 (-30,30);
        m_Rigidbody.AddForce (launchR * launchForce);
    }
}
