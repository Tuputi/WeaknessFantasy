using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {


    public enum TriggerType { NextLevel, Sound, Light, ExpandLight, EndGame};

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
            case TriggerType.Light:
                SphereScript.instance.CreateLight();
                Destroy(this.gameObject);
                break;
            case TriggerType.ExpandLight:
                SphereScript.instance.currentObject = this.gameObject.transform.parent.gameObject;
                SphereScript.instance.ExpandOn = true;
                break;
            case TriggerType.EndGame:
                Application.LoadLevel(0);
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
