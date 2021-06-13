using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float fireRate = 10f;
    private float currentTimer = 0f;
    float vertical;
    float horizontal;
    private static List<GameObject> pushing = new List<GameObject>();
    private static List<GameObject> adjacentToHeavy = new List<GameObject>();

    public enum playerTypes
    {
        torso,
        legs
    }

    public playerTypes type;

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed * Time.deltaTime);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            foreach(GameObject gm in pushing)
            {
                gm.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            }

            pushing.Clear();
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

    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        if(Mathf.Abs(horizontal) > Mathf.Abs(vertical))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * horizontal, 0);
        }
        else if(Mathf.Abs(vertical) > Mathf.Abs(horizontal))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, moveSpeed * vertical);
        }
        else if(vertical == 0 && horizontal == 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        foreach(GameObject gm in pushing)
        {
            if(Mathf.Abs(horizontal) > Mathf.Abs(vertical))
            {
                gm.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * horizontal, 0);
            }
            else if(Mathf.Abs(vertical) > Mathf.Abs(horizontal))
            {
                gm.GetComponent<Rigidbody2D>().velocity = new Vector2(0, moveSpeed * vertical);
            }
            else if(vertical == 0 && horizontal == 0)
            {
                gm.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
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
        // child this object to the other object

        if (collision.gameObject.transform.parent != this.gameObject.transform && Input.GetKey(KeyCode.Space))
        {
            if(collision.tag == "Heavy" && adjacentToHeavy.Count >= 2)
            {
                if(adjacentToHeavy[0] == adjacentToHeavy[1] && !pushing.Contains(collision.gameObject))
                {
                    pushing.Add(collision.gameObject);
                    Debug.Log(pushing.Count);
                }
            }
            else if(collision.tag == "Moveable" && !pushing.Contains(collision.gameObject))
            {
                pushing.Add(collision.gameObject);
                Debug.Log(pushing.Count);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Heavy")
        {
            if(adjacentToHeavy.Count < 2)
            {
                adjacentToHeavy.Add(col.gameObject);
            }
            Debug.Log(adjacentToHeavy.Count);
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
            if(adjacentToHeavy.Contains(col.gameObject))
            {
                adjacentToHeavy.Remove(col.gameObject);
            }
            Debug.Log(adjacentToHeavy.Count);
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
