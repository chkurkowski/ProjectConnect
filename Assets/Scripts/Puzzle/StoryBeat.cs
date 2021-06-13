using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryBeat : MonoBehaviour
{
    public GameObject[] storyBeatPanels;

    public static StoryBeat instance;

    public float timeToWait;

    private bool canProceed = false;

    public GameObject proceedText;

    private GameObject[] players;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            
           
        }
    }

    private void Start()
    {
        StartStoryBeat();
    }


    void StartStoryBeat()
    {
        StartCoroutine(waitToProceed());
        DisablePlayerMovement();
    }

    GameObject getNextStoryBeat()
    {
        for (int i = 0; i < storyBeatPanels.Length; i++)
        {
            if (storyBeatPanels[i].activeSelf)
            {
                return storyBeatPanels[i];
            }
        }

  

        
        return null;
    }

    public void AllowSkip()
    {
        //enable press to continue text
        proceedText.SetActive(true);
        //flip bool that lets you proceed
        canProceed = true;
    }

    public void DisablePlayerMovement()
    {
         players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < players.Length; i++)
        {
            Debug.Log("Players " + players.Length.ToString());
            players[i].GetComponent<PlayerController>().DisableMovement();
        }
    }

    public void EnablePlayerMovement()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<PlayerController>().EnableMovement();
        }
    }

    IEnumerator waitToProceed()
    {
        yield return new WaitForSeconds(timeToWait);

        AllowSkip();
    }

    

    // Update is called once per frame
    void Update()
    {
        //disable player ability to move
        //is this the player's first time loading the scene? if not, disable this
        //wait a couple of seconds
        //pop up the prompt to press space
        //if they press space, and there's another story beat, load that panel and start it's timer
        //let player move again

        if (canProceed & Input.GetKeyDown(KeyCode.Space))
        {

            GameObject nextStoryBeat = getNextStoryBeat();

            nextStoryBeat.SetActive(false);

            GameObject nextNextStoryBeat = getNextStoryBeat();

            if (!nextNextStoryBeat)
            {
                //we're done, turn player movement back on
                EnablePlayerMovement();
                proceedText.SetActive(false);
            }
            else
            {
                StartCoroutine(waitToProceed());
                canProceed = false;
                proceedText.SetActive(false);
            }

            //getNextStoryBeat().SetActive(false);

        }
    }
}
