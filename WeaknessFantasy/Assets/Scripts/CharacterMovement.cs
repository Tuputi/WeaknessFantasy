using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

   public GameObject playerCharacter;
    public float speed = 4f;

    void Start()
    {
        playerCharacter = GameObject.Find("PlayerCharacter").gameObject;
        
    }

    void FixedUpdate()
    {

        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        playerCharacter.transform.position += move * speed * Time.deltaTime;
        
    }
    
    void OnMouseOver()
    {
        LightController.instance.CallFlicker();
    }
    void OnMouseExit()
    {
        LightController.instance.CloseFlicker();
    }


}
