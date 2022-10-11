using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueHandler : MonoBehaviour
{
    public List<Dialogue> dialogueset;
    Dialogue currentDialogue;
    Dictionary<string, bool> currentTags;

    [Header("Text Objects")]
    public GameObject buttonPrefab;
    public GameObject buttonPanel;
    public float width = 647f;
    List<GameObject> choiceButtons;
    public TMP_Text textBox;

    public void Start()
    {
        currentDialogue = dialogueset[0];
        LoadCurrentDialogue();
    }
    public void Choose(int choice)
    {

    }
    public void LoadCurrentDialogue()
    {
        currentTags = currentDialogue.GetTags();
        
        textBox.text = currentDialogue.text;

        foreach (GameObject button in choiceButtons)
        {
            Destroy(button);
        }
        choiceButtons.Clear();

        if (currentTags.GetValueOrDefault("choices", false))
        {
            var count = currentDialogue.ChoiceCount();
            for (int i = 0; i < count; i++)
            {
                var button = Instantiate(buttonPrefab, buttonPanel.transform);
                choiceButtons.Add(button);

                var buttonTransform = button.GetComponent<RectTransform>();
                buttonTransform.anchoredPosition = new Vector2(647 / (count + 1), buttonTransform.anchoredPosition.y);

            }
        }
    }
}
