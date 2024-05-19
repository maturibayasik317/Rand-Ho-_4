using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SUB_sceneManeger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [CustomPropertyDrawer(typeof(SceneFieldAttribute))]
    public class SceneFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.String)
            {
                EditorGUI.BeginChangeCheck();
                var scene = EditorGUI.ObjectField(position, label, AssetDatabase.LoadAssetAtPath<SceneAsset>(property.stringValue), typeof(SceneAsset), false);
                if (EditorGUI.EndChangeCheck())
                {
                    property.stringValue = AssetDatabase.GetAssetPath(scene);
                }
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "Use SceneField with string.");
            }
        }
    }
}
