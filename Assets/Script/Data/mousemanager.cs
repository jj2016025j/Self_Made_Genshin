using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//using UnityEngine.Events;[System.Serializable ] public class EventVector3 : UnityEvent<Vector3>{public EventVector3 OnMouseClicked;}

public class mousemanager : MonoBehaviour
{
    public static mousemanager Instance;
    public RaycastHit hitInfo;
    public event Action<Vector3> OnMouseClicked;
    public Texture2D a, b, c, d, e;
    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        Instance = this;
        Debug.Log(Instance);
    }

    private void Update()
    {
        SetCursorTesture();
        MouseControl();
    }
    void SetCursorTesture()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo))
        {
            //切換鼠標貼圖
            switch (hitInfo.collider.gameObject.tag)
            {
                case "Ground":
                    Cursor.SetCursor(a, new Vector2(16,16), CursorMode.Auto);
                    break;
            }
        }
    }
    
    void MouseControl()
    {
        if(Input.GetMouseButtonDown(0)&&hitInfo.collider!=null)
        {
            if (hitInfo.collider.gameObject.CompareTag("Ground"))
            {
                OnMouseClicked?.Invoke(hitInfo.point);
            }
        }
    }
}
    
