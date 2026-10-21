using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float attackRadius = 10f;
    public float fireRate = 2f;

    Transform player;
    float fireTimer;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (Vector3.Distance(transform.position, player.position) <= attackRadius)
        {
            if (fireTimer >= fireRate)
            {
                fireTimer = 0f;
                Vector3 shootDirection = (player.position - transform.position).normalized;

                GameObject proj = Pooling.Spawn(projectilePrefab, transform.position, Quaternion.identity);
                proj.GetComponent<EnemyProjectile>().direction = shootDirection;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}