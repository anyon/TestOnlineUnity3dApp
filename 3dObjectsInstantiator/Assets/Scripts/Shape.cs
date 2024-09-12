using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{

    public ShapeSO shapeData;

    public void UpdateShapeColor (Color color)
    {
        Renderer cubeRenderer = this.GetComponent<Renderer>();
        if (cubeRenderer != null)
        {
            cubeRenderer.material.color = color; 
        }
        else
        {
            Debug.LogWarning("No Renderer found on the cube.");
        }
    }

}
