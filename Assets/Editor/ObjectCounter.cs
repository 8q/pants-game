using UnityEngine;
using UnityEditor;

public class ObjectCounter : Editor
{
    [MenuItem("Tools/Object Counter")]
    static void Create()
    {
        Debug.Log(Selection.gameObjects.Length);
    }
}

public class ObjectCounterWithName : Editor
{
    [MenuItem("Tools/Object Counter(Name)")]
    static void Create()
    {
        var obj = Selection.gameObjects;
        Debug.Log(obj.Length);
        foreach (GameObject g in obj)
        {
            Debug.Log(g.name);
        }
    }
}

