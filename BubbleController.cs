using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    //Variable declaration
    Transform bubble;
    Animator animator;
    AudioSource audioSource;

    //Value initialization
    public float speed = 1f;
    bool isPopped = false;

    // Start is called before the first frame update
    void Start()
    {
        //get gameobjects
        bubble = gameObject.GetComponent<Transform>();
        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //move bubble in time
        if(!isPopped)
            bubble.Translate(0, speed * Time.deltaTime, 0);

        //destroy bubble and lose game if bubble goes over the screen
        if(Camera.main.WorldToScreenPoint(transform.position).y > Screen.height + 230)
        {
            Destroy(gameObject);
            Scoreboard.gameDone = true;
        }
    }

    //when clicked on
    private void OnMouseDown()
    {
        //if not popped already
        if (!isPopped)
        {
            //increase score   
            Pop();
            Scoreboard.score++;
        }
    }

    //start popping animation  
    public void Pop()
    {
        isPopped = true;
        StartCoroutine(DestroyTimer());
    }

    //Destruction process
    IEnumerator DestroyTimer()
    {
        //play popping animation and sound
        audioSource.Play();
        animator.Play("BubblePopped");
        //wait for animation to finish, then destroy object
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }

    
}
