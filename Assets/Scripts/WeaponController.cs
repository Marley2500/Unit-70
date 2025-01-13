using UnityEngine;

public class WeaponController : MonoBehaviour
{
    EnemyController enemyController;
    public int damage;
    public GameObject wepPanel;
    public Animator wepAnim;

    private void Start()
    {
        wepAnim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyController = other.GetComponent<EnemyController>();
            enemyController.TakeDamage(damage);
        }

    }

    public void AddTempBoost()
    {
        wepAnim.SetFloat("Multiplier", wepAnim.GetFloat("Multiplier") +1.0f);
        Invoke(nameof(RemoveTempBoost), 3);
    }

    private void RemoveTempBoost()
    {
        wepAnim.SetFloat("Multiplier", wepAnim.GetFloat("Multiplier") - 1.0f);
    }


    //Item Functions//
    public void DamageBoost()
    {
        damage = damage * 2;
    }
    public void WeaponSpeed()
    {
        wepAnim.SetFloat("Multiplier", wepAnim.GetFloat("Multiplier") + 0.2f);
    }
}
