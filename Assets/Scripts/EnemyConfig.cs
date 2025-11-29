using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = 
    "Enemy/EnemyConfig", order = 1)]
public class EnemyConfig : ScriptableObject
{
    [Range(0, 20)]
    public float speed;
    public Color color;
}
