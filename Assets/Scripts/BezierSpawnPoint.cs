using UnityEngine;

public class BezierSpawnPoint : MonoBehaviour
{
    public GameObject creaturePrefab;
    public float spawnInterval = 3f;
    public Transform[] controlPoints;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            GameObject creature = Instantiate(creaturePrefab, transform.position, Quaternion.identity);
            creature.GetComponent<Creature>().spawnPoint = GetComponent<BezierSpawnPoint>();
        }
    }

    public Vector3 GetPoint(float t)
    {
        if (controlPoints.Length == 3)
        {
            Vector3 a = Vector3.Lerp(controlPoints[0].position, controlPoints[1].position, t);
            Vector3 b = Vector3.Lerp(controlPoints[1].position, controlPoints[2].position, t);

            return Vector3.Lerp(a, b, t);
        }
        else
        {
            Vector3 a = Vector3.Lerp(controlPoints[0].position, controlPoints[1].position, t);
            Vector3 b = Vector3.Lerp(controlPoints[1].position, controlPoints[2].position, t);
            Vector3 c = Vector3.Lerp(controlPoints[2].position, controlPoints[3].position, t);

            Vector3 d = Vector3.Lerp(a, b, t);
            Vector3 e = Vector3.Lerp(b, c, t);

            return Vector3.Lerp(d, e, t);
        }
    }

    void OnDrawGizmos()
    {
        if (controlPoints.Length == 3)
        {
            Gizmos.color = Color.yellow;
        }
        else
        {
            Gizmos.color = Color.magenta;
        }

        Vector3 previousPoint = controlPoints[0].position;

        for (int i = 1; i <= 20; i++)
        {
            float t = i / 20f;
            Vector3 currentPoint = GetPoint(t);
            Gizmos.DrawLine(previousPoint, currentPoint);
            previousPoint = currentPoint;
        }
    }
}