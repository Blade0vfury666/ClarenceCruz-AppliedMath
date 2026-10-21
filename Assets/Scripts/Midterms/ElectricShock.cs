using TMPro;
using UnityEngine;

public class ElectricShock : MonoBehaviour
{
    public GameObject shockParticle;
    public TextMeshProUGUI levelText;
    public int level = 1;

    float radius;
    float damage;
    float fireRate;
    float fireTimer;

    void Start()
    {
        levelText.text = "ELECTRIC SHOCK LVL: " + level;
    }

    void Update()
    {
        if (level >= 10)
        {
            damage = 40f;
            radius = 9f;
            fireRate = 0.7f;
        }
        else
        {
            damage = 6f + level;
            fireRate = 3f - ((level - 1) * 0.2875f);
            radius = 4f + ((level - 1) * 0.625f);
        }

        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            fireTimer = 0f;
            SoundManager.instance.PlayElectricShock();

            shockParticle.transform.localScale = Vector3.one * radius;
            shockParticle.GetComponent<ParticleSystem>().Play();

            for (int i = 0; i < EnemyMastermind.allEnemies.Count; i++)
            {
                Enemy currentEnemy = EnemyMastermind.allEnemies[i];

                Vector3 shockPos = new Vector3(transform.position.x, 0f, transform.position.z);
                Vector3 enemyPos = new Vector3(currentEnemy.transform.position.x, 0f, currentEnemy.transform.position.z);

                if (Vector3.Distance(shockPos, enemyPos) <= radius)
                {
                    currentEnemy.TakeDamage(damage);
                }
            }
        }
    }

    public void LevelUp()
    {
        if (level < 10)
        {
            level += 1;

            if (level >= 10)
            {
                levelText.text = "ELECTRIC SHOCK LVL: MAX";
            }
            else
            {
                levelText.text = "ELECTRIC SHOCK LVL: " + level;
            }
        }
    }
}