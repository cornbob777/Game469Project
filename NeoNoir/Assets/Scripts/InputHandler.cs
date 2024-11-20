using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Camera inputCamera; // Assign your InputCamera here
    public LayerMask interactableLayer; // Set the layer for interactable objects

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detect left-click
        {
            Ray ray = inputCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactableLayer))
            {
                Debug.Log("Interacted with: " + hit.collider.name);
                // Implement interaction logic here
            }
        }
    }
}