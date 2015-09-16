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
        for (int i = rows; i > 0; i--)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject obj = Instantiate(TileBase);
                obj.transform.position = new Vector3(i*1.5f, j*1.4f, -0.2f);
                obj.transform.SetParent(MapHolder.transform);
            }
        }


    }


}
