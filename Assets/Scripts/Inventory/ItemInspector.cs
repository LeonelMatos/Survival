using Sirenix.OdinInspector.Editor;
using UnityEditor;
using static Item;
using UnityEngine;

[CustomEditor(typeof(Item))]
public class ItemInspector : OdinEditor
{
    public GameObject ObjectDrawnWithOdin;

    private SerializedProperty type;
    private SerializedProperty name;
    private SerializedProperty amount;
    private SerializedProperty description;
    private SerializedProperty isStackable;
    private SerializedProperty sprite;
    private SerializedProperty color;


    protected override void OnEnable () {
        base.OnEnable();

        type = serializedObject.FindProperty("type");
        name = serializedObject.FindProperty("name");
        amount = serializedObject.FindProperty("amount");
        description = serializedObject.FindProperty("description");
        isStackable = serializedObject.FindProperty("isStackable");
        sprite = serializedObject.FindProperty("sprite");
        color = serializedObject.FindProperty("color");
    }

    public override void OnInspectorGUI() {

        //base.OnInspectorGUI();
        //
        DrawDefaultInspector();
        //
        serializedObject.Update();

        EditorGUILayout.LabelField("Item Creator", EditorStyles.boldLabel);

        EditorGUILayout.PropertyField(type);
        EditorGUILayout.PropertyField(name);
        EditorGUILayout.PropertyField(amount);
        EditorGUILayout.PropertyField(description);
        EditorGUILayout.PropertyField(isStackable);
        EditorGUILayout.PropertyField(sprite);
        EditorGUILayout.PropertyField(color);

        serializedObject.ApplyModifiedProperties();

    }
}
