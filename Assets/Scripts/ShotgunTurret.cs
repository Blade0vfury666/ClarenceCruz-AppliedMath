using UnityEngine;

public class ShotgunTurret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float range = 6f;
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
                cooldown = 2f;

                for (int i = -1; i <= 1; i++)
                {
                    Quaternion spreadRot = Quaternion.Euler(0, transform.eulerAngles.y + (i * 15f), 0);
                    Instantiate(bulletPrefab, transform.position, spreadRot);
                }
            }
        }
    }
}