using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CompoundType { City, Castle, Village}

public class CompoundManager : MonoBehaviour
{
    [HideInInspector]public Compound compound;
    public int index;
    public CompoundType compoundType;

    private bool recourcesAdded;

    [SerializeField] private float timeLeft;
    [SerializeField] private bool isBuilding;
    public string timeText;


    [Header("Compound")]
    public int level;
    public int gold;
    public int metal;
    public int wood;
    public int cement;
    public int archerQuantity;
    public int infantryQuantity;
    public int cavalryQuantity;

    [Header("Upgrades")]
    public int barrack;
    public int bazaar;
    public int forge;
    public int bakery;
    public int shop;
    public bool barrackBuilt;
    public bool bazaarbuilt;
    public bool forgebuilt;
    public bool bakeryBuilt;
    public bool shopBuilt;

    [Header("City")]
    public int numberOfHouse;
    public int houseTaxPerYear;
    public int tradingIncome;
    public int infrastructureExpense_C;

    [Header("Castle")]
    public int numberOfSoldiers;
    public int yearlySoldierSalary;
    public int lootIncome;
    public int equipmentExpense;
    public int infrastructureExpense_Ca;

    [Header("Village")]
    public int numberOfFarmers;
    public int agriculturalTax;
    public int infrastructureExpense_V;

    [Header("Build Buttons")]
    private Buttons[] buttons;

    private void Awake()
    {
        if (CompareTag("City"))
        {
            compound = new City(numberOfHouse, houseTaxPerYear, tradingIncome, infrastructureExpense_C, level);            
        }
        else if (CompareTag("Castle"))
        {
            compound = new Castle(numberOfSoldiers, yearlySoldierSalary, lootIncome, equipmentExpense, infrastructureExpense_Ca, level);
        }
        else if (CompareTag("Village"))
        {
            compound = new Village(numberOfFarmers, agriculturalTax, infrastructureExpense_V, level);
        }

    }

    void Start()
    {
        buttons = FindObjectsOfType<Buttons>();
        
    }

    
    void Update()
    {
        if (isBuilding && !barrackBuilt)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                timeLeft = 0;
                isBuilding = false;
                barrack++;
                level++;

                gold -= Compound_SO_BaseClass.Instance.barrackGold;
                metal -= Compound_SO_BaseClass.Instance.barrackMetal;
                wood -= Compound_SO_BaseClass.Instance.barrackWood;
                cement -= Compound_SO_BaseClass.Instance.barrackCement;
                barrackBuilt = true;
            }
        }

        
        if (TimeManager.Instance.dayCounter % 5 == 0)
        {
            if (!recourcesAdded)
            {
                gold += 5;
                metal += 5;
                wood += 5;
                cement += 5;
                recourcesAdded = true;
            }
           
        }
        else
        {
            recourcesAdded = false;
        }
    }

    private void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minute = Mathf.FloorToInt(currentTime / 60);
        float second = Mathf.FloorToInt(currentTime % 60);

        timeText = string.Format("{0:00} : {1:00}", minute, second);
        
    }

    public void BuildBarrack()
    {
        if (!isBuilding)
        {
            if (gold >= Compound_SO_BaseClass.Instance.barrackGold && metal >= Compound_SO_BaseClass.Instance.barrackMetal
            && wood >= Compound_SO_BaseClass.Instance.barrackWood && cement >= Compound_SO_BaseClass.Instance.barrackCement)
            {
                isBuilding = true;

            }

        }
    }









}



