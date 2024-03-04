using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Compound
{
    public int profit;
    public string name;
    public Sprite image;


    public int Profit()
    {
        if (this is City)
        {
            City currentCity = (City)this;
            currentCity.CalculateTaxProfit();
        }
        else if (this is Castle)
        {
            Castle currentCastle = (Castle)this;
            currentCastle.CalculateTaxProfit();
        }
        else if (this is Village)
        {
            Village currentVillage = (Village)this;
            currentVillage.CalculateTaxProfit();
        }

        return profit;

    }

    public void CompoundInitialize(int _index)
    {     

        if (this is City)
        {
            name = Compound_SO_BaseClass.Instance.city_SO[_index].name;
            image = Compound_SO_BaseClass.Instance.city_SO[_index].image;
        }
        else if (this is Castle)
        {
            name = Compound_SO_BaseClass.Instance.castle_SO[_index].name;
            image = Compound_SO_BaseClass.Instance.castle_SO[_index].image;
        }
        else if (this is Village)
        {
            name = Compound_SO_BaseClass.Instance.village_SO[_index].name;
            image = Compound_SO_BaseClass.Instance.village_SO[_index].image;
        }
    }




}

public class City : Compound
{
    public int numberOfHouse;
    public int houseTaxPerYear;
    public int tradingIncome;
    public int infrastructureExpense;
    public int level;

    public City(int numberOfHouse, int houseTaxPerYear, int tradingIncome, int infrastructureExpense, int level)
    {
        this.numberOfHouse = numberOfHouse;
        this.houseTaxPerYear = houseTaxPerYear;
        this.tradingIncome = tradingIncome;
        this.infrastructureExpense = infrastructureExpense;
        this.level = level;
    }

    public void CalculateTaxProfit()
    {
        profit = (numberOfHouse * houseTaxPerYear + tradingIncome - infrastructureExpense);
    }
        

}

public class Village : Compound
{
    public int numberOfFarmers;
    public int agriculturalTax;
    public int infrastructureExpense ;
    public int level;

    public Village(int numberOfFarmers, int agriculturalTax, int infrastructureExpense, int level)
    {
        this.numberOfFarmers = numberOfFarmers;
        this.agriculturalTax = agriculturalTax;
        this.infrastructureExpense = infrastructureExpense;
        this.level = level;
    }

    public void CalculateTaxProfit()
    {
        profit = numberOfFarmers * agriculturalTax;
    }
}

public class Castle : Compound
{
    public int numberOfSoldiers;
    public int yearlySoldierSalary ;
    public int lootIncome ;
    public int equipmentExpense;
    public int infrastructureExpense_Ca;
    public int level;

    public Castle(int numberOfSoldiers, int yearlySoldierSalary, int lootIncome, int equipmentExpense, int infrastructureExpense_Ca, int level)
    {
        this.numberOfSoldiers = numberOfSoldiers;
        this.yearlySoldierSalary = yearlySoldierSalary;
        this.lootIncome = lootIncome;
        this.equipmentExpense = equipmentExpense;
        this.infrastructureExpense_Ca = infrastructureExpense_Ca;
        this.level = level;
    }

    public void CalculateTaxProfit()
    {
        profit = lootIncome -  numberOfSoldiers * yearlySoldierSalary - equipmentExpense;
    }
}