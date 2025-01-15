using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;

public class Shop : MonoBehaviour
{
    private GameObject player;
    public GameObject shop;
    public ItemController itemController;
    public Entity entity;
    private ItemCosts costs;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shop.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ShopItemPicked()
    {
        shop.SetActive(false);
        Time.timeScale = 1;
    }

    public void SetCost(BaseEventData data)
    {
        costs = data.selectedObject.GetComponent<ItemCosts>();    
    }

    public void ShopDamageButton()
    {
        if (entity.gold >= costs.cost)
        {
            entity.gold = entity.gold - costs.cost;
            itemController.DamageButton();
            entity.UpdateUI();
            costs.cost *= 2;
            costs.ButtonUpdate();
        }
    }
    public void ShopWeaponSpeed()
    {
        if (entity.gold >= costs.cost)
        {
            entity.gold = entity.gold - costs.cost;
            itemController.WeaponSpeed();
            entity.UpdateUI();
            costs.cost *= 2;
            costs.ButtonUpdate();
        }
    }
    public void ShopRegenButton()
    {
        if (entity.gold >= costs.cost)
        {
            entity.gold = entity.gold - costs.cost;
            itemController.RegenButton();
            entity.UpdateUI();
            costs.cost *= 2;
            costs.ButtonUpdate();
        }
    }
    public void ShopExpButton()
    {
        if (entity.gold >= costs.cost)
        {
            entity.gold = entity.gold - costs.cost;
            itemController.ExpButton();
            entity.UpdateUI();
            costs.cost *= 2;
            costs.ButtonUpdate();
        }
    }
    public void ShopSpeedButton()
    {
        if (entity.gold >= costs.cost)
        {
            entity.gold = entity.gold - costs.cost;
            itemController.SpeedButton();
            entity.UpdateUI();
            costs.cost *= 2;
            costs.ButtonUpdate();
        }
    }
}
