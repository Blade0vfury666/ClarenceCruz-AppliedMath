using TMPro;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public static PlayerXP playerXP;

    public TextMeshProUGUI xpText;
    public TextMeshProUGUI orbText;
    public TextMeshProUGUI shockText;
    public TextMeshProUGUI meteorText;

    public GameObject levelUpWindow;
    public GameObject orbCard;
    public GameObject shockCard;
    public GameObject meteorCard;

    public EnergyOrb energyOrb;
    public ElectricShock electricShock;
    public Meteor meteor;

    public int playerLevel = 1;
    public int currentXP;
    public int xpRequired;

    float noticeTimer;

    void Start()
    {
        playerXP = this;
        xpRequired = 120;
        xpText.text = "XP: " + currentXP;
    }

    void Update()
    {
        if (noticeTimer > 0f)
        {
            noticeTimer -= Time.deltaTime;

            if (noticeTimer <= 0f)
            {
                orbText.gameObject.SetActive(false);
                shockText.gameObject.SetActive(false);
                meteorText.gameObject.SetActive(false);
            }
        }
    }

    public void AddXP(int amount)
    {
        if (energyOrb.level >= 10 && electricShock.level >= 10 && meteor.level >= 10)
        {
            xpText.text = "XP: MAX";
            return;
        }

        currentXP += amount;

        if (currentXP >= xpRequired)
        {
            currentXP -= xpRequired;
            playerLevel += 1;
            xpRequired = 30 * (playerLevel + 1) * (playerLevel + 1);
            
            levelUpWindow.SetActive(true);
            Time.timeScale = 0.0001f;
        }

        LVLui();
    }

    public void LVLupEnergyOrb()
    {
        energyOrb.LevelUp();
        orbText.gameObject.SetActive(true);
        noticeTimer = 4f;
        levelUpWindow.SetActive(false);

        if (energyOrb.level >= 10)
        {
            orbCard.SetActive(false);
        }

        LVLui();
        Time.timeScale = 1f;
    }

    public void LVLupElectricShock()
    {
        electricShock.LevelUp();
        shockText.gameObject.SetActive(true);
        noticeTimer = 4f;
        levelUpWindow.SetActive(false);

        if (electricShock.level >= 10)
        {
            shockCard.SetActive(false);
        }

        LVLui();
        Time.timeScale = 1f;
    }

    public void LVLupMeteor()
    {
        meteor.LevelUp();
        meteorText.gameObject.SetActive(true);
        noticeTimer = 4f;
        levelUpWindow.SetActive(false);

        if (meteor.level >= 10)
        {
            meteorCard.SetActive(false);
        }

        LVLui();
        Time.timeScale = 1f;
    }

    public void LVLui()
    {
        if (energyOrb.level >= 10 && electricShock.level >= 10 && meteor.level >= 10)
        {
            xpText.text = "XP: MAX";
        }
        else
        {
            xpText.text = "XP: " + currentXP;
        }
    }
}