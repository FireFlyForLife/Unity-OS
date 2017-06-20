using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace InGameComputer
{
    [CustomEditor(typeof(DesktopIcon))]
    [CanEditMultipleObjects]
    public class DesktopIconEditor : Editor
    {
        private DesktopIcon desktopIcon;

        private SerializedProperty textureProperty;
        private SerializedProperty underTextProperty;
        private SerializedProperty selectedColorProperty;
        private SerializedProperty programProperty;

        private bool foldout = false;
        private SerializedProperty iconReferenceProperty;
        private SerializedProperty textBackgroundReferenceProperty;
        private SerializedProperty textReferenceProperty;


        void OnEnable()
        {
            textureProperty = serializedObject.FindProperty("iconTexture");
            underTextProperty = serializedObject.FindProperty("undersideText");
            selectedColorProperty = serializedObject.FindProperty("selectedColor");
            programProperty = serializedObject.FindProperty("program");

            iconReferenceProperty = serializedObject.FindProperty("icon");
            textBackgroundReferenceProperty = serializedObject.FindProperty("underTextImage");
            textReferenceProperty = serializedObject.FindProperty("text");

            desktopIcon = (DesktopIcon)target;
            desktopIcon.RefreshAppearence();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(textureProperty);
            EditorGUILayout.PropertyField(underTextProperty);
            EditorGUILayout.PropertyField(selectedColorProperty);
            EditorGUILayout.PropertyField(programProperty);

            foldout = EditorGUILayout.Foldout(foldout, "References");
            if (foldout)
            {
                EditorGUILayout.PropertyField(iconReferenceProperty);
                EditorGUILayout.PropertyField(textBackgroundReferenceProperty);
                EditorGUILayout.PropertyField(textReferenceProperty);
            }

            serializedObject.ApplyModifiedProperties();

            desktopIcon.RefreshAppearence();
        }
    } 
}
