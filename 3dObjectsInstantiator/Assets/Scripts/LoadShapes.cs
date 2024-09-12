using System.IO;
using UnityEngine;
using UnityEditor;
using static UnityEditor.VersionControl.Asset;
using System;

public class LoadShapesFromJson : MonoBehaviour
{
    [SerializeField]
    private ShapeSO[] shapes;

    [Serializable]
    public struct ShapeInstanceData
    {
        public string shapeName;
        public Vector3 position;
        public Quaternion rotation;
        public Color color;
    }

    public void RestoreShapes()
    {

        string path = Application.persistentDataPath + "/shapes.json";
        if (File.Exists(path))
        {
            string jsonArray = File.ReadAllText(path);

            ShapeInstanceData[] jsonArrayData = JsonUtils.FromJson<ShapeInstanceData>(jsonArray);

            foreach (ShapeInstanceData data in jsonArrayData)
            {
                ShapeSO shapeData = FindShapeDataByName(data.shapeName);

                if (shapeData != null)
                {
                    GameObject shapeInstance = Instantiate(shapeData.shapePrefab, data.position, data.rotation);

                    Shape shapeObj = shapeInstance.GetComponent<Shape>();
                    shapeObj.shapeData = shapeData;
                    ShapeMover mover = shapeInstance.GetComponent<ShapeMover>();
                    mover.StopMoving();
                    shapeObj.UpdateShapeColor(shapeData.shapeColor);
                }
                else
                {
                    Debug.LogWarning($"No matching ShapeSO found for shape: {data.shapeName}");
                }
            }

            Debug.Log("Shapes restored from: " + path);
        }
        else
        {
            Debug.LogWarning("No saved shapes found.");
        }
    }

    private ShapeSO FindShapeDataByName(string shapeName)
    {
        foreach (ShapeSO shapeSO in shapes)
        {
            if (shapeSO.name == shapeName)
            {
                return shapeSO;
            }
        }
        return null; // Return null if no matching shape is found
    }
}

