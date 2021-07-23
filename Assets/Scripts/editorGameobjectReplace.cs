using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class editorGameobjectReplace : ScriptableWizard
{
    public bool copyValues = true;
    public GameObject ReplacementPrefab;
    public GameObject ParentWithChildrenToReplace;

    [MenuItem("Custom/Replace GameObjects")]


    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Replace GameObjects", typeof(editorGameobjectReplace), "Replace");
    }

    void OnWizardCreate()
    {
        Transform[] Replaces;
        Replaces = ParentWithChildrenToReplace.GetComponentsInChildren<Transform>();

        foreach (Transform t in Replaces)
        {
            GameObject newObject;
            newObject = (GameObject)PrefabUtility.InstantiatePrefab(ReplacementPrefab);
            newObject.transform.position = t.position;
            newObject.transform.rotation = t.rotation;

            Destroy(t.gameObject);

        }

    }
}