using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyFollower : MonoBehaviour
{
   
    private static GameObject Instance;
   void Awake(){
DontDestroyOnLoad(gameObject);

GameObject[] partnerControllers = GameObject.FindGameObjectsWithTag ("partner1");
		if (partnerControllers.Length > 1)
			Destroy (partnerControllers [1]);

}

}