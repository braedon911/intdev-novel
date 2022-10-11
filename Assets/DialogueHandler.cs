using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
    public List<Dialogue> dialogueset;

    
}
[System.Serializable]
public class Dialogue
{
    public string text;
    public string[] choices;
    [HideInInspector]
    public int choice_count;

    public void Load()
    {
        choice_count = choices.Length;
    }
}