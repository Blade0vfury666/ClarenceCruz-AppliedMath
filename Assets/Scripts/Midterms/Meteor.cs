using TMPro;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public Transform skySpawnPoint;
    public GameObject meteorPrefab;
    public GameObject ultimateMeteorPrefab;
    public TextMeshProUGUI levelText;
    public float angleRadius = 1f;
    public int level = 1;

    float fireRate;
    float fireTimer;

    void Start()
    {
        levelText.text = "METEOR LVL: " + level;
    }

    void Update()
    {
        int meteorAmount = 2;
        float sizeMultiplier = 1f;

        if (level >= 10)
        {
            meteorAmount = 1;
            fireRate = 25f;
        }
        else
        {
            fireRate = 10f - ((level - 1) * 0.5f);

            if (level >= 7)
            {
                meteorAmount = 4;
                sizeMultiplier = 2f;
            }
            else if (level >= 4)
            {
                meteorAmount = 3;
                sizeMultiplier = 1.5f;
            }
        }

        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            fireTimer = 0f;

            GameObject prefab = meteorPrefab;

            if (level >= 10)
            {
                prefab = ultimateMeteorPrefab;
            }

            for (int i = 0; i < meteorAmount; i++)
            {
                Vector3 shootDirection = new Vector3(Random.Range(-angleRadius, angleRadius), -1f, Random.Range(-angleRadius, angleRadius)).normalized;

                GameObject spawnedMeteor = Pooling.Spawn(prefab, skySpawnPoint.position, Quaternion.identity);

                MeteorProjectile projectile = spawnedMeteor.GetComponent<MeteorProjectile>();
                projectile.direction = shootDirection;

                if (level < 10)
                {
                    projectile.explosionRadius = 4f * sizeMultiplier;
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
                levelText.text = "METEOR LVL: MAX";
            }
            else
            {
                levelText.text = "METEOR LVL: " + level;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(skySpawnPoint.position, angleRadius);
    }
}