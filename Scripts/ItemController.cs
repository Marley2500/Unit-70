using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject[] itemList;
    public GameObject itemPanel;
    private GameObject randomItem;
    private WeaponController weaponController;
    private Entity entity;
    public GameObject[] weaponList;

    private void Start()
    {
        entity = GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>();
    }

    public void ItemSelect()
    {
        randomItem = itemList[Random.Range(0, itemList.Length)];
        randomItem.SetActive(true);
        itemPanel.SetActive(true);
        Time.timeScale = 0;

        weaponList = GameObject.FindGameObjectsWithTag("Weapon");
    }

    public void ChooseItem()
    {
        randomItem.SetActive(false);
        Time.timeScale = 1;
    }

    //Item Buttons//
    public void DamageButton()
    {
        for (int i = 0; i < weaponList.Length; i++)
        {
            weaponList[i].GetComponent<WeaponController>().DamageBoost();
        }
    }
    public void WeaponSpeed()
    {
        for (int i = 0; i < weaponList.Length; i++)
        {
            weaponList[i].GetComponent<WeaponController>().WeaponSpeed();
        }
    }
    public void RegenButton()
    {
        entity.regen = entity.regen + 1;
    }
    public void ExpButton()
    {
        entity.ExpGain();
    }
    public void SpeedButton()
    {
        entity.SpeedBoost();
    }
}
