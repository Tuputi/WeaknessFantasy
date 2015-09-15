using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapCreator : MonoBehaviour {

    public GameObject TileBase;
    public GameObject MapHolder;

    public int rows;
    public int columns;

    //List<List<GameObject>> map;



    void Start()
    {
        for (int i = 0; i <= rows; i++)
        {
            for (int j = 0; j <= columns; j++)
            {
                GameObject obj = Instantiate(TileBase);
                obj.transform.position = new Vector3(i, j, -0.2f);
                obj.transform.SetParent(MapHolder.transform);
            }
        }


    }


}
