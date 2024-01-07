using UnityEditor;
using UnityEngine;

using static EventOption;

[CustomPropertyDrawer(typeof(EventOptions))]
public class EventOptionsDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType == SerializedPropertyType.Enum)
        {
            EditorGUI.BeginProperty(position, label, property);

            // �� Inspector ����ʾһ�������б�ѡ��
            property.enumValueIndex = EditorGUI.Popup(position, label.text, property.enumValueIndex, property.enumDisplayNames);

            EditorGUI.EndProperty();
        }
        else
        {
            EditorGUI.PropertyField(position, property, label);
        }
    }
}