using UnityEditor;

// 1
[CustomEditor(typeof(MoveEnemy))]
// 2
public class EnemyDataEditor : Editor
{
    // 3
    public override void OnInspectorGUI()
    {
        // 4
        MoveEnemy moveEnemy = (MoveEnemy)target;
        HealthBar healthBar = moveEnemy.gameObject.GetComponentInChildren<HealthBar>();
        // 5
        healthBar.maxHealth = EditorGUILayout.FloatField("Max Health", healthBar.maxHealth);
        // 6
        healthBar.currentHealth = EditorGUILayout.Slider("Current Health", healthBar.currentHealth, 0, healthBar.maxHealth);
        // 7
        DrawDefaultInspector();
    }
}
