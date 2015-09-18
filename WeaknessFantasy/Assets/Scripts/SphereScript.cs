using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SphereScript : MonoBehaviour {

    public List<GameObject> appearPoints;
   // public List<GameObject> usedPoints;
    public GameObject sphere;
    public static SphereScript instance;
    public Camera playerCamera;

    float cameraOrgSize;

    //expand
    public bool ExpandOn = false;
    bool shrinkON = false;
    public GameObject currentObject = null;

    void Awake()
    {
        instance = this;
        cameraOrgSize = playerCamera.orthographicSize;
    }

    void Update()
    {
        if (ExpandOn)
        {
            Expand(currentObject);
        }
    }


   public void CreateLight()
    {
        int i = Random.Range(0, appearPoints.Count);
        Debug.Log(i);

        GameObject newSphere = Instantiate(sphere);
       
        newSphere.transform.SetParent(appearPoints[i].transform);
        newSphere.transform.localPosition = new Vector3(0, 0, 0);

        //usedPoints.Add(appearPoints[i]);
        appearPoints.RemoveAt(i);
    }

    public void Expand(GameObject sphereOb)
    {
        Light lightSource = sphereOb.GetComponentInChildren<Light>();
        if (!shrinkON)
        {
            if (lightSource.spotAngle < 160)
            {
                lightSource.spotAngle += 1f;
                lightSource.range += 0.05f;

                playerCamera.orthographicSize += 0.01f;
            }
            else
            {
                shrinkON = true;
            }
        }
        else
        {
            if (playerCamera.orthographicSize > cameraOrgSize)
            {
                playerCamera.orthographicSize -= 0.01f;
            }
            if (lightSource.spotAngle <= 0 || lightSource.range <= 0)
            {
                ExpandOn = false;
                shrinkON = false;
                currentObject = null;
                Destroy(sphereOb);
                
            }
            else
            {
                lightSource.spotAngle -= 1f;
                lightSource.range -= 0.1f;
            }
        }
        
    }
}
