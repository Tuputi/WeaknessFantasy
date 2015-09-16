using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {


    public enum TriggerType { NextLevel, Sound};

    public TriggerType type;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger");
        other.GetComponent<CharacterMovement>().withinActionTrigger = true;

        switch (type)
        {
            case TriggerType.NextLevel:
                CharacterMovement charMove = GameObject.Find("PlayerCharacter").GetComponentInChildren<CharacterMovement>();
                StartCoroutine(charMove.PlayEndLevelAnimation());
                break;
            case TriggerType.Sound:
                break;
            default:
                break;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<CharacterMovement>().withinActionTrigger = true;
    }
}
