using UnityEngine;

public class EnemyController : Controller
{
    private enum EnemyState
    {
        Idle,
        Patrol,
        Chase,
        Attack,
        Dead
    }

    private EnemyState currentState;

    private void Awake()
    {
        // 在Awake函数中，初始化敌人状态为Idle（待命）
        currentState = EnemyState.Idle;
        Debug.Log("敌人已经被初始化并处于待命状态");
    }

    private void Start()
    {
        // 在Start函数中，你可以做一些初始化工作，比如获取组件引用，设置初始位置等。
    }

    private void Update()
    {
        // 在Update函数中，根据当前的敌人状态来调用相应的行为函数。
        switch (currentState)
        {
            case EnemyState.Dead:
                Dead();
                break;
        }
    }

    // 敌人的待命行为
    private void Idle()
    {
        Debug.Log("敌人正在待命");
        // 实现敌人待命的行为，例如在原地看看四周
    }

    // 敌人的巡逻行为
    private void Patrol()
    {
        Debug.Log("敌人正在巡逻");
        // 实现敌人的巡逻行为，例如按照预设的路径行走
    }


    // 敌人的追击行为
    private void Chase()
    {
        Debug.Log("敌人正在追击玩家");
        // 实现敌人的追击行为，例如向玩家的位置移动
    }

    // 敌人的死亡行为
    private void Dead()
    {
        Debug.Log("敌人已死亡");
        // 实现敌人的死亡行为，例如播放死亡动画，然后销毁这个游戏对象
    }
}
