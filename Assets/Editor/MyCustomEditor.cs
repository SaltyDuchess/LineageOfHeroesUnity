using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ScriptableObject), true, isFallback = true)]
public class MyCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var sourceObject = target as ScriptableObject;

        GUILayout.Space(20);

        GUILayout.Label("Copy values to another ScriptableObject:");

        EditorGUI.BeginChangeCheck();
        var targetType = EditorGUILayout.ObjectField("Target ScriptableObject", null, typeof(ScriptableObject), false) as ScriptableObject;
        if (EditorGUI.EndChangeCheck() && targetType != null)
        {
            CopyValues(sourceObject, targetType);
        }
    }

    private void CopyValues(ScriptableObject source, ScriptableObject target)
    {
        var sourceFields = source.GetType().GetFields();
        var targetFields = target.GetType().GetFields();

        foreach (var sourceField in sourceFields)
        {
            var targetField = System.Array.Find(targetFields, field => field.Name == sourceField.Name);
            if (targetField != null)
            {
                targetField.SetValue(target, sourceField.GetValue(source));
            }
        }

        EditorUtility.SetDirty(target);
    }
}
