using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorScript : MonoBehaviour {

    public List<GameObject> possibleDoors;
    public GameObject door;

    void Start()
    {
        int random = Random.Range(0, possibleDoors.Count);

        GameObject newDoor = Instantiate(door);
        newDoor.transform.SetParent(possibleDoors[random].transform);
        newDoor.transform.localPosition = new Vector3(0, 0, 0);
    }


}
