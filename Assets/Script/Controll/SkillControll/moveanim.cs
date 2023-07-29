using UnityEngine;

public class moveanim : MonoBehaviour
{
    Vector3 movement;
    Animator anim;
    float rotatespeed = 20f;
    Quaternion rotation;
    Rigidbody rb;

    void Start()
    {
        anim = GetComponent<Animator>();//設anim維本身的<Animator>
        rb = GetComponent<Rigidbody>();//設rb維本身的<Rigidbody>
    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");//取得浮點數=水平
        float vertical = Input.GetAxis("Vertical");//取得浮點數=垂直

        movement.Set(horizontal, 0f, vertical);//設定movement的三圍
        movement.Normalize();//看不懂
        

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);//()是內的值不是大約相等
        bool hasverticaInput = !Mathf.Approximately(vertical, 0f);

        bool iswalking = hasHorizontalInput || hasverticaInput;//其中一個是ture嗎
        anim.SetBool("iswalking", iswalking);//動畫名稱 bool值 是否播放

        Vector3 rotateDirection = Vector3.RotateTowards(transform.forward, movement, rotatespeed * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(rotateDirection);
    }
    private void OnAnimatorMove()
    {
        rb.MovePosition(rb.position + movement * anim.deltaPosition.magnitude);
        rb.MoveRotation(rotation);
    }
}
