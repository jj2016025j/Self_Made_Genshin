using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class mousemanager : MonoBehaviour
{
    public static mousemanager Instance;
    public RaycastHit hitInfo;
    public Texture2D a, b, c, d, e;
    public event Action<Vector3> OnMouseClicked;
    public event Action<GameObject> OnEnemyClicked;
    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        Instance = this;
    }

    private void Update()
    {
        SetCursorTexture();
        MouseControl();
    }
    void SetCursorTexture()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo))
        {
            //切換鼠標貼圖
            switch (hitInfo.collider.gameObject.tag)
            {
                case "Untagged":
                    Cursor.SetCursor(c, new Vector2(16,16), CursorMode.Auto);
                    break;
                case "Ground":
                    Cursor.SetCursor(a, new Vector2(16,16), CursorMode.Auto);
                    break;
                case "Enemy":
                    Cursor.SetCursor(b, new Vector2(16,16), CursorMode.Auto);
                    break;
            }
        }
    }
    
    void MouseControl()//之後要複習
    {
        if(Input.GetMouseButtonDown(0)&&hitInfo.collider!=null)
        {
            if (hitInfo.collider.gameObject.CompareTag("Ground"))
            {
                OnMouseClicked?.Invoke(hitInfo.point);
            }
            if (hitInfo.collider.gameObject.CompareTag("Enemy"))
            {
                OnEnemyClicked?.Invoke(hitInfo.collider.gameObject);
            }
        }
    }
}
    
