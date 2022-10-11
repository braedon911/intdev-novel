using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;
using UnityEditor;

public class DialogueChart : GraphView
{
    public DialogueChart()
    {
        GridBackground background = new GridBackground();
        background.StretchToParentSize();
        Insert(0, background);

        StyleSheet style = (StyleSheet) EditorGUIUtility.Load("dialoguegrid.uss");
        styleSheets.Add(style);
    }
}
