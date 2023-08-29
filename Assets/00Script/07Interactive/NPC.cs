using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    public string NPCName;
    
    protected virtual void MoveTo(Vector3 destination) { /* 移動邏輯 */ }
    protected virtual void InteractWithPlayer(Player player) { /* 與玩家互動邏輯 */ }
}

public class Businessman : NPC
{
    public Transform shopFront; // 商店前的位置

    protected override void MoveTo(Vector3 destination)
    {
        // 商人移動邏輯
    }

    public void PatrolShop()
    {
        MoveTo(shopFront.position);
    }

    public void AdvertiseToPassingPlayer(Player player)
    {
        if (/* 檢測到玩家經過 */) 
        {
            InteractWithPlayer(player);
        }
    }

    protected override void InteractWithPlayer(Player player)
    {
        // 與玩家推銷商品的邏輯
    }

    public void TradeWithWeaponDealer(WeaponDealer dealer) { /* 與武器商交易邏輯 */ }
    public void TradeWithMaterialVendor(MaterialVendor vendor) { /* 與素材商交易邏輯 */ }
    public void DiscussPriceWithAdventurer(Adventurer adventurer) { /* 討論價格邏輯 */ }
    public void TradeWithChef(Chef chef) { /* 與食堂進行食材交易的邏輯 */ }
}

public class WeaponDealer : NPC
{
    public Transform forgePosition; // 鍛造間位置
    public Transform displayPosition; // 展示武器位置

    public void WorkAtForge()
    {
        MoveTo(forgePosition.position);
        // 播放鍛造動畫
    }

    public void DisplayNewWeapon()
    {
        MoveTo(displayPosition.position);
        // 展示武器邏輯
    }

    public void PurchaseMaterialsFromVendor(MaterialVendor vendor) { /* 購買材料邏輯 */ }
    public void ProvideEquipmentToAdventurer(Adventurer adventurer) { /* 提供裝備邏輯 */ }
}

// ... 其他NPC的腳本，模仿上述結構
