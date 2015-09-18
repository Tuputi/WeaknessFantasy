using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicScript : MonoBehaviour {

    
    void Awake()
    {
      
            DontDestroyOnLoad(this.gameObject);
    }


}
