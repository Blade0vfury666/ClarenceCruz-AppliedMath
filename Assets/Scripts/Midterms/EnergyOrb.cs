using TMPro;
using UnityEngine;

public class EnergyOrb : MonoBehaviour
{
    public Transform player;
    public GameObject orbPrefab;
    public TextMeshProUGUI levelText;
    public int level = 1;

    float fireRate = 0.4f;
    float fireTimer;

    void Start()
    {
        levelText.text = "ORB LVL: " + level;
    }

    void Update()
    {
        int orbCount = 4;
        float orbSize = 1f;

        if (level >= 7)
        {
            orbCount = 6;
            orbSize = 2f;
        }
        else if (level >= 4)
        {
            orbCount = 5;
            orbSize = 1.5f;
        }

        float orbSpeed = 6f + level;

        if (orbSpeed > 15f)
        {
            orbSpeed = 15f;
        }

        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            fireTimer = 0f;
            SoundManager.instance.PlayOrbShoot();

            float spacing = 360f / orbCount;
            float startingAngle = spacing / 2f;

            for (int i = 0; i < orbCount; i++)
            {
                float currentAngle = startingAngle + (i * spacing);
                float angleInRadians = currentAngle * Mathf.Deg2Rad;

                Vector3 shootDirection = new Vector3(Mathf.Sin(angleInRadians), 0f, Mathf.Cos(angleInRadians));

                GameObject spawnedOrb = Pooling.Spawn(orbPrefab, player.position, Quaternion.identity);
                spawnedOrb.transform.localScale = Vector3.one * orbSize;

                OrbProjectile projectile = spawnedOrb.GetComponent<OrbProjectile>();
                projectile.direction = shootDirection;
                projectile.hitRadius = 0.5f * orbSize;
                projectile.speed = orbSpeed;

                if (level >= 10)
                {
                    projectile.isPiercing = true;
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
                levelText.text = "ORB LVL: MAX";
            }
            else
            {
                levelText.text = "ORB LVL: " + level;
            }
        }
    }
}