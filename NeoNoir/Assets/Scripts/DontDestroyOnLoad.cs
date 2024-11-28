using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private static GameObject Instance;
   void Awake(){
DontDestroyOnLoad(gameObject);

GameObject[] playersControllers = GameObject.FindGameObjectsWithTag ("Player");
		if (playersControllers.Length > 1)
			Destroy (playersControllers [1]);

}
}

// https://discussions.unity.com/t/how-move-player-between-scenes/161471/2 I used this for help