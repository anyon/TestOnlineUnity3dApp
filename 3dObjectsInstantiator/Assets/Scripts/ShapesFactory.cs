using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesFactory : MonoBehaviour
{
    [SerializeField]
    private ShapeSO[] shapes;

    [SerializeField]
    private GameObject buttonPrefab;

    private void Start()
    {
        PopulateShapesList();
    }

    private void PopulateShapesList()
    {
        foreach (ShapeSO shape in shapes)
        {
            GameObject newButton = Instantiate(buttonPrefab);
            ButtonShapeData btnShapeData = newButton.GetComponent<ButtonShapeData>();
            if(btnShapeData != null )
            {
                btnShapeData.UpdateButtonShapeData(shape);
            }
            newButton.transform.SetParent(transform, false);
        }
    }
}
