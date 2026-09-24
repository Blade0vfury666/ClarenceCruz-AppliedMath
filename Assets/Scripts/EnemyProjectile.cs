using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 8f;
    public float lifeTime = 4f;
    public float hitDistance = 0.5f;

    float lifeTimer;

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        lifeTimer += Time.deltaTime;
        
        if (lifeTimer > lifeTime)
        {
            Destroy(gameObject);
        }

        if (Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) < hitDistance)
        {
            SceneManager.LoadScene(0); 
        }
    }
}