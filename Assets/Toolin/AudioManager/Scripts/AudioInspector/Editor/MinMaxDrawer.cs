using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(MinMaxAttribute))]
public class MinMaxDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        MinMaxAttribute minMax = attribute as MinMaxAttribute;
  
        if (property.propertyType == SerializedPropertyType.Vector2)
        {

            if (minMax.ShowDebugValues || minMax.ShowEditRange)
            {
                position = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            }

          
            float minValue = property.vector2Value.x; 
            float maxValue = property.vector2Value.y;
            float minLimit = minMax.minLimit; 
            float maxLimit = minMax.maxLimit;

   
            EditorGUI.MinMaxSlider(position, label, ref minValue, ref maxValue, minLimit, maxLimit);

            var vec = Vector2.zero; 
            vec.x = minValue;
            vec.y = maxValue;

            property.vector2Value = vec;


            if (minMax.ShowDebugValues || minMax.ShowEditRange)
            {
                bool isEditable = false;
                if (minMax.ShowEditRange)
                {
                    isEditable = true;
                }

                if (!isEditable)
                    GUI.enabled = false;


                position.y += EditorGUIUtility.singleLineHeight;

                Vector4 val = new Vector4(minLimit, minValue, maxValue, maxLimit);
                val = EditorGUI.Vector4Field(position, "MinLimit/MinVal/MaxVal/MaxLimit", val);

                GUI.enabled = false;
                position.y += EditorGUIUtility.singleLineHeight;
                EditorGUI.FloatField(position, "Selected Range", maxValue - minValue);
                GUI.enabled = true;

                if (isEditable)
                {
                    property.vector2Value = new Vector2(val.y, val.z);
                }

            }
            else
            {
                GUI.enabled = false;
                position.y += EditorGUIUtility.singleLineHeight;
                EditorGUI.Vector2Field(position, "Current Values", new Vector2(minValue, maxValue));
                GUI.enabled = true;
            } 
        }
    }


    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        MinMaxAttribute minMax = attribute as MinMaxAttribute;


        float size = EditorGUIUtility.singleLineHeight;

        if (minMax.ShowEditRange || minMax.ShowDebugValues)
        {
            size += EditorGUIUtility.singleLineHeight * 2;
        }
        else
        {
            size += EditorGUIUtility.singleLineHeight;
        }
        return size;
    }
}
