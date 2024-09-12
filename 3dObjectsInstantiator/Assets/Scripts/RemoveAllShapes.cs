using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAllShapes : MonoBehaviour
{
    public void DeleteAllShapes()
    {
        GameObject[] shapeInstances = GameObject.FindGameObjectsWithTag("Shape");
        foreach (GameObject shapeInstance in shapeInstances)
        {
            Destroy(shapeInstance);
        }
    }
}
