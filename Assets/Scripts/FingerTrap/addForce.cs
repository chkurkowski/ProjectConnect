using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addForce : MonoBehaviour
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
        
        if (Input.GetKeyDown(KeyCode.D))
        {
           LaunchRight();
        }
    }
    void LaunchLeft()
    {
        Vector2 launchR = new Vector2 (-30,30);
        m_Rigidbody.AddForce (launchR * launchForce);
    }
    void LaunchRight()
    {
        Vector2 launchR = new Vector2 (30,30);
        m_Rigidbody.AddForce (launchR * launchForce);
    }
      private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Moveable" && collision.transform.parent != this.gameObject)
        {
            collision.transform.parent = this.gameObject.transform;
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).tag == "Moveable")
            {
                transform.GetChild(i).transform.eulerAngles = new Vector3(0f, 0f, transform.GetChild(i).eulerAngles.z);
            }
            
        }
    }
}
