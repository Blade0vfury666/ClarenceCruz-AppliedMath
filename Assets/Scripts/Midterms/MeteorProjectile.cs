using UnityEngine;

public class MeteorProjectile : MonoBehaviour
{
    public GameObject explosionPrefab;
    public Vector3 direction;
    public float speed = 30f;
    public float damage = 30f;
    public float explosionRadius = 4f;

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (transform.position.y <= 0f)
        {
            Pooling.Spawn(explosionPrefab, transform.position, Quaternion.identity);
            SoundManager.instance.PlayExplosion();

            for (int i = 0; i < EnemyMastermind.allEnemies.Count; i++)
            {
                Enemy currentEnemy = EnemyMastermind.allEnemies[i];

                float distance = Vector3.Distance(transform.position, currentEnemy.transform.position);

                if (distance <= explosionRadius)
                {
                    currentEnemy.TakeDamage(damage);
                }
            }

            Pooling.Despawn(gameObject);
        }
    }
}