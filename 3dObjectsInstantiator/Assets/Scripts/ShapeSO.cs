using UnityEngine;

[CreateAssetMenu(fileName = "New Shape", menuName = "Shapes/ShapeSO")]
public class ShapeSO : ScriptableObject
{
    public string shapeName;
    public GameObject shapePrefab;
    public Color shapeColor;
    public Vector3 defaultPosition;
    public Vector3 defaultRotation;
}
