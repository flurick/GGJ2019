using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AlignWithSphere))]
public class AlignEditor : Editor
{
    void OnSceneGUI()
    {
        AlignWithSphere origin = (target as AlignWithSphere);

        EditorGUI.BeginChangeCheck();
        //Quaternion rot = Handles.RotationHandle(origin.transform.rotation, Vector3.zero);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Rotated arond point");
            EditorUtility.SetDirty(target);
        }
    }
}
