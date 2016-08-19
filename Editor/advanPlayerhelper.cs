using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(AdvanPlayerObj))]
[CanEditMultipleObjects]

public class advanPlayerhelper : Editor
{
    string[] names = new string[4] { "idie = 0", "walking = 1", "running = 2", "isJumbing = 3" };
public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
       foreach (var item in names)
       {
           GUILayout.Label(item);	
       }
        }
        
    }