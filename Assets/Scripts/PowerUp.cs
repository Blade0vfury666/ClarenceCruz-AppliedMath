using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float pickupDistance = 1.5f;

    void Update()
    {
        PlayerController playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        if (Vector3.Distance(transform.position, playerScript.transform.position) < pickupDistance)
        {
            if (playerScript.rocketCount < 8)
            {
                playerScript.rocketCount += 1;
            }
            
            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, pickupDistance);
    }
}