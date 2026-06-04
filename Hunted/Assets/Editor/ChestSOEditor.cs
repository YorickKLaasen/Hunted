using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ChestSO))]
public class ChestSOEditor : Editor
{
    SerializedProperty chestTypeProp;
    SerializedProperty chestTierProp;

    SerializedProperty _weaponLootTable;
    SerializedProperty _powerUpLootTable;
    SerializedProperty _itemLootTable;

    private void OnEnable()
    {
        chestTypeProp = serializedObject.FindProperty("chestType");
        chestTierProp = serializedObject.FindProperty("chestTier");

        _weaponLootTable = serializedObject.FindProperty("weaponLootTable");
        _powerUpLootTable = serializedObject.FindProperty("powerUpLootTable");
        _itemLootTable = serializedObject.FindProperty("itemLootTable");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(chestTypeProp);
        EditorGUILayout.PropertyField(chestTierProp);

        EditorGUILayout.Space();

        ChestSO.ChestType selectedType =
            (ChestSO.ChestType)chestTypeProp.enumValueIndex;

        switch (selectedType)
        {
            case ChestSO.ChestType.Weapon:
                EditorGUILayout.PropertyField(_weaponLootTable);
                break;

            case ChestSO.ChestType.PowerUp:
                EditorGUILayout.PropertyField(_powerUpLootTable);
                break;

            case ChestSO.ChestType.Item:
                EditorGUILayout.PropertyField(_itemLootTable);
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
