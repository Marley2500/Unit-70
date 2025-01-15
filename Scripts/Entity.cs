using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    private NavMeshAgent agent;

    public TMP_Text healthText;
    public float health = 100;
    public Image xpBar;
    public float xp = 0;
    private float maxXp = 100;
    public TMP_Text lvlText;
    public int lvl = 1;
    public LevelUp levelUp;
    public float regen;
    private float xpMultiplier;
    public EnemySpawner spawner;
    public GameObject gameOver;
    public TMP_Text goldText;
    public int gold = 0;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        xpBar.fillAmount = 0;
        Invoke(nameof(HealthRegen), 1f);

        xpMultiplier = 1;
        regen = 0;
    }

    public void ModifyXP()
    {
        xp += 10f * xpMultiplier;

        if (xp >= maxXp)
        {
            levelUp.LevelUpFunc();
            ModifyHealth(10);
            ModifySpeed(0.5f);
            ModifyLevel();
            xp = 0;
            maxXp = maxXp * 1.1f;
        }

        xpBar.fillAmount = xp / maxXp;

    }

    public void UpdateUI()
    {
        goldText.text = "GOLD: " + gold;
        healthText.text = "HEALTH: " + health;
        lvlText.text = "Lvl: " + lvl;
    }

    public void ModifyGold(int increaseAmount)
    {
        gold = gold + 1;
        UpdateUI();
    }

    public void ModifyHealth(float increaseAmount)
    {
        health = health + increaseAmount;
        UpdateUI();
    }

    public void ModifySpeed(float increaseAmount)
    {
        agent.speed = agent.speed + increaseAmount;
    }

    public void ModifyLevel()
    {
        if (xp >= maxXp)
        {
            lvl += 1;
            UpdateUI();
        }

        if (lvl == 3 || lvl == 5)
        {
            spawner.EnemyScale();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateUI();

        if (health <= 0)
        {
            Death();
        }

    }

    public void Death()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void ResetSpeed()
    {
        agent.speed = agent.speed - 4;
    }

    public void InvokeResetSpeed()
    {
        Invoke(nameof(ResetSpeed), 3f);
    }

    //Item Functions//
    private void HealthRegen()
    {
        Invoke(nameof(HealthRegen), 1f);
        health = health + regen;
        healthText.text = "HEALTH: " + health;
    }
    public void SpeedBoost()
    {
        agent.speed = agent.speed + 1;
    }
    public void ExpGain()
    {
        xpMultiplier = xpMultiplier + 1;
    }
}

