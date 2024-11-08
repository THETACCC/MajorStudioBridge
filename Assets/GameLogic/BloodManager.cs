using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SKCell;

public class BloodManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI headtext;
    public SKSlider bloodSlider;
    public SKSlider bloodSlider_Bridge;

    public int bloodCount;
    public float bloodCountToDecimal;
    public int maxBlood;

    //Incremental Calculation
    public int addBloodCount = 10;
    public int HeadCount = 0;
    public float eachKillCount;
    public bool isAutoUpgraded = false;
    //public float timeBetweenClick = 5f;
    //private float time = 0f;



    //Upgrades References



    //Type A Puppet Master

    //Upgrade Auto Pump
    [Header("Auto Pump Upgrade GameObjects")]
    public GameObject AutoPumpLevel1;
    public GameObject AutoPumpLevel2;
    public GameObject AutoPumpLevel3;
    public GameObject AutoPumpMax;

    [Header("Auto Pump Upgrade Costs")]
    public int AutoPumpLevel1_Cost;
    public int AutoPumpLevel2_Cost;
    public int AutoPumpLevel3_Cost;
    private bool isAutoPump1 = false;
    private bool isAutoPump2 = false;
    private bool isAutoPump3 = false;
    public float timeBetweenPump = 3f;
    private float time = 0f;


    //Type B Blood Craft
    [Header("Tentacle Upgrade GameObjects")]
    public GameObject TentacleLevel1;
    public GameObject TentacleLevel2;
    public GameObject TentacleLevelMax;

    [Header("Tentacle Upgrade Costs")]
    public int TentacleLevel1_Cost;
    public int TentacleLevel2_Cost;
    [HideInInspector]
    public bool isTentacle1 = false;
    [HideInInspector]
    public bool isTentacle2 = false;
    [HideInInspector]
    public bool isTentacleMax = false;

    public GameObject UpgradeA2;


    public GameObject UpgradeB1;
    public GameObject UpgradeB1_2;
    // Start is called before the first frame update
    void Start()
    {
        //maxBlood = 9999999999;
        bloodCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        // Ensure bloodCount is clamped between 0 and maxBlood
        //bloodCount = Mathf.Min(bloodCount, maxBlood);
        bloodCount = Mathf.Max(bloodCount, 0);


        text.text = bloodCount.ToString();
        headtext.text = HeadCount.ToString();
        UpdateBloodSlider();


        //Auto Click upgrade Module
        if(isAutoPump1)
        {
            time += Time.deltaTime;
            if(time >= timeBetweenPump)
            {
                RandomAutoKill();
                time = 0f;
            }



        }


    }

    public void AddBlood()
    {
        HeadCount++;
        bloodCount += (int)(addBloodCount * eachKillCount);
    }
    public void AddBloodTaxi()
    {
        HeadCount+= 5;
        bloodCount += (int)(addBloodCount * eachKillCount);
    }

    public void AddBloodTrain()
    {
        HeadCount += 20;
        bloodCount += (int)(addBloodCount * eachKillCount);
    }
    /*
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
    */

    #region Puppet Master Upgrades

    //Auto Pump Upgrades
    private void RandomAutoKill()
    {
        GameObject[] peopleObjects = GameObject.FindGameObjectsWithTag("People");

        if (peopleObjects.Length > 0)
        {
            int randomIndex = Random.Range(0, peopleObjects.Length);
            GameObject selectedPerson = peopleObjects[randomIndex];

            // Check if the selected person has a component with autoKill method
            var personScript = selectedPerson.GetComponent<PeopleMove>(); // Replace PeopleScript with the actual script name that has autoKill
            if (personScript != null)
            {
                personScript.autoKill(); // Call the autoKill function on the randomly selected person
            }
        }
    }

    public void AutoPumpUpgradeLevel1()
    {
        if (bloodCount >= AutoPumpLevel1_Cost)
        {
            bloodCount -= AutoPumpLevel1_Cost;
            isAutoPump1 = true;
            AutoPumpLevel1.SetActive(false);
            AutoPumpLevel2.SetActive(true);
        }
    }

    public void AutoPumpUpgradeLevel2()
    {
        if (bloodCount >= AutoPumpLevel2_Cost)
        {
            bloodCount -= AutoPumpLevel2_Cost;
            isAutoPump2 = true;
            timeBetweenPump = 2f;
            AutoPumpLevel2.SetActive(false);
            AutoPumpLevel3.SetActive(true);
        }
    }

    public void AutoPumpUpgradeLevel3()
    {
        if (bloodCount >= AutoPumpLevel3_Cost)
        {
            bloodCount -= AutoPumpLevel3_Cost;
            isAutoPump3 = true;
            timeBetweenPump = 1f;
            AutoPumpLevel3.SetActive(false);
            AutoPumpMax.SetActive(true);
        }
    }
    #endregion


    #region Blood Craft

    //Tentacle Upgrades
    public void TentacleUpgradeLevel1()
    {
        if (bloodCount >= TentacleLevel1_Cost)
        {
            bloodCount -= TentacleLevel1_Cost;
            isTentacle1 = true;
            TentacleLevel1.SetActive(false);
            TentacleLevel2.SetActive(true);
        }
    }

    public void TentacleUpgradeLevel2()
    {
        if (bloodCount >= TentacleLevel2_Cost)
        {
            bloodCount -= TentacleLevel2_Cost;
            isTentacle2 = true;
            TentacleLevel2.SetActive(false);
            TentacleLevelMax.SetActive(true);
        }
    }

    #endregion
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
            //timeBetweenClick = 2f;
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
