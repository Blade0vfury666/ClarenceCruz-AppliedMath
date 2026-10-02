using UnityEngine;
using TMPro;

public class CoinsUI : MonoBehaviour
{
    public static int targetCoins = 0;

    public TextMeshProUGUI coinText;
    public int displayCoins = 0;
    float timer;

    void Start()
    {
        targetCoins = 0;
        displayCoins = 0;
        coinText.text = "Coins: " + displayCoins;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, Time.deltaTime * 5f);

        if (displayCoins < targetCoins)
        {
            timer += Time.deltaTime;

            if (timer >= 0.05f)
            {
                timer = 0f;
                displayCoins += 1;
                coinText.text = "Coins: " + displayCoins;
                transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            }
        }
    }
}