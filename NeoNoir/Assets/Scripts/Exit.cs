using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
   
    void Update()
    {
        if(Input.GetKeyDown("escape"))
Application.Quit();
    }
}
