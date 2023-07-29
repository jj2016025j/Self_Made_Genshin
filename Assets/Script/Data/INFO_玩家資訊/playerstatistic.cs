using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerstatistic : MonoBehaviour
{
    public int Hp;
    public double Hpreply;
    public int Mp;
    public double Mpreply;
    public int Damage;
    public int Defence;
    public int Speed;
    public double Attackspeed;

    public int Sp;
    public string Playerteam;
    //public 
    public Vector3 spwan;
    public playerstatistic(int hp, double hpreply, int mp, double mpreply, int damage, int defence, int speed, double attackspeed, int sp)
    {
        Hp = hp;
        Hpreply = hpreply;
        Mp = mp;
        Mpreply = mpreply;
        Damage = damage;
        Defence = defence;
        Speed = speed;
        Attackspeed = attackspeed;

        Sp = sp;
    }
    
    public playerstatistic()
    {
    }

    void Start()
    {
        player ready = new player(100, 0.01, 100, 0.01, 10, 10, 100, 1, 10);
        player unemployed = new player(100,0.01,100,0.01,10,10,100,1,10);
        player mage = new player(90, 0.01, 200, 0.01, 10, 10, 100, 1, 10);
        player warrior = new player(150, 0.01, 100, 0.01, 15, 15, 120, 1.5, 10);
        player healer = new player(80, 0.01, 150, 0.01, 6, 8, 80, 0.8, 10);
        player assassir = new player(100, 0.01, 120, 0.01, 20, 10, 150, 2, 10);
        player archer = new player(90, 0.01, 120, 0.01, 10, 10, 100, 1.5, 10);
        player tank= new player(200, 0.01, 100, 0.01, 8, 20, 80, 0.8, 10);

        
    }
    void Onclick()
    {

    }
        /*void Start()
            {
            Hp=100;
            Hpreply =0.01f;
            Mp = 100;
            Mpreply = 0.01f;
            Damage = 10;
            Walkpeed = 100;
            Runspeed = Walkpeed*2;
            Attackspeed = 1;

            Hp = Random.Range(Hp - (Hp / 2), Hp + (Hp / 2));
            Hpreply = Random.Range(Hpreply - (Hpreply / 2), Hpreply + (Hpreply / 2));
            Mp = Random.Range(Mp - (Mp / 2), Mp + (Mp / 2));
            Mpreply = Random.Range(Mpreply - (Mpreply / 2), Mpreply + (Mpreply / 2));
            Damage = Random.Range(Damage - (Damage / 2), Damage + (Damage / 2));
            Walkpeed = Random.Range(Walkpeed - (Walkpeed / 2), Walkpeed + (Walkpeed / 2));
            Runspeed = Random.Range(Runspeed - (Runspeed / 2), Runspeed + (Runspeed / 2));
            Attackspeed = Random.Range(Attackspeed - (Attackspeed / 2), Attackspeed + (Attackspeed / 2));
        }*/
        private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S))
        {

        }
        if (Hp < 0)
        {
            death();
        }

    }
    public void transcamera()
    {

    }
    public void Walk()
    {

    }
    public void Run()
    {

    }
    public void jump()
    {

    }
    public void Normalattack()
    {

    }
    public void skill()
    {

    }
    public void death()
    {

    }
    public void spawn()
    {
        transform.position=new Vector3(0,0,0);
        gameObject.transform.position = new Vector3(0, 0, 0);
        Animation spawna;

        spawna = GetComponent<Animation>();
    }
    public void track()
    {

    }
    public void Find()
    {
        /*
        Healer
        Tank
        Ad
        Ap
        
        */
    }
    public void team()
    {
        switch (Playerteam)
        {
            case "A":
                gameObject.tag = "Ateam";
                break;
            case "B":
                gameObject.tag = "Bteam";
                break;
            case "C":
                gameObject.tag = "Cteam";
                break;
            case "D":
                gameObject.tag = "D team";
                break;
        }
    }
}
