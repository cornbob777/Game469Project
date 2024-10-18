using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanUI : MonoBehaviour
{
    private Renderer _renderer;
    [SerializeField] public GameObject Scanui ;
    
    void Start()
    {
         _renderer = GetComponent<Renderer>();
         Scanui.SetActive(false);
    }

    // Update is called once per frame
     void Update()
    {
        
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Scanui.SetActive(true);
        }
        else if(Input.anyKey)
        {
          Scanui.SetActive(false);
        }
}
}