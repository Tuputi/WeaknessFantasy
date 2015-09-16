using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    public GameObject playerCharacter;
    public float speed = 4f;
    public Facing facing = Facing.Right;

    public bool withinActionTrigger = false;

    Animator anim;

    public enum Facing {  Right, Left, Up, Down};



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
            //moving left or up
            return 2; //left
        }
        else if(horizontal < 0 && vertical <= 0)
        {
            //moving down or right
            Debug.Log("downLeft");
            return 3; // down
        }
        else if(horizontal < 0 && vertical >= 0)
        {
            Debug.Log("leftup");
            return 4;
        }
        else if (horizontal >= 0 && vertical < 0)
        {
            Debug.Log("rightDown");
            return 1;
        }
        return 0;
    }

   /* void OnMouseOver()
    {
        LightController.instance.CallFlicker();
    }
    void OnMouseExit()
    {
        LightController.instance.CloseFlicker();
    }*/

}

