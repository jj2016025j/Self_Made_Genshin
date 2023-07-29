using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class uiManager:MonoBehaviour
{
    private static uiManager instance;
    public static uiManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new uiManager();
            }
            return instance;
        }
    }
    public characterStats own;
    public GameObject field;
    public GameObject Parent;
    public List<float> AbilityPointList = new List<float>();
    public bag bag;
    public GameObject itemUI;//inclub:image,text
    public void Start()
    {
        //AbilityPointUIinfo(own, field, Parent);
        ShowItem(bag, itemUI, Parent);
    }
    public void AbilityPointUIinfo(characterStats characterStats, GameObject field, GameObject Parent)
    {
        AbilityPointList.Add(characterStats.Constitution);
        AbilityPointList.Add(characterStats.Intelligence);
        AbilityPointList.Add(characterStats.Induction);
        AbilityPointList.Add(characterStats.Focus);
        AbilityPointList.Add(characterStats.Dexterity);
        AbilityPointList.Add(characterStats.luck);
        for(int i = 0; i < Parent.transform.childCount; i++){
            Destroy( Parent.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < AbilityPointList.Count; i++)
        {
            GameObject InfoUI = Instantiate(field);
            InfoUI.transform.SetParent(Parent.transform);
            InfoUI.transform.GetChild(0).GetComponent<Text>().text = AbilityPointList[i].ToString();
        }
        NumericalValueUIinfo(own, field, Parent);
    }
    public void NumericalValueUIinfo(characterStats characterStats, GameObject field, GameObject Parent)
    {
        AbilityPointList.Add(characterStats.maxHealth);
        AbilityPointList.Add(characterStats.health);
        AbilityPointList.Add(characterStats.defense);
        AbilityPointList.Add(characterStats.magicDefense);
        AbilityPointList.Add(characterStats.toughness);
        AbilityPointList.Add(characterStats.attack);
        AbilityPointList.Add(characterStats.load);
        AbilityPointList.Add(characterStats.volume);
        AbilityPointList.Add(characterStats.maxEnergy);
        AbilityPointList.Add(characterStats.energy);
        AbilityPointList.Add(characterStats.magicAttack);
        AbilityPointList.Add(characterStats.maxMagicPoint);
        AbilityPointList.Add(characterStats.magicPoint);
        AbilityPointList.Add(characterStats.coolDown);
        AbilityPointList.Add(characterStats.healthRestore);
        AbilityPointList.Add(characterStats.magicPointRestore);
        AbilityPointList.Add(characterStats.energyRestore);
        AbilityPointList.Add(characterStats.draw);
        AbilityPointList.Add(characterStats.criticalMultiplier);
        AbilityPointList.Add(characterStats.deadTime);
        AbilityPointList.Add(characterStats.criticalChance);
        AbilityPointList.Add(characterStats.speed);
        AbilityPointList.Add(characterStats.attackSpeed);
        for (int i = 0; i < AbilityPointList.Count; i++)
        {
            GameObject InfoUI = Instantiate(field);
            InfoUI.transform.SetParent(Parent.transform);
            InfoUI.transform.GetChild(0).GetComponent<Text>().text = AbilityPointList[i].ToString();
        }
    }
    public void ShowItem(bag bag, GameObject item, GameObject Parent)
    {
        for (int i = 0; i < Parent.transform.childCount; i++)
        {
            Destroy(Parent.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < bag.itemsList.Count; i++)
        {
            GameObject itemUI = Instantiate(item);
            itemUI.GetComponent<Image>().sprite = bag.itemsList[i].itemImage;
            itemUI.transform.GetChild(0).GetComponent<Text>().text = bag.itemsList[i].itemName;
            itemUI.transform.GetChild(1).GetComponent<Text>().text = bag.itemsList[i].itemAmount.ToString();
        }
    }
}