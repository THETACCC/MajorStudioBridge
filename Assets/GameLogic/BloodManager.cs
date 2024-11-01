using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SKCell;

public class BloodManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public SKSlider bloodSlider;
    public SKSlider bloodSlider_Bridge;

    public int bloodCount;
    public float bloodCountToDecimal;
    public int maxBlood;

    //Incremental Calculation
    public int addBloodCount = 100;
    public bool isAutoUpgraded = false;
    public float timeBetweenClick = 5f;
    private float time = 0f;



    //Upgrades References
    public GameObject UpgradeA1;
    public GameObject UpgradeA1_1;

    public GameObject UpgradeA2;


    public GameObject UpgradeB1;
    public GameObject UpgradeB1_2;
    // Start is called before the first frame update
    void Start()
    {
        maxBlood = 10000;
        bloodCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        // Ensure bloodCount is clamped between 0 and maxBlood
        bloodCount = Mathf.Min(bloodCount, maxBlood);
        bloodCount = Mathf.Max(bloodCount, 0);


        text.text = bloodCount.ToString();
        UpdateBloodSlider();


        //Auto Click upgrade Module
        if(isAutoUpgraded)
        {
            time += Time.deltaTime;
            if(time >= timeBetweenClick)
            {
                AddBlood();
                time = 0f;
            }



        }


    }

    public void AddBlood()
    {
        bloodCount += addBloodCount;
    }

    public void AddBloodCountUpgrade()
    {
        if(bloodCount >= 5000)
        {
            bloodCount -= 5000;
            addBloodCount = 200;
            UpgradeA1.SetActive(false);
            UpgradeA1_1.SetActive(true);
        }
    }
    public void AddBloodCountUpgrade1_2()
    {
        if (bloodCount >= 8000)
        {
            bloodCount -= 8000;
            addBloodCount = 400;
            UpgradeA1.SetActive(false);
            UpgradeA1_1.SetActive(false);
        }
    }

    public void AutoClickUpgrade()
    {
        if(bloodCount >= 2000)
        {
            bloodCount -= 2000;
            isAutoUpgraded = true;
            UpgradeB1.SetActive(false);
            UpgradeB1_2.SetActive(true);
        }
    }

    public void AutoClickUpgradeSpeedB1_2()
    {
        if (bloodCount >= 3000)
        {
            bloodCount -= 3000;
            timeBetweenClick = 2f;
            UpgradeB1_2.SetActive(false);
        }
    }


    public void maxBloodStorageUpgradeA2()
    {
        if (bloodCount >= 10000)
        {
            bloodCount -= 10000;
            maxBlood = 20000;
            UpgradeA2.SetActive(false);

        }
    }


    private void UpdateBloodSlider()
    {
        // Calculate the decimal percentage of bloodCount relative to maxBlood
        float bloodPercentage = (float)bloodCount / maxBlood;
        bloodSlider.SetValue(bloodPercentage);
        bloodSlider_Bridge.SetValue(bloodPercentage);
    }

}
