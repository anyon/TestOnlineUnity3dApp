using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShapeMover : MonoBehaviour
{
    [SerializeField]
    private bool isMoving = true;

    [SerializeField]
    private Camera cameraMain;

    [SerializeField]
    private UnityAction onStopMoving;

    private void Start()
    {
       isMoving = true;
        SetMainCamera();
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            SetMainCamera();
            Vector3 cursorPos = Input.mousePosition;

            cursorPos.z = 10f;

            Vector3 worldPosition = cameraMain.ScreenToWorldPoint(cursorPos);

            transform.position = worldPosition;
        }
    }

    private void SetMainCamera()
    {
        if (cameraMain == null)
        {
            cameraMain = Camera.main;
        }
    }

    private void Update()
    {
        if (isMoving && Input.GetMouseButtonDown(1))
        {
            StopMoving();
        }
    }

    public void StopMoving()
    {
        isMoving = false;
        onStopMoving?.Invoke();
    }

    
}
