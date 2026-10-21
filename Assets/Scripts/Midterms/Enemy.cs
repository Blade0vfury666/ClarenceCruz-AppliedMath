using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;
    public float speed = 3f;
    public float damage = 10f;
    public float radius = 1f;
    public int xpAmount = 10;
    public Vector3 offset;

    void OnEnable()
    {
        health = maxHealth;
        EnemyMastermind.allEnemies.Add(this);
        offset = new Vector3(Random.Range(-2f, 2f), 0f, Random.Range(-2f, 2f));
    }

    void OnDisable()
    {
        EnemyMastermind.allEnemies.Remove(this);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            SoundManager.instance.PlayEnemyDeath();
            PlayerXP.playerXP.AddXP(xpAmount);
            Pooling.Despawn(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}