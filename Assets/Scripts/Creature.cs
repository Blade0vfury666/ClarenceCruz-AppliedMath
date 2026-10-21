// using UnityEngine;

// public class Creature : MonoBehaviour
// {
//     public float travelTime = 5f;
//     public BezierSpawnPoint spawnPoint;
//     public GameObject coinPrefab;

//     float timer;

//     void Update()
//     {
//         timer += Time.deltaTime;
//         float t = timer / travelTime;

//         transform.position = spawnPoint.GetPoint(t);

//         if (t >= 1f)
//         {
//             GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().TakeDamage();
//             Destroy(gameObject);
//         }
//     }

//     public void Die()
//     {
//         Instantiate(coinPrefab, transform.position, Quaternion.identity);
//         Destroy(gameObject);
//     }
// }