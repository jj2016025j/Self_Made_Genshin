using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kewBehaviourScript : MonoBehaviour
{
	//腳色能力值
	public int str;//(strength)力量(物攻、血量、重量)
	public int vit;// (vitality)耐性(體質、體型、回復、防禦、感受、精神MEN(mentality))CON(Constitution)：體質
	public int dex;// (dexterity)敏捷(感知、精準、速度)AGI(Agility)：靈巧／靈敏度，常指迴避率
	public int INT;// (Intelligence)智力(魔攻、魔力
	public int luk;// (luck)幸運(爆擊、突發狀態、意外收穫)
	public int pst;// (prestige)聲望(各項權限、交易金額)
	
	public int HP;// (Health Point)血量			 = str * 10
	public int ATK;//(Attack)物理攻擊 			 = str * 1
	public int kg;//* 重量						 = str * 3
	public float vol;//volume*體型				 = str * 3%
	public float rec;//回復recover				 = vit * 1%
	public float recHP;//回復血量				 = rec * HP
	public int DEF;//(Defense)防禦				 = vit * 10
	public float Dmgrdc;//reduction傷害減免		 = 1 - 100 / ( 100 + DEF )
	public float aspd;//攻擊速度				 = dex * 10% * s
	public float mSPD;//(Speed)移動速度			 = dex * 10% * s
	public float prc;//精準precise				 = dex * 1%
	public int MP;//(Magic point) ／Mana* 魔力	 = INT * 10
	public float recMP;//回復魔力				 = ( rec * 0.5 + INT * 0.5 ) * MP
	public float CD;//CD(cool down)冷卻時間減免	 = INT * 1%
	public int MAG;//MATK魔法攻擊				 = INT * 1

	void Start()
	{
		HP = str * 10;
		ATK = str * 1;//(Attack)物理攻擊 			 = str * 1
		kg = str * 3;//* 重量						 = str * 3
		vol = str * 0.03f ;//volume*體型				 = str * 3%
		rec = vit * 0.01f;//回復recover				 = vit * 1%
		recHP = rec * HP;//回復血量				 = rec * HP
		DEF = vit * 1;//(Defense)防禦				 = vit * 1
		Dmgrdc = 1 - 100 / (100 + DEF);//reduction傷害減免		 = 1 - 100 / ( 100 + DEF )
		aspd = dex * 0.1f;//攻擊速度					 = dex * 10% * s
		mSPD = dex * 0.1f;//(Speed)移動速度			 = dex * 10% * s
		prc = dex * 0.01f;//精準precise				 = dex * 1%
		MP = INT * 10;//(Magic point) ／Mana* 魔力	 = INT * 10
		recMP = (rec * 0.5f + INT * 0.5f) * MP;//回復魔力				 = ( rec * 0.5 + INT * 0.5 ) * MP
		CD = INT * 0.01f;//CD(cool down)冷卻時間減免	 = INT * 1%
		MAG = INT * 1;//MATK魔法攻擊				 = INT * 1
	}

	// Update is called once per frame
	void Update()
	{
		if (str == 100)
		{
			str = 100;
		}
		if (HP < 0)
		{
			HP = 0;
		}
		Debug.Log(HP);
	}
}
