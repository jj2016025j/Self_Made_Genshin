using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float ms = 1;
    [SerializeField] float hp = 10;
    [SerializeField] float scoretime = 0;
    [SerializeField] float score = 0;
    [SerializeField] GameObject scoreboss;
    [SerializeField] Text scoretext;
    [SerializeField] GameObject currentfloor;
    void Start()
    {
        Debug.Log(ms);
        hp = 10;
        score = 0; 
        scoretime = 0;
        scoretext.text="分數0分";
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        updatescore();
        HPUI();

    }
    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        transform.Translate(x * ms * Time.deltaTime, 0, 0);
        float y = Input.GetAxis("Vertical");
        transform.Translate(0, y * ms * Time.deltaTime, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor1")
        {
            if (collision.contacts[0].normal == new Vector2(0f, 1f))
            {
                currentfloor = collision.gameObject;
                Debug.Log("著地");
                HPmodify(1);
            }
            if (collision.contacts[0].normal != new Vector2(0f, 1f))
            {
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else if (collision.gameObject.tag == "ceiling")
        {
            currentfloor.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("天花板");
            HPmodify(-3);
        }
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "gameover")
        {
            bool stopfollow = true;
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        }
    }
    void HPmodify(int num)
    {
        hp += num;
        if (hp > 10)
        {
            hp = 10;
        }
        if (hp <= 0)
        {
            hp = 0;
        }
    }
    void HPUI()
    {
        for(int i = 0; i<= scoreboss.transform.childCount; i++)
        {
            if (hp > i)
            {
                scoreboss.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                scoreboss.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    void updatescore()
    {
        scoretime += Time.deltaTime;
        if (scoretime > 2f)
        {
            score++;
            scoretext.text = "分數"+ score +"分";
            scoretime = 0;
        }
    }
}
