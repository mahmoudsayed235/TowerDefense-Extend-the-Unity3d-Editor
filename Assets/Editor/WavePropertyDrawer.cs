//1
using UnityEditor;
using UnityEngine;

//2
[CustomPropertyDrawer(typeof(Wave))]
//3
public class WavePropertyDrawer : PropertyDrawer
{
    //4
    private const int spriteHeight = 50;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PropertyField(position, property, label, true);
        // 1
        if (property.isExpanded)
        {
            // 2
            SerializedProperty enemyPrefabProperty = property.FindPropertyRelative("enemyPrefab");
            GameObject enemyPrefab = (GameObject)enemyPrefabProperty.objectReferenceValue;
            // 3
            if (enemyPrefab != null)
            {
                SpriteRenderer enemySprite = enemyPrefab.GetComponentInChildren<SpriteRenderer>();
                // 4
                int previousIndentLevel = EditorGUI.indentLevel;
                EditorGUI.indentLevel = 2;
                // 5
                Rect indentedRect = EditorGUI.IndentedRect(position);
                float fieldHeight = base.GetPropertyHeight(property, label) + 2;
                Vector3 enemySize = enemySprite.bounds.size;
                Rect texturePosition = new Rect(indentedRect.x, indentedRect.y + fieldHeight * 4, enemySize.x / enemySize.y * spriteHeight, spriteHeight);
                // 6
                EditorGUI.DropShadowLabel(texturePosition, new GUIContent(enemySprite.sprite.texture));
                // 7
                EditorGUI.indentLevel = previousIndentLevel;
            }
        }

    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property);
    }
}
