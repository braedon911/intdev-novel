using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    [TextArea()]
    public string text;
    public string[] choices;
    public string tags;

    public int ChoiceCount()
    {
        return choices.Length;
    }
    public Dictionary<string, bool> GetTags()
    {
        //playin around with stuff like a tag system. for marking dialogue as particular to a character, for now
        Dictionary<string, bool> tagsFormat = new Dictionary<string, bool>();
        string[] pairs = tags.Split(char.Parse(","));
        foreach (string pair in pairs)
        {
            string[] keyandval = pair.Split(char.Parse("="));
            string key = keyandval[0];
            bool value = keyandval[1] == "true";
            tagsFormat.Add(key, value);
        }

        return tagsFormat;
    }
}