using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;
    public Vector3 direction;

    float lifeTimer;

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        lifeTimer += Time.deltaTime;
        
        if (lifeTimer > lifeTime)
        {
            Destroy(gameObject);
        }
    }
}