using UnityEngine;

public class FlyingCoin : MonoBehaviour
{
    public float flySpeed = 5f;
    float timer;

    void Update()
    {
        transform.position += Vector3.up * flySpeed * Time.deltaTime;

        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            Add();
        }
    }

    void Add()
    {
        CoinsUI.targetCoins += 10;
        Destroy(gameObject);
    }
}