using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    //Variable Declaration
    Animator animator;
    public Scoreboard scoreboard;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        //Get Components from scene
        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //Start Animation and functionality in time
        StartCoroutine(DestroyTimer());
    }

    IEnumerator DestroyTimer()
    {
        //Play bubble pop sound
        audioSource.Play();

        //Play animation and wait for animation to finish
        animator.Play("GenericBubblePopAnim");
        yield return new WaitForSeconds(0.4f);

        //Button Check
        if(gameObject.name == "RestartBubble") // Restart
        {
            scoreboard.Restart();
        }
        else if (gameObject.name == "StartBubble")//Start
        {
            SceneManager.LoadScene(sceneName: "MainGame");
            
        }
        else if(gameObject.name == "ExitBubble")//Exit
        {
            SceneManager.LoadScene(sceneName: "TitleScreen");
        }
        else if(gameObject.name == "QuitBubble") //Quit
        {
            Application.Quit();
        }
        
    }
}
