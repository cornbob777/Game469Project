using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDCardpickup : MonoBehaviour
{
    [SerializeField] public GameObject Partner1;
    private void OnDestroy () {
    Partner1.SetActive(true);
}
}
