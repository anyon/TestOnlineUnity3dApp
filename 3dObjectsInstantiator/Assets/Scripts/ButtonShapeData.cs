using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonShapeData : MonoBehaviour
{
    [SerializeField]
    private ShapeSO shape;

    [SerializeField]
    private TMP_Text text;

    private Camera cameraMain;

    private void Start()
    {
        cameraMain = Camera.main;
    }

    public void UpdateButtonShapeData(ShapeSO shape)
    {
        this.shape = shape;
        text.text = shape.name;
        text.color = shape.shapeColor;
    }

    public void OnButtonClicked()
    {
        Vector3 cursorPos = Input.mousePosition;

        cursorPos.z = 10f;

        Vector3 worldPosition = cameraMain.ScreenToWorldPoint(cursorPos);

        GameObject shapePrefab = shape.shapePrefab;
        GameObject shapeGO = Instantiate(shapePrefab, worldPosition, Quaternion.identity);
        Shape shapeData = shapeGO.GetComponent<Shape>();
        shapeData.shapeData = shape;
        shapeData.UpdateShapeColor(shape.shapeColor);
    }
}
