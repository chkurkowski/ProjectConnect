using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform target = null;
    public float speed;
    GameObject[] players;

    public int health = 10;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }


    public Transform DetermineTarget()
    {
        //determine who to target - player 1 or player 2 (Based on distance maybe?)

        if (target == null)
        {
            int randomNum = Random.Range(0, 2);

            target = players[randomNum].transform;

            return target;
        }

        return target;
     
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, DetermineTarget().position, step);
    }

    public void LoseHealth()
    {
        health--;

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
