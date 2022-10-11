using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    [TextArea()]
    public string text;
    public Choice[] choices;
    public string tags;
    public Dialogue next;

    public int ChoiceCount()
    {
        return choices.Length;
    }
    public Dialogue GetNextFromChoiceIndex(int index)
    {
        return choices[index].link;
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
            Debug.Log(key + "=" + value);
            tagsFormat.Add(key, value);
        }
        
        return tagsFormat;
    }
}

[System.Serializable]
public class Choice
{
    public Dialogue link;
    public string name;
}