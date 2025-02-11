using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health, speed, damage;
    private GameObject player;
    public GameObject expObj;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.tag = "Enemy";
        InvokeRepeating(nameof(Movement), 0, (1 / System.Convert.ToSingle(Screen.currentResolution.refreshRateRatio.value)));
    }

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z), 0.01f * speed);
    }

    private void Health()
    {
        if (health <= 0)
        {
            Instantiate(expObj, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Health();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Entity entity = other.GetComponent<Entity>();
            entity.TakeDamage(damage);
        }
    }

}
