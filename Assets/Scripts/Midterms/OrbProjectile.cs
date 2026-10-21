using System.Collections.Generic;
using UnityEngine;

public class OrbProjectile : MonoBehaviour
{
    public float speed = 7f;
    public float lifeTime = 3f;
    public float damage = 7f;
    public float hitRadius = 0.5f;
    public Vector3 direction;
    public bool isPiercing;

    float lifeTimer;
    List<Enemy> hitEnemies = new List<Enemy>();

    void OnEnable()
    {
        lifeTimer = 0f;
        isPiercing = false;
        hitEnemies.Clear();
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        lifeTimer += Time.deltaTime;

        if (lifeTimer > lifeTime)
        {
            Pooling.Despawn(gameObject);
        }

        for (int i = 0; i < EnemyMastermind.allEnemies.Count; i++)
        {
            Enemy currentEnemy = EnemyMastermind.allEnemies[i];

            Vector3 orbFlat = new Vector3(transform.position.x, 0f, transform.position.z);
            Vector3 enemyFlat = new Vector3(currentEnemy.transform.position.x, 0f, currentEnemy.transform.position.z);
            float distance = Vector3.Distance(orbFlat, enemyFlat);

            if (distance <= hitRadius + currentEnemy.radius)
            {
                if (isPiercing)
                {
                    if (hitEnemies.Contains(currentEnemy) == false)
                    {
                        currentEnemy.TakeDamage(damage);
                        hitEnemies.Add(currentEnemy);
                    }
                }
                else
                {
                    currentEnemy.TakeDamage(damage);
                    Pooling.Despawn(gameObject);
                }
            }
        }
    }
}