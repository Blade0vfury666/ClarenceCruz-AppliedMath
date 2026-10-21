// using UnityEngine;

// public class ShotgunTurret : MonoBehaviour
// {
//     public GameObject bulletPrefab;
//     public float range = 6f;
//     public float coneAngle = 45f;

//     float cooldown;

//     void Update()
//     {
//         cooldown -= Time.deltaTime;

//         GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

//         for (int i = 0; i < enemies.Length; i++)
//         {
//             Vector3 direction = enemies[i].transform.position - transform.position;

//             if (Vector3.Distance(transform.position, enemies[i].transform.position) < range && Vector3.Angle(transform.forward, direction) < (coneAngle / 2f))
//             {
//                 if (cooldown <= 0f)
//                 {
//                     cooldown = 2f;

//                     for (int step = -1; step <= 1; step++)
//                     {
//                         Quaternion spreadRotation = Quaternion.Euler(0, transform.eulerAngles.y + (step * 15f), 0);
//                         Instantiate(bulletPrefab, transform.position, spreadRotation);
//                     }
//                 }
//                 break;
//             }
//         }
//     }
// }