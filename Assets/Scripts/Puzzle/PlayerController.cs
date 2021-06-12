﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float fireRate = 10f;
    private float currentTimer = 0f;

    private static int numberPushing = 0;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed * Time.deltaTime);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).parent = null;
            }
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

      
    }

    void Fire()
    {
        GameObject newBullet = ObjectPooler.instance.SpawnFromPool("Bullet", transform.position, Quaternion.identity);

        Bullet newBulletScript = newBullet.GetComponent<Bullet>();

        newBulletScript.setSpeed(new Vector2(Input.GetAxisRaw("Fire1"), Input.GetAxisRaw("Fire2")));
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // child this object to the other object

        if (collision.gameObject.transform.parent != this.gameObject.transform && Input.GetKey(KeyCode.Space))
        {
            if(collision.tag == "Heavy" && numberPushing >= 2)
            {
                collision.gameObject.transform.parent = this.gameObject.transform;
            }
            else if(collision.tag == "Moveable")
            {
                collision.gameObject.transform.parent = this.gameObject.transform;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Heavy")
        {
            numberPushing++;
            if(numberPushing > 2)
            {
                numberPushing = 2;
            }
        }

        if(col.tag == "Teleporter")
        {
            transform.position = col.GetComponent<Teleporter>().RendernDropOffLocation().position;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Heavy")
        {
            numberPushing--;
            if(numberPushing < 0)
            {
                numberPushing = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death" || collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
