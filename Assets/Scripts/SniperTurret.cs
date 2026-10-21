// using UnityEngine;

// public class SniperTurret : MonoBehaviour
// {
//     public GameObject bulletPrefab;
//     public float range = 15f;

//     float cooldown;

//     void Update()
//     {
//         cooldown -= Time.deltaTime;

//         GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

//         for (int i = 0; i < enemies.Length; i++)
//         {
//             Vector3 direction = enemies[i].transform.position - transform.position;

//             if (Vector3.Distance(transform.position, enemies[i].transform.position) < range && Vector3.Angle(transform.forward, direction) < 2f)
//             {
//                 if (cooldown <= 0f)
//                 {
//                     cooldown = 3f;
//                     Instantiate(bulletPrefab, transform.position, transform.rotation);
//                 }
//                 break;
//             }
//         }
//     }
// }