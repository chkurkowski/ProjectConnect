using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleGoal : MonoBehaviour
{

    public DoubleGoal otherGoal;

    private ChangeScenes changeScene;

    private bool hasPlayer = false;



    private void Awake()
    {
        changeScene = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<ChangeScenes>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hasPlayer = true;
            
            CheckPlayersInGoal();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hasPlayer = false;
            
            CheckPlayersInGoal();
        }
    }

    void CheckPlayersInGoal()
    {
        if (hasPlayer && otherGoal.hasPlayer)
        {
            changeScene.NextScene();
        }
    }
}

