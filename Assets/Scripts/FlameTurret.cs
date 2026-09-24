using UnityEngine;

public class FlameTurret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float range = 5f;
    public float coneAngle = 45f;

    float cooldown;

    void Update()
    {
        cooldown -= Time.deltaTime;

        Vector3 dir = GameObject.FindWithTag("Player").transform.position - transform.position;

        if (Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) < range && Vector3.Angle(transform.forward, dir) < (coneAngle / 2f))
        {
            if (cooldown <= 0f)
            {
                cooldown = 0.1f;
                Instantiate(bulletPrefab, transform.position, transform.rotation);
            }
        }
    }
}