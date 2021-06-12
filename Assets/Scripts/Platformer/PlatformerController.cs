using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{
    public string MoveAxis;
    public string JumpAxis;

    public float movementSpeed;

    public float jumpForce;

    private bool canJump = true;




    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxisRaw(MoveAxis) * movementSpeed * Time.deltaTime, 0f, 0f);

        if (Input.GetAxisRaw(JumpAxis) == 1.0f && canJump)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            canJump = false;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            canJump = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.Space))
        {
            gameObject.SetActive(false);
        }
    }
}
