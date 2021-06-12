using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPlatformerController : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float fireRate = 10f;
    private float currentTimer = 0f;
    private bool canJump = true;

    public float jumpForce;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));

        if (Input.GetKeyUp(KeyCode.Space))
        {
            //break back into 2 parts
        }

        if (Input.GetAxis("Fire1") != 0 || Input.GetAxis("Fire2") != 0)
        {
            if (currentTimer >= 100f)
            {
                currentTimer = 0f;
                Fire();
            }

        }

        currentTimer += Time.deltaTime * fireRate;

        if (Input.GetAxisRaw("Vertical") == 1.0f && canJump)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            canJump = false;
        }


    }

    void Fire()
    {
        GameObject newBullet = ObjectPooler.instance.SpawnFromPool("Bullet", transform.position, Quaternion.identity);

        Bullet newBulletScript = newBullet.GetComponent<Bullet>();

        newBulletScript.setSpeed(new Vector2(Input.GetAxisRaw("Fire1"), Input.GetAxisRaw("Fire2")));
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death" || collision.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Floor")
        {
            canJump = true;
        }
    }
}
