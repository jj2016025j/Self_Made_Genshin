using UnityEngine;

public class Rocket : MonoBehaviour
{

    public Transform target;               //跟蹤目標
    //  public GameObject FX;                  //爆炸特效
    public float moveSpeed;                //移動速度
    public float rotateSpeed;             //旋轉速度

    private void Start()
    {
        moveSpeed = 30;
        rotateSpeed = 50;
    }
    private void Update()
    {
        if (target != null)    //判斷當前是否有跟蹤目標 如果有的話 執行 以下跟蹤邏輯
        {

            transform.LookAt(target);

            Vector3 tempDirV = target.position - transform.position;                //計算出正確的轉向
            Quaternion rightDirQ = Quaternion.LookRotation(tempDirV);               //將轉向 轉化爲 四元數
            transform.rotation = Quaternion.Lerp(transform.rotation, rightDirQ, rotateSpeed);  //利用四元數插值方法 將方向賦給 transform.rotation
        }
        transform.position += transform.forward * moveSpeed * Time.deltaTime;      //向前移動
    }


    //當 有物體進入到 自己的觸發器時 調用一次
    private void OnTriggerEnter(Collider other)
    {
        //GameObject tempFX = Instantiate(FX, transform.position, transform.rotation);  //生成一個爆炸特效 並給予位置和旋轉信息
        Destroy(gameObject);      //銷燬自己
        //Destroy(tempFX, 1);       //等待 1秒 銷燬剛纔 創建生成的爆炸特效
        Debug.Log("Destroy");
    }
}