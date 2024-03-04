using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CompoundType { City, Castle, Village}

public class CompoundManager : MonoBehaviour
{
    [HideInInspector]public Compound compound;
    public int index;
    public CompoundType compoundType;

    [SerializeField] private float timer;
    [SerializeField] private bool isBuilding;
    public int level;

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
       
    }

    
    void Update()
    {
        
    }


}



