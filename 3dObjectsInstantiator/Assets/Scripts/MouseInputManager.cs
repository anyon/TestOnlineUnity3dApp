using System;
using UnityEngine;

public class MouseInputManager : MonoBehaviour
{
    public static event Action OnLeftClick;
    public static event Action OnRightClick;

    public static MouseInputManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            OnRightClick?.Invoke();
        }
    }

    public void ItemPlaced()
    {
        OnLeftClick?.Invoke();
    }
}
