using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateAnimalWindow : EditorWindow
{
    [MenuItem("Custom Tools/ Create Animal Prefabs")]

    public static void CreateShowCase()
    {
        EditorWindow window = GetWindow<CreateAnimalWindow>("Create Animal Prefabs");
    }


    public void OnEnable()
    {
        
    }


}
