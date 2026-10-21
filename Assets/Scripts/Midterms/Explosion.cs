using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float duration = 1f;

    float timer;

    void OnEnable()
    {
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= duration)
        {
            Pooling.Despawn(gameObject);
        }
    }
}