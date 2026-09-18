using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject rocketPrefab;
    public int rocketCount = 4;
    public float fireRate = 3f;

    float fireTimer;

    void Update()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveZ = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveZ = -1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }

        transform.position += new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;

        fireTimer += Time.deltaTime;
        
        if (fireTimer >= fireRate)
        {
            fireTimer = 0f;
            
            float spacing = 360f / rocketCount;
            float startingAngle = spacing / 2f;

            for (int i = 0; i < rocketCount; i++)
            {
                float currentAngle = startingAngle + (i * spacing);
                float angleInRadians = currentAngle * Mathf.Deg2Rad;
                
                Vector3 shootDirection = new Vector3(Mathf.Sin(angleInRadians), 0, Mathf.Cos(angleInRadians));

                GameObject spawnedRocket = Instantiate(rocketPrefab, transform.position, Quaternion.identity);
                spawnedRocket.GetComponent<Rocket>().direction = shootDirection;
            }
        }
    }
}