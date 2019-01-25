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
        Quaternion rotx = Handles.Disc(origin.centerRot, Vector3.zero, new Vector3(1, 0, 0), origin.transform.position.z, false, 1);
        Quaternion roty = Handles.Disc(origin.centerRot, Vector3.zero, new Vector3(0, 1, 0), origin.transform.position.z, false, 1);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Rotated arond point");
            EditorUtility.SetDirty(target);
            origin.transform.rotation = rotx * roty;
        }
    }
}
