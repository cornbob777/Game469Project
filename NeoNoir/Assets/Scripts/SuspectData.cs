using UnityEngine;

[CreateAssetMenu(fileName = "New Suspect", menuName = "Quest System/Suspect")]
public class SuspectData : ScriptableObject
{
    public string suspectName; // Name of the suspect
    public bool wasCitedForIntoxication; // Was the suspect cited for intoxication?
    public string department; // Department of the suspect
}
