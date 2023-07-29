using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    }

    private void Update()
    {
        SetCursorTesture();
        MouseControl();
    }
    void SetCursorTesture()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//從螢幕點擊處發射一條射線
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
            if (hitInfo.collider.gameObject.CompareTag("Ground"))//如果射線碰到物體
            {
                OnMouseClicked?.Invoke(hitInfo.point);
            }
        }
    }
}
public class cusor : MonoBehaviour//切換鼠標嗎我不確定
{
    public Texture texture;
    public float vectorx;
    public float vectory;
    public Vector3 mousePos;
    public Vector3 startvecter;
    void Start()
    {
        
    }
    void Update()
    {
        //Screen.ShowCursor = false; //關閉鼠標 之後再找
    }
    private void OnGUI()
    {
        vectorx = Input.mousePosition.x;
        vectory = Input.mousePosition.y;
        GUI.DrawTexture(Rect(vectorx - 15, -vectory - 15 + Screen.height, 30, 30), texture);
        mousePos = Input.mousePosition;
        startvecter =new Vector3(mousePos.x / Screen.width, mousePos.y / Screen.height, 0);
    }

    private Rect Rect(float v1, float v2, int v3, int v4)
    {
        throw new NotImplementedException();
    }
}