using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// https://www.youtube.com/watch?v=gpnEPPyhLE8 I used this youtube video to help with this script
public class Interactable : MonoBehaviour
{
    private Renderer _renderer;
    private Color originalColor;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        originalColor = GetComponent<Renderer>().material.color;
    }

    private void OnMouseDown()
    {
        Debug.Log("Successful Click");
        Destroy(gameObject);
    }
     void Update()
    {
        //This makes the object look like its getting scaned.
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Debug.Log("Mouse 1");
            _renderer.material.color =
            _renderer.material.color == Color.green ? Color.green : Color.green;
            
        }
        else if(Input.anyKey)
        {
          _renderer.material.color = originalColor;
        }
}
}