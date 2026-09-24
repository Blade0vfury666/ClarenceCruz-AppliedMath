using UnityEngine;

public class SniperTurret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float range = 15f;

    float cooldown;

    void Update()
    {
        cooldown -= Time.deltaTime;

        Vector3 dir = GameObject.FindWithTag("Player").transform.position - transform.position;

        if (Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) < range && Vector3.Angle(transform.forward, dir) < 2f)
        {
            if (cooldown <= 0f)
            {
                cooldown = 3f;
                Instantiate(bulletPrefab, transform.position, transform.rotation);
            }
        }
    }
}