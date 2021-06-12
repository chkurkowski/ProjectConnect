using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGoal : MonoBehaviour
{

    private ChangeScenes changeScene;

    private List<GameObject> objectsInScene;



    private int playersInGoal = 0;

    private void Awake()
    {
        changeScene = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<ChangeScenes>();
        objectsInScene = new List<GameObject>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !objectsInScene.Contains(collision.gameObject))
        {
            Debug.Log("Player has entered");
            objectsInScene.Add(collision.transform.gameObject);
            CheckPlayersInGoal();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            objectsInScene.Remove(collision.transform.gameObject);
            CheckPlayersInGoal();
        }
    }

    void CheckPlayersInGoal()
    {
        if (objectsInScene.Count == 2)
        {
            changeScene.NextScene();
        }
    }
}
