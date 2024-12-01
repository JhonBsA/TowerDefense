using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Turret))]
public class TurretEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Turret turret = (Turret)target;

        // General properties
        EditorGUILayout.LabelField("General", EditorStyles.boldLabel);
        turret.detectionRange = EditorGUILayout.FloatField("Detection Range", turret.detectionRange);

        // Toggle for Laser Turret
        turret.useLaser = EditorGUILayout.Toggle("Use Laser", turret.useLaser);

        // If it's a Laser Turret, show the laser-specific properties
        if (turret.useLaser)
        {
            EditorGUILayout.LabelField("Laser Turret", EditorStyles.boldLabel);
            turret.lineRenderer = (LineRenderer)EditorGUILayout.ObjectField("Line Renderer", turret.lineRenderer, typeof(LineRenderer), true);
        }
        else
        {
            // Otherwise, show the Projectile Turret settings
            EditorGUILayout.LabelField("Projectile Turret (default)", EditorStyles.boldLabel);
            turret.fireRate = EditorGUILayout.FloatField("Fire Rate", turret.fireRate);
            turret.projectilePrefab = (GameObject)EditorGUILayout.ObjectField("Projectile Prefab", turret.projectilePrefab, typeof(GameObject), false);
            turret.firePoint = (Transform)EditorGUILayout.ObjectField("Fire Point", turret.firePoint, typeof(Transform), true);
            turret.rotatingPart = (Transform)EditorGUILayout.ObjectField("Rotating Part", turret.rotatingPart, typeof(Transform), true);
        }

        // Unity Setup Fields (common to both turrets)
        EditorGUILayout.LabelField("Unity Setup Fields", EditorStyles.boldLabel);
        turret.enemyTag = EditorGUILayout.TextField("Enemy Tag", turret.enemyTag);

        // Apply changes to the serialized object
        if (GUI.changed)
        {
            EditorUtility.SetDirty(turret);
        }

        // Make sure to call base.OnInspectorGUI() if you need to display other default properties
        base.OnInspectorGUI();
    }
}
