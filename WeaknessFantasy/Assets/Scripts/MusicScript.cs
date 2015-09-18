using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

    public static bool musicON = false;
    void Awake()
    {
        if (!musicON)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


}
