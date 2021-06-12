using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 direction;
    public float bulletSpeed;

    public float bulletDistance = 30f;
    private float currentTimer = 0f;

    private float maxRange = 10f;

    // Start is called before the first frame update
    public void setSpeed(Vector2 newDirection)
    {
        direction = newDirection;
    }

    public void SetLongRange()
    {
        bulletDistance = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer += Time.deltaTime * bulletDistance;

        if (currentTimer >= 10f)
        {
            currentTimer = 0f;
            gameObject.SetActive(false);
            bulletDistance = 30f;
        }

        transform.Translate(direction * bulletSpeed * Time.deltaTime);
        //transform.localScale += new Vector3(0.1f, 0.1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyFollow enemyFollow = collision.gameObject.GetComponent<EnemyFollow>();
            enemyFollow.LoseHealth();
            gameObject.SetActive(false);
        }
    }
}
