using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abillity1 : MonoBehaviour
{ 
  [SerializeField] public GameObject DoorOpen;
  [SerializeField] public GameObject DoorClosed;

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("partner1"))
    {
        DoorOpen.SetActive(true);
        DoorClosed.SetActive(false);
    }
    
  }
}
