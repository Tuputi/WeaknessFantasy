using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    public GameObject playerCharacter;
    public GameObject DyingPlayer;
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
            Debug.Log("Idle on!");
            anim.SetBool("Idle", true);
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
            
            //moving left or up x
            IdleTime = 0;
            anim.SetBool("Idle", false);
            currentDirection = 2;
            //left
        }
        else if(horizontal < 0 && vertical <= 0)
        {
            //moving down or right x
            
            IdleTime = 0;
            anim.SetBool("Idle", false);
            currentDirection = 3;
          // down
        }
        else if(vertical < 0)
        {
           
            IdleTime = 0;
            anim.SetBool("Idle", false);
            currentDirection = 4;
            
        }
        else if (horizontal > 0)
        {
            
            IdleTime = 0;
            anim.SetBool("Idle", false);
            currentDirection = 1;
           
        }
        return currentDirection;
    }

    void OnMouseOver()
    {
        // LightController.instance.CallFlicker();
        anim.SetBool("Idle", false);
        IdleTime = 0;
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
        anim.Play("Disappear");
        Destroy(this); //take away player control
        yield return new WaitForSeconds(0.9f);
        Application.LoadLevel(Application.loadedLevel + 1);
    }


    public IEnumerator PlayEndGameSound()
    {
        if (!hasBeeped)
        {
            GameObject deadCharacter = Instantiate(DyingPlayer);
            deadCharacter.transform.localPosition = playerCharacter.transform.localPosition - new Vector3(0,0,0.2f);
            playerCharacter.transform.FindChild("Character").GetComponent<SpriteRenderer>().enabled = false;
            //audSource.PlayOneShot(beepSound);
            hasBeeped = true;
        }

        yield return new WaitForSeconds(3f);
        Application.LoadLevel(5);
    }



}

