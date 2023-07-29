using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class trigger : MonoBehaviour
{
	public int istriggeer;
	public Text text, yes;//視窗文字
	public Canvas canvas;//視窗
	public int transfer;//傳送門種類
	public Button onClick;
	public Rigidbody write,black;
	void Start()
	{
		if (GameObject.Find("question"))
		{
			canvas = GameObject.Find("Canvas").GetComponent<Canvas>();//畫布
		}
		if (GameObject.Find("question").GetComponent<Text>())
		{
			text = GameObject.Find("question").GetComponent<Text>();//問題
		}
		if (GameObject.Find("yes").GetComponent<Text>())
		{
			yes = GameObject.Find("yes").GetComponent<Text>();//確認按鈕
		}
		if (GameObject.Find("write").GetComponent<Rigidbody>())//生成腳色
		{
			write = GameObject.Find("write").GetComponent<Rigidbody>();
		}
	}
	void Update()
	{

	}
	void OnTriggerEnter(Collider other)
	{
		Debug.Log("OnTriggerEnter");
		if (istriggeer == 0)
		{
			istriggeer = 1;
			Debug.Log("istriggeer = 1;");
			Transfer();
		}
	}
	void OnTriggerExit(Collider other)
	{
		Debug.Log("OnTriggerExit");
		if (istriggeer == 1)
		{
			istriggeer = 0;
			Debug.Log("istriggeer = 0;");
			canvas.enabled = false;//關閉視窗
		}
	}
	public void Transfer()
	{
		Debug.Log("trigger");
		transfer = 1;
		switch (transfer)
		{
			case 1://野外傳送門wild portal
				canvas.enabled = true;//開啟視窗
				text.text = "是否傳送到野外";
				yes.text = "傳送到野外";
				Debug.Log("是否傳送到野外");
				break;
			case 2://對戰傳送門battle portal
				canvas.enabled = true;//開啟視窗
				text.text = "是否傳送到對戰場地";
				yes.text = "傳送到對戰場地";
				Debug.Log("是否傳送到對戰場地");
				break;
			case 3://練習場傳送門driving range portal
				canvas.enabled = true;//開啟視窗
				text.text = "是否傳送到練習場";
				yes.text = "傳送到練習場";
				Debug.Log("是否傳送到練習場");
				break;
		}
	}
	public void wildportal()//傳送到野外
	{
		Debug.Log("已傳送到野外");
		SceneManager.LoadScene("1");//切換場景
	}
	public void battleportal()//傳送到對戰場地
	{
		Debug.Log("已傳送到對戰場地");
		SceneManager.LoadScene("2");//切換場景
	}
	public void drivingrangeportal()//傳送到練習場
	{
		Debug.Log("已傳送到練習場");
		SceneManager.LoadScene("3");//切換場景
	}
	public void turnoffcanvas()
	{
		canvas.enabled = false;
		Debug.Log("已關閉視窗");
	}
	public void resetscene()
	{
		Application.LoadLevel(Application.loadedLevel);//重製場景
	}
	public GameObject c;
	public Vector3 a;
	public Quaternion b;
	public void choose()//選擇腳色
    {
		if (GameObject.Find("write").GetComponent<BoxCollider>())//生成腳色
		{
			c = GameObject.Find("write").GetComponent<BoxCollider>();
			Debug.Log("生成新物件");
			a = gameObject.transform.position+vector3(0,10,0);//生成位置
			Instantiate(c, a, b);//生成
		}
	}
}
