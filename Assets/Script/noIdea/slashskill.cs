using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slashskill : MonoBehaviour//模擬揮砍
{
    float time_f;
    int time_i;
    public GameObject player;
    private void Start()
    {
        player = gameObject.transform.parent.gameObject;
        transform.parent = null;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //manager.attacksomeone(player, collision.gameObject);
            Destroy(gameObject);
        }
    }
    void Update()
    {
        time_f += Time.deltaTime;
        time_i = Mathf.FloorToInt(time_f);
        if (time_i >= 0.1)
        {
            Destroy(gameObject);
        }
    }
}
