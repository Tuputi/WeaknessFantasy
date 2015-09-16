using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    public GameObject playerCharacter;
    public float speed = 4f;
  

    public bool withinActionTrigger = false;

    Animator anim;

    //sound
    public AudioSource audSource;
    public AudioClip beepSound;
    bool hasBeeped = false;

    public int currentDirection;

    public float IdleTime = 0;
    public float IdleTimeEdge = 5f;



    void Start()
    {
        playerCharacter = GameObject.Find("PlayerCharacter").gameObject;
        anim = playerCharacter.GetComponentInChildren<Animator>();
        //audSource = playerCharacter.GetComponentInChildren<AudioSource>();
    }

    void FixedUpdate()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        playerCharacter.transform.position += move * speed * Time.deltaTime;

        float speedValue = Input.GetAxis("Horizontal") + Input.GetAxis("Vertical");
        anim.SetFloat("Speed", speedValue);
        anim.SetInteger("MoveDirection", WhichDirection(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }


    void Update()
    {
        IdleTime += Time.fixedDeltaTime;
        if(IdleTime > IdleTimeEdge)
        {
            int rando = Random.Range(1, 3);
            if(rando > 2)
            {
                anim.Play("Smiling");
            }
            else
            {
                anim.Play("Waiting");
            }
            currentDirection = 4;
            IdleTime = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && withinActionTrigger){
            Debug.Log("Action!");
        }


        


    }


    int WhichDirection(float horizontal, float vertical)
    {
        if(horizontal >= 0 && vertical > 0)
        {
            Debug.Log("rightUp");
            //moving left or up x
            IdleTime = 0;
            currentDirection = 2;
            //left
        }
        else if(horizontal < 0 && vertical <= 0)
        {
            //moving down or right x
            Debug.Log("downLeft");
            IdleTime = 0;
            currentDirection = 3;
          // down
        }
        else if(vertical < 0)
        {
            Debug.Log("leftup");
            IdleTime = 0;
            currentDirection = 4;
            
        }
        else if (horizontal > 0)
        {
            Debug.Log("rightDown");
            IdleTime = 0;
            currentDirection = 1;
           
        }
        return currentDirection;
    }

    void OnMouseOver()
    {
        // LightController.instance.CallFlicker();
        anim.Play("Smiling");
        currentDirection = 4;
        if (!hasBeeped)
        {
            audSource.PlayOneShot(beepSound);
            hasBeeped = true;
        }
        
    }
    void OnMouseExit()
    {
        hasBeeped = false;
        // LightController.instance.CloseFlicker();
    }


    public IEnumerator PlayEndLevelAnimation()
    {
        Debug.Log("in here");
        anim.Play("Disappear");
        
        yield return new WaitForSeconds(0.9f);
        Application.LoadLevel(Application.loadedLevel + 1);
    }


    public IEnumerator PlayEndGameSound()
    {
        audSource.PlayOneShot(beepSound);

        yield return new WaitForSeconds(0.9f);
        Application.LoadLevel(0);
    }



}

