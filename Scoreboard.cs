using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    //Variable Declaration
    Text ScoreText;
    public GameObject spawner;
    public GameObject GOText;
    public GameObject RestartButton;
    public GameObject ExitButton;

    //Initialization for the start of the game
    public static int score = 0;
    public static bool gameDone = false;

    // Start is called before the first frame update
    void Start()
    {
        //Get Components and restart in case game has loaded from an exit to the menu
        ScoreText = gameObject.GetComponentInChildren<Text>();
        Restart();
        
    }

    // Update is called once per frame
    void Update()
    {
        //display score
        ScoreText.text = "Bubbles Popped: " + score;

        //check for game over
        if (gameDone)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        //stop creating bubbles
        spawner.GetComponent<BubbleSpawner>().StopSpawning();

        //clear bubbles from screen
        foreach(Transform child in spawner.transform)
        {
            child.gameObject.GetComponent<BubbleController>().Pop();
        }

        //Show Endgame GUI
        GOText.SetActive(true);
        RestartButton.SetActive(true);
        ExitButton.SetActive(true);
    }

    //To restart the game
    public void Restart()
    {
        //reset values
        gameDone = false;
        score = 0;
        spawner.GetComponent<BubbleSpawner>().speedcount = 1;
        spawner.GetComponent<BubbleSpawner>().spawnPeriod = 2f;
        spawner.GetComponent<BubbleSpawner>().waves = 0;

        //remove endgame GUI
        GOText.SetActive(false);
        RestartButton.SetActive(false);
        ExitButton.SetActive(false);

        //Begin game
        spawner.GetComponent<BubbleSpawner>().StartSpawning();
    }
}
