using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

[ExecuteInEditMode]
public class DialogueChartEditor : EditorWindow
{
    //this stuff looks fancy, but it's actually very easy to tweak the inspector like this as long as you trust tutorials and use your brain a lil :)

    [MenuItem("Window/Dialogue/Chart Editor", false, 10)]
    public static void Open()
    {
        DialogueChartEditor editor = GetWindow<DialogueChartEditor>("Chart Editor");
        
    }

    private void OnEnable()
    {
        DialogueChart chart = new DialogueChart();
        rootVisualElement.Add(chart);

        chart.StretchToParentSize();
    }
}
