using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SuspectListUIManager : MonoBehaviour
{
    public List<TMP_Text> suspectTextElements; // List of UI Text elements for suspects
    public List<SuspectData> suspectData; // List of actual suspect data (ScriptableObjects)

    //private bool isDecrypted = false;  Flag to track if the data is decrypted

    // Method to display encrypted data (*****)
    public void ShowEncryptedList()
    {
        foreach (TMP_Text suspectText in suspectTextElements)
        {
            suspectText.text = "*****"; // Display encrypted text
        }
    }

    // Method to decrypt and display the suspect data
    public void DecryptData()
    {
        //isDecrypted = true;  Set the flag to true

        for (int i = 0; i < suspectTextElements.Count; i++)
        {
            suspectTextElements[i].text = suspectData[i].suspectName; // Show actual suspect names
        }

        Debug.Log("Suspect data revealed.");
    }
}

