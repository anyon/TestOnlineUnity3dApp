using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class SaveShapesToJson : MonoBehaviour
{
    private ShapeSO[] shapes;

    [System.Serializable]
    public struct ShapeInstanceData
    {
        public string shapeName;
        public Vector3 position;
        public Quaternion rotation;
        public Color color;
    }

    public void SaveShapes()
    {
        GameObject[] shapeInstances = GameObject.FindGameObjectsWithTag("Shape");
        List<ShapeInstanceData> shapeDataArray = new List<ShapeInstanceData>();
        foreach (GameObject shapeInstance in shapeInstances)
        {
            Shape shape = shapeInstance.GetComponent<Shape>();
            if (shape != null) 
            {
                ShapeInstanceData data = new ShapeInstanceData();
                data.shapeName = shape.shapeData.name;
                data.position = shapeInstance.transform.position;
                data.rotation = shapeInstance.transform.rotation;
                data.color = shape.shapeData.shapeColor;
                shapeDataArray.Add(data);
            }
        }

        string jsonArray = JsonUtils.ToJson<ShapeInstanceData>(shapeDataArray.ToArray(), true);

        File.WriteAllText(Application.persistentDataPath + "/shapes.json", jsonArray);

        Debug.Log(Application.persistentDataPath + "/shapes.json");
    }
}

