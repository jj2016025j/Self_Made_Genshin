using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._3DMultiPlayerGame.Global.UI
{
    //負責顯示遊戲中的血量
    //即時獲取並更新血量
    public class WorldSpaceUI : MonoBehaviour
    {
        public UnityEngine.GameObject UnitUIWorldSpace;

        public Image HealthBarWorldSpace;

        public TextMeshProUGUI UnitNameWorldSpace;

        public TheObject Object;

        public void Update()
        {
            // rotate health bar to face the camera/player
            UnitUIWorldSpace.transform.LookAt(Camera.main.transform.position);
        }

        //Update
        public void UpdateUI()
        {
            // update health bar value
            UnitNameWorldSpace.text = name;
            HealthBarWorldSpace.fillAmount = Object.currentHealth / Object.maxHealth;

            // hide health bar if needed
            UnitUIWorldSpace.SetActive(HealthBarWorldSpace.fillAmount != 1);
        }
    }
}