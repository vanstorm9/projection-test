﻿using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(LeapImageBasedMaterial))]
public class LeapImageBasedMaterialEditor : Editor {

  private List<string> BasicModePropertyNames = new List<string>() { 
    "m_Script",
  };

  public override void OnInspectorGUI() {
    SerializedProperty properties = serializedObject.GetIterator();

    bool useEnterChildren = true;
    while (properties.NextVisible(useEnterChildren) == true) {
      useEnterChildren = false;
      if (AdvancedMode._advancedModeEnabled || BasicModePropertyNames.Contains(properties.name)) {
        EditorGUILayout.PropertyField(properties, true);
      }
    }

    serializedObject.ApplyModifiedProperties();
  }
}
