using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class DialogueHandler : MonoBehaviour
{
    public List<Dialogue> dialogueset;
    Dialogue currentDialogue;
    Dictionary<string, bool> currentTags;

    [Header("Text Objects")]
    public GameObject buttonPrefab;
    public GameObject buttonPanel;
    public GameObject nextButton;
    public float width = 647f;
    List<GameObject> choiceButtons;
    public TMP_Text textBox;

    public void Start()
    {
        currentDialogue = dialogueset[0];
        choiceButtons = new List<GameObject>();
        LoadCurrentDialogue();
    }
    public void Choose(int choice)
    {
        currentDialogue = currentDialogue.choices[choice -1].link;
        LoadCurrentDialogue();
    }
    public void Next()
    {
        currentDialogue = currentDialogue.next;
        LoadCurrentDialogue();
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
            nextButton.SetActive(false);
            var count = currentDialogue.ChoiceCount();
            for (int i = 0; i < count; i++)
            {
                var button = Instantiate(buttonPrefab, buttonPanel.transform);
                choiceButtons.Add(button);

                var buttonTransform = button.GetComponent<RectTransform>();
                buttonTransform.anchoredPosition = new Vector2(width / (count + 1), buttonTransform.anchoredPosition.y);

                TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
                buttonText.text = currentDialogue.choices[i].name;

                Button interactable = button.GetComponent<Button>();
                //mwahahahahaaaaaaaaaaaa IM EVIL
                interactable.onClick.AddListener(() => Choose(i));
            }
        }
        else
        {
            nextButton.SetActive(true);
        }
    }
}
