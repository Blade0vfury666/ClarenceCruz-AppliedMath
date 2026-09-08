using UnityEngine;

public class FinishZone : MonoBehaviour
{
    public float finishDist = 2f;
    public GameObject winUI;

    void Update()
    {
        if (Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) < finishDist)
            winUI.SetActive(true);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, finishDist);
    }
}