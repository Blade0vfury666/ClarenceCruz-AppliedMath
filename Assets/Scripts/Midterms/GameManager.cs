using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public float spawnRadius = 15f;
    public TextMeshProUGUI timerText;

    public GameObject basicPrefab;
    public GameObject fastPrefab;
    public GameObject heavyPrefab;
    public GameObject rangedPrefab;
    public GameObject minibossPrefab;

    List<GameObject> activePrefabs = new List<GameObject>();
    float gameTimer;
    float spawnTimer;
    bool minibossSpawned;

    void Update()
    {
        gameTimer += Time.deltaTime;

        if (gameTimer >= 480f)
        {
            SceneManager.LoadScene(3);
            return;
        }

        float timeRemaining = 480f - gameTimer;
        int minutes = (int)timeRemaining / 60;
        int seconds = (int)timeRemaining % 60;
        timerText.text = $"{minutes}:{seconds:00}";

        float scale = Mathf.Min(gameTimer, 420f) / 420f;
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= 1f - (scale * 0.5f))
        {
            spawnTimer = 0f;

            activePrefabs.Clear();
            activePrefabs.Add(basicPrefab);

            if (gameTimer >= 60f)
            {
                activePrefabs.Add(fastPrefab);
            }

            if (gameTimer >= 180f)
            {
                activePrefabs.Add(heavyPrefab);
            }

            if (gameTimer >= 240f)
            {
                activePrefabs.Add(rangedPrefab);
            }

            int amount = 4 + (int)(scale * 36f);

            for (int i = 0; i < amount; i++)
            {
                foreach (GameObject prefab in activePrefabs)
                {
                    Spawn(prefab);
                }
            }
        }

        if (gameTimer >= 360f && minibossSpawned == false)
        {
            minibossSpawned = true;
            Spawn(minibossPrefab);
            Spawn(minibossPrefab);
        }
    }

    void Spawn(GameObject prefab)
    {
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector3 pos = player.position + (new Vector3(Mathf.Sin(angle), 0f, Mathf.Cos(angle)) * spawnRadius);
        Pooling.Spawn(prefab, pos, Quaternion.identity);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(player.position, spawnRadius);
    }
}