using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {



    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger");
        other.GetComponent<CharacterMovement>().withinActionTrigger = true;
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<CharacterMovement>().withinActionTrigger = true;
    }
}
