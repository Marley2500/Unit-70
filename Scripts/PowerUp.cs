using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpBase[] powerUpBase;
    public PowerUpBase selectedPowerUp;
    public PowerUps powerUpType;
    public float value;
    public GameObject[] weaponList;
    private ItemController itemController;
    Entity entity;

    private void Awake()
    {
        entity = GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>();

        int chance = Random.Range(0, 99);


        if (chance <= 2.5)
        {
            selectedPowerUp = powerUpBase[2];
            gameObject.GetComponent<Renderer>().material.color = new Color(1f, 0f, 1f);
        }
        else if (chance <= 95)
        {
            selectedPowerUp = powerUpBase[0];
        }
        else 
        {
            selectedPowerUp = powerUpBase[1];
            gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 0f);
        }


        powerUpType = selectedPowerUp.powerUps;
        value = selectedPowerUp.valueIncrease;

        weaponList = GameObject.FindGameObjectsWithTag("Weapon");
        itemController = GameObject.FindGameObjectWithTag("ItemController").GetComponent<ItemController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }

        Destroy(gameObject, 0.01f);

        switch (powerUpType)
        {
            case PowerUps.XP:
                entity.ModifyXP();
                entity.ModifyGold(1);
                break;

            case PowerUps.item:
                itemController.ItemSelect();
                break;

            case PowerUps.tempBoost:
                entity.ModifySpeed(value);
                entity.InvokeResetSpeed();
                for (int i = 0; i < weaponList.Length; i++)
                {
                    weaponList[i].GetComponent<WeaponController>().AddTempBoost();
                }
                break;

        }
    }


}
