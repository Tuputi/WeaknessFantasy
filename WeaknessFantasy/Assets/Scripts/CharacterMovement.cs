using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    public GameObject playerCharacter;
    public float speed = 4f;
  

    public bool withinActionTrigger = false;

    Animator anim;

    public int currentDirection;



    void Start()
    {
        playerCharacter = GameObject.Find("PlayerCharacter").gameObject;
        anim = playerCharacter.GetComponentInChildren<Animator>();
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
            currentDirection = 2;
            //left
        }
        else if(horizontal < 0 && vertical <= 0)
        {
            //moving down or right x
            Debug.Log("downLeft");
            currentDirection = 3;
          // down
        }
        else if(vertical < 0)
        {
            Debug.Log("leftup");
            currentDirection = 4;
            
        }
        else if (horizontal > 0)
        {
            Debug.Log("rightDown");
            currentDirection = 1;
           
        }
        return currentDirection;
    }

   /* void OnMouseOver()
    {
        LightController.instance.CallFlicker();
    }
    void OnMouseExit()
    {
        LightController.instance.CloseFlicker();
    }*/


    public IEnumerator PlayEndLevelAnimation()
    {
        Debug.Log("in here");
        anim.Play("Disappear");
       // float second = GetComponentInChildren<Animator>().animation
      //      ("Disappear").length;
        yield return new WaitForSeconds(3);
        Application.LoadLevel(Application.loadedLevel + 1);
    }

}

