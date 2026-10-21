using System.Collections.Generic;
using UnityEngine;

public class EnemyMastermind : MonoBehaviour
{
    public static List<Enemy> allEnemies = new List<Enemy>();

    public Transform player;
    public PlayerHealth playerHealth;

    void Update()
    {
        for (int i = 0; i < allEnemies.Count; i++)
        {
            Enemy currentEnemy = allEnemies[i];

            if (Vector3.Distance(currentEnemy.transform.position, player.position) > currentEnemy.radius)
            {
                Vector3 direction = (player.position - currentEnemy.transform.position).normalized;
                currentEnemy.transform.position += direction * currentEnemy.speed * Time.deltaTime;
            }
            else
            {
                playerHealth.TakeDamage(currentEnemy.damage * Time.deltaTime);
            }
        }
    }
}