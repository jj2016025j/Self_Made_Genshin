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
        anim = GetComponent<Animator>();//�]anim��������<Animator>
        rb = GetComponent<Rigidbody>();//�]rb��������<Rigidbody>
    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");//���o�B�I��=����
        float vertical = Input.GetAxis("Vertical");//���o�B�I��=����

        movement.Set(horizontal, 0f, vertical);//�]�wmovement���T��
        movement.Normalize();//�ݤ���
        

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);//()�O�����Ȥ��O�j���۵�
        bool hasverticaInput = !Mathf.Approximately(vertical, 0f);

        bool iswalking = hasHorizontalInput || hasverticaInput;//�䤤�@�ӬOture��
        anim.SetBool("iswalking", iswalking);//�ʵe�W�� bool�� �O�_����

        Vector3 rotateDirection = Vector3.RotateTowards(transform.forward, movement, rotatespeed * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(rotateDirection);
    }
    private void OnAnimatorMove()
    {
        rb.MovePosition(rb.position + movement * anim.deltaPosition.magnitude);
        rb.MoveRotation(rotation);
    }
}
