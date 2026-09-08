using UnityEngine;
using UnityEngine.SceneManagement;

public class NoGoZone : MonoBehaviour
{
    public float warningDist = 4f;
    public float restartDist = 1.5f;

    void Update()
    {
        float Dist = Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position);

        if (Dist < restartDist) SceneManager.LoadScene(0);
        else if (Dist < warningDist)
        {
            GetComponent<Renderer>().material.color = Color.red;
            transform.position += Random.insideUnitSphere * 0.02f;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, warningDist);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, restartDist);
    }
}