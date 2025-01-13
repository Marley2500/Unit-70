using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public Entity entity;
    public GameObject wepPanel;
    public GameObject flail;
    public GameObject fire;
    public GameObject boomerang;
    private Animator fireAnim;
    private Animator flailAnim;
    private Animator boomAnim;

    private void Start()
    {
        Time.timeScale = 0;
        wepPanel.SetActive(true);

        fireAnim = fire.GetComponent<Animator>();
        flailAnim = flail.GetComponent<Animator>();
        boomAnim = boomerang.GetComponent<Animator>();
    }

    public void LevelUpFunc()
    {
        Time.timeScale = 0;
        wepPanel.SetActive(true);
    }

    public void LevelUpFire()
    {
        if (!fire.activeInHierarchy)
        {
            SetWeaponActive(fire);
        }

        else
        {
            fireAnim.SetFloat("Multiplier", fireAnim.GetFloat("Multiplier") + 0.1f);
            wepPanel.SetActive(false);
            Time.timeScale = 1;
        }

    }

    public void LevelUpFlail()
    {
        if (!flail.activeInHierarchy)
        {
            SetWeaponActive(flail);
        }

        else
        {
            flailAnim.SetFloat("Multiplier", flailAnim.GetFloat("Multiplier") + 0.1f);
            wepPanel.SetActive(false);
            Time.timeScale = 1;
        }

    }

    public void LevelUpBoomerang()
    {
        if (!boomerang.activeInHierarchy)
        {
            SetWeaponActive(boomerang);
        }

        else
        {
            boomAnim.SetFloat("Multiplier", boomAnim.GetFloat("Multiplier") + 0.1f);
            wepPanel.SetActive(false);
            Time.timeScale = 1;
        }

    }

    public void SetWeaponActive(GameObject _obj)
    {
        _obj.SetActive(true);
        wepPanel.SetActive(false);
        Time.timeScale = 1;
    }

}
