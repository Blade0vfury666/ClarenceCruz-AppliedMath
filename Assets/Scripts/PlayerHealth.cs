using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public RectTransform realHealthBar;
    public RectTransform ghostHealthBar;

    public float currentHealth = 20f;
    float delayTimer;
    Vector3 initialScale;

    void Start()
    {
        initialScale = realHealthBar.localScale;
    }

    void Update()
    {
        if (delayTimer > 0f)
        {
            delayTimer -= Time.deltaTime;
        }
        else if (ghostHealthBar.localScale.x > realHealthBar.localScale.x)
        {
            ghostHealthBar.localScale = Vector3.Lerp(ghostHealthBar.localScale, realHealthBar.localScale, Time.deltaTime * 3f);
        }
    }

    public void TakeDamage()
    {
        currentHealth -= 1f;
        realHealthBar.localScale = new Vector3(initialScale.x * (currentHealth / 20f), initialScale.y, initialScale.z);
        delayTimer = 0.5f;
    }
}