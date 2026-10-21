using TMPro;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public static PlayerXP playerXP;

    public TextMeshProUGUI xpText;
    public TextMeshProUGUI orbText;
    public TextMeshProUGUI shockText;
    public TextMeshProUGUI meteorText;

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

            while (true)
            {
                int randomWeapon = Random.Range(1, 4);

                if (randomWeapon == 1 && energyOrb.level < 10)
                {
                    energyOrb.LevelUp();
                    orbText.gameObject.SetActive(true);
                    break;
                }
                else if (randomWeapon == 2 && electricShock.level < 10)
                {
                    electricShock.LevelUp();
                    shockText.gameObject.SetActive(true);
                    break;
                }
                else if (randomWeapon == 3 && meteor.level < 10)
                {
                    meteor.LevelUp();
                    meteorText.gameObject.SetActive(true);
                    break;
                }
            }

            noticeTimer = 4f;

            if (energyOrb.level >= 10 && electricShock.level >= 10 && meteor.level >= 10)
            {
                xpText.text = "XP: MAX";
                return;
            }
        }

        xpText.text = "XP: " + currentXP;
    }
}