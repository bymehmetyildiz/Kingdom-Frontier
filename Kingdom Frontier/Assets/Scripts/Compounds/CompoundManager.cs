using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CompoundType { City, Castle, Village}

public class CompoundManager : MonoBehaviour
{
    [HideInInspector]public Compound compound;
    public int index;
    public CompoundType compoundType;

    [SerializeField] private float timeLeft;
    [SerializeField] private bool isBuilding;
    public string timeText;

    [Header("Compound")]
    public int level;
    public int gold;
    public int metal;
    public int wood;
    public int cement;

    [Header("Upgrades")]
    public int barrack;
    public int bazaar;
    public int forge;
    public int bakery;
    public int shop;

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
        isBuilding = false;
    }

    
    void Update()
    {
        if (isBuilding)
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
            }
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



