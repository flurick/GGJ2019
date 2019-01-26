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

        Quaternion originRot = Quaternion.Euler(origin.centerRot);
        Quaternion rotx = Handles.Disc(originRot, Vector3.zero, originRot * new Vector3(1, 0, 0), 50, false, 1);
        Quaternion roty = Handles.Disc(originRot, Vector3.zero, originRot * new Vector3(0, 1, 0), 50, false, 1);
        if (EditorGUI.EndChangeCheck())
        {
            Vector3 rotAxis = rotx.eulerAngles + roty.eulerAngles;
            origin.transform.eulerAngles = rotAxis;
            origin.centerRot = rotAxis;
            Undo.RecordObject(origin, "Rotated arond point");
            EditorUtility.SetDirty(origin);
        }
    }
}
