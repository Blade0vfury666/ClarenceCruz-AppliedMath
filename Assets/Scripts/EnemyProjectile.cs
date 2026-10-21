using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 10f;
    public float damage = 5f;
    public float hitRadius = 0.5f;
    public float lifeTime = 3f;

    GameObject player;
    float lifeTimer;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnEnable()
    {
        lifeTimer = 0f;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        lifeTimer += Time.deltaTime;

        if (Vector3.Distance(transform.position, player.transform.position) <= hitRadius)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(damage);
            Pooling.Despawn(gameObject);
        }
        else if (lifeTimer >= lifeTime)
        {
            Pooling.Despawn(gameObject);
        }
    }
}