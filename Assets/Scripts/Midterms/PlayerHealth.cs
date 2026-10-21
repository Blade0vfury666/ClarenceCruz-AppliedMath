using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public RectTransform realHealthBar;
    public RectTransform ghostHealthBar;
    public GameObject flashScreen;

    public float maxHealth = 20f;
    public float currentHealth = 20f;

    float delayTimer;
    float flashTimer;
    Vector3 initialScale;

    void Start()
    {
        initialScale = realHealthBar.localScale;
        currentHealth = maxHealth;
    }

    void Update()
    {
        flashTimer -= Time.deltaTime;
        if (flashTimer <= 0)
        {
            flashScreen.SetActive(false);
        }

        if (delayTimer > 0f)
        {
            delayTimer -= Time.deltaTime;
        }
        else if (ghostHealthBar.localScale.x > realHealthBar.localScale.x)
        {
            ghostHealthBar.localScale = Vector3.Lerp(ghostHealthBar.localScale, realHealthBar.localScale, Time.deltaTime * 3f);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        flashScreen.SetActive(true);
        flashTimer = 0.2f;

        if (currentHealth <= 0f)
        {
            SceneManager.LoadScene(2);
        }

        realHealthBar.localScale = new Vector3(initialScale.x * (currentHealth / maxHealth), initialScale.y, initialScale.z);
        delayTimer = 0.5f;
    }
}