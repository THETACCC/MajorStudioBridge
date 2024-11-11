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

    [Header("ManEater Upgrade GameObjects")]
    public GameObject ManEaterLevel1;
    public GameObject ManEaterLevel2;
    public GameObject ManEaterLevel3;
    public GameObject ManEaterMax;

    [Header("ManEater Upgrade Costs")]
    public int ManEaterLevel1_Cost;
    public int ManEaterLevel2_Cost;
    public int ManEaterLevel3_Cost;
    private bool isManEater1 = false;
    private bool isManEater2 = false;
    private bool isManEater3 = false;


    public GameObject ManEaterOBJ;
    public GameObject ManEaterOBJ2;
    public GameObject ManEaterOBJ3;
    public GameObject ManEaterOBJ4;
    public GameObject ManEaterOBJ5;
    public ManEater manEater;
    public ManEater manEater2;
    public ManEater manEater3;
    public ManEater manEater4;
    public ManEater manEater5;

    [Header("Summoning Upgrade GameObjects")]
    public GameObject SummonLevel1;
    public GameObject SummonLevel2;
    public GameObject SummonLevel3;
    public GameObject SummonMax;

    [Header("Summoning Upgrade Costs")]
    public int SummonLevel1_Cost;
    public int SummonLevel2_Cost;
    public int SummonLevel3_Cost;
    private bool isSummon1 = false;
    private bool isSummon2 = false;
    private bool isSummon3 = false;


    public GameObject RatSpawnerOBJ;
    public RatSpawner ratSpawner;
    public GameObject PeopleSpawnLeft;
    public GameObject PeopleSpawnRight;
    public PeopleSpawnerMaster peopleMaster;

    public CrowSpawner crowSpawner;
    public TaxiSpawnerMaster taxiMaster;

    public CockSpawner cockSpawner;
    public TrainSpawnMaster trainMaster;

    private float timeBetweenRat = 30f;
    private float timeRat = 0f;

    private float timeBetweenCrow = 30f;
    private float timeCrow = 0f;

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

    [Header("MoreEater GameObjects")]
    public GameObject MoreEaterLevel1;
    public GameObject MoreEaterLevel2;
    public GameObject MoreEaterLevel3;
    public GameObject MoreEaterMax;

    [Header("Tentacle Upgrade Costs")]
    public int MoreEaterLevel1_Cost;
    public int MoreEaterLevel2_Cost;
    public int MoreEaterLevel3_Cost;
    private bool isMoreEater1 = false;
    private bool isMoreEater2 = false;
    private bool isMoreEater3 = false;



    [Header("Prestige Count")]
    public GameObject PrestigeBase;
    public int Prestige1_Count;
    public int Prestige2_Count;
    public int Prestige3_Count;
    public int Prestige4_Count;
    public int Prestige5_Count;
    public int Prestige6_Count;
    public int Prestige7_Count;
    public int Prestige8_Count;
    public int Prestige9_Count;
    public int Prestige10_Count;
    private bool isPrestige1 = false;
    private bool isPrestige2 = false;
        
    private bool isPrestige3 = false;
    private bool isPrestige4 = false;
    private bool isPrestige5 = false;
    private bool isPrestige6 = false;
    private bool isPrestige7 = false;
        
    private bool isPrestige8 = false;
    private bool isPrestige9 = false;
    private bool isPrestige10 = false;


    //Prestige Upgrades
    [Header("Prestige People")]

       
    public GameObject MorePeopleLevel1;
    public GameObject MorePeopleLevel2;
    public GameObject MorePeopleLevel3;
    public GameObject MorePeopleLevel4;
    public GameObject MorePeopleLevel5;
    public GameObject MorePeopleLevel6;
    public GameObject MorePeopleMax;



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


        //Summoning Upgrade Module
        if (isSummon1)
        {
            timeRat += Time.deltaTime;
            if (timeRat >= timeBetweenRat)
            {
                //RandomAutoKill();
                RatSpawning();
                timeRat = 0f;
            }



        }
        if (isSummon2)
        {
            timeCrow += Time.deltaTime;
            if (timeCrow >= timeBetweenCrow)
            {
                //RandomAutoKill();


                CrowSpawning();
                if(isSummon3)
                {
                    CockSpawning();
                }


                timeCrow = 0f;
            }



        }


        if(HeadCount > Prestige1_Count)
        {
            if(!isPrestige1)
            {
                PrestigeBase.SetActive(true);
                isPrestige1= true;
            }
        }

        if (HeadCount > Prestige2_Count)
        {
            if (!isPrestige2)
            {
                PrestigeBase.SetActive(true);
                isPrestige2 = true;
            }
        }

        if (HeadCount > Prestige3_Count)
        {
            if (!isPrestige3)
            {
                PrestigeBase.SetActive(true);
                isPrestige3 = true;
            }
        }

        if (HeadCount > Prestige4_Count)
        {
            if (!isPrestige4)
            {
                PrestigeBase.SetActive(true);
                isPrestige4 = true;
            }
        }

        if (HeadCount > Prestige5_Count)
        {
            if (!isPrestige5)
            {
                PrestigeBase.SetActive(true);
                isPrestige5 = true;
            }
        }

        if (HeadCount > Prestige6_Count)
        {
            if (!isPrestige6)
            {
                PrestigeBase.SetActive(true);
                isPrestige6 = true;
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


    //Man Eater 

    public void ManEaterUpgrade1()
    {
        if (bloodCount >= ManEaterLevel1_Cost)
        {
            bloodCount -= ManEaterLevel1_Cost;
            isManEater1 = true;
            ManEaterLevel1.SetActive(false);
            ManEaterLevel2.SetActive(true);

            ManEaterOBJ.SetActive(true);

        }
    }

    public void ManEaterUpgrade2()
    {
        if (bloodCount >= ManEaterLevel2_Cost)
        {
            bloodCount -= ManEaterLevel2_Cost;
            isManEater2 = true;
            ManEaterLevel2.SetActive(false);
            ManEaterLevel3.SetActive(true);

            manEater.timeBetweenEat = 10f;
            manEater2.timeBetweenEat = 10f;
            manEater3.timeBetweenEat = 10f;
            manEater4.timeBetweenEat = 10f;
            manEater5.timeBetweenEat = 10f;
        }
    }
    public void ManEaterUpgrade3()
    {
        if (bloodCount >= ManEaterLevel3_Cost)
        {
            bloodCount -= ManEaterLevel3_Cost;
            isManEater3 = true;
            ManEaterLevel3.SetActive(false);
            ManEaterMax.SetActive(true);

            manEater.timeBetweenEat = 5f;
            manEater2.timeBetweenEat = 5f;
            manEater3.timeBetweenEat = 5f;
            manEater4.timeBetweenEat = 5f;
            manEater5.timeBetweenEat = 5f;

        }
    }
    //Summoning stuff
    public void RatSpawning()
    {
        ratSpawner.StartSpawning();
        PeopleSpawnLeft.SetActive(false);
        PeopleSpawnRight.SetActive(false);
        peopleMaster.enabled = false;
        Invoke("RatFinished", 6f);
    }

    private void RatFinished()
    {
        peopleMaster.enabled = true;
        PeopleSpawnLeft.SetActive(true);
        PeopleSpawnRight.SetActive(true);
    }

    public void CrowSpawning()
    {
        crowSpawner.StartSpawning();

        taxiMaster.enabled = false;
        Invoke("CrowFinished", 6f);
    }

    private void CrowFinished()
    {
        taxiMaster.enabled = true;

    }
    public void CockSpawning()
    {
        cockSpawner.StartSpawning();

        trainMaster.enabled = false;
        Invoke("CockFinished", 6f);
    }

    private void CockFinished()
    {
        trainMaster.enabled = true;

    }
    public void SummonUpgrade1()
    {
        if (bloodCount >= SummonLevel1_Cost)
        {
            bloodCount -= SummonLevel1_Cost;
            isSummon1 = true;
            SummonLevel1.SetActive(false);
            SummonLevel2.SetActive(true);

            RatSpawnerOBJ.SetActive(true);

        }
    }

    public void SummonUpgrade2()
    {
        if (bloodCount >= SummonLevel2_Cost)
        {
            bloodCount -= SummonLevel2_Cost;
            isSummon2 = true;
            SummonLevel2.SetActive(false);
            SummonLevel3.SetActive(true);


        }
    }

    public void SummonUpgrade3()
    {
        if (bloodCount >= SummonLevel3_Cost)
        {
            bloodCount -= SummonLevel3_Cost;
            isSummon3 = true;
            SummonLevel3.SetActive(false);
            SummonMax.SetActive(true);


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


    public void MoreEaterUpgrade1()
    {
        if (bloodCount >= MoreEaterLevel1_Cost)
        {
            bloodCount -= MoreEaterLevel1_Cost;
            isMoreEater1 = true;
            MoreEaterLevel1.SetActive(false);
            MoreEaterLevel2.SetActive(true);
            ManEaterOBJ2.SetActive(true);
        }
    }

    public void MoreEaterUpgrade2()
    {
        if (bloodCount >= MoreEaterLevel2_Cost)
        {
            bloodCount -= MoreEaterLevel2_Cost;
            isMoreEater2 = true;
            MoreEaterLevel2.SetActive(false);
            MoreEaterLevel3.SetActive(true);
            ManEaterOBJ3.SetActive(true);
        }
    }

    public void MoreEaterUpgrade3()
    {
        if (bloodCount >= MoreEaterLevel3_Cost)
        {
            bloodCount -= MoreEaterLevel3_Cost;
            isMoreEater3 = true;
            MoreEaterLevel3.SetActive(false);
            MoreEaterMax.SetActive(true);
            ManEaterOBJ4.SetActive(true);
            ManEaterOBJ5.SetActive(true);
        }
    }





    #endregion


    #region Prestige
    public void MorePeopleUpgrade1()
    {

            MorePeopleLevel1.SetActive(false);
            MorePeopleLevel2.SetActive(true);
        peopleMaster.timeBetweenSpawn -= 0.05f;
    }

    public void MorePeopleUpgrade2()
    {

        MorePeopleLevel2.SetActive(false);
        MorePeopleLevel3.SetActive(true);
        peopleMaster.timeBetweenSpawn -= 0.05f;
    }

    public void MorePeopleUpgrade3()
    {

        MorePeopleLevel3.SetActive(false);
        MorePeopleLevel4.SetActive(true);
        peopleMaster.timeBetweenSpawn -= 0.05f;
    }
    public void MorePeopleUpgrade4()
    {

        MorePeopleLevel4.SetActive(false);
        MorePeopleLevel5.SetActive(true);
        peopleMaster.timeBetweenSpawn -= 0.05f;
    }
    public void MorePeopleUpgrade5()
    {

        MorePeopleLevel5.SetActive(false);
        MorePeopleLevel6.SetActive(true);
        peopleMaster.timeBetweenSpawn -= 0.05f;
    }
    public void MorePeopleUpgrade6()
    {

        MorePeopleLevel6.SetActive(false);
        MorePeopleMax.SetActive(true);
        peopleMaster.timeBetweenSpawn -= 0.05f;
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
