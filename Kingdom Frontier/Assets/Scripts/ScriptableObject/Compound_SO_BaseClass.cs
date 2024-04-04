using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Compound_SO
{
    public string name;
    public Sprite image;
}

[Serializable]
public class City_SO:Compound_SO
{
    public int index;
}

[Serializable]
public class Village_SO : Compound_SO
{
    public int index;
   
}

[Serializable]
public class Castle_SO : Compound_SO
{
    public int index;

}


[CreateAssetMenu(fileName = "NewEntityData", menuName = "Entity Data")]
public class Compound_SO_BaseClass : ScriptableObject
{
    private static Compound_SO_BaseClass instance;

    public static Compound_SO_BaseClass Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<Compound_SO_BaseClass>("Compound_SO/CompoundEntity");
            }

            return instance;

        }

    }

    [Header("Soldier Barrack")]
    public int barrackGold = 500;
    public int barrackMetal = 500;
    public int barrackWood = 500;
    public int barrackCement = 500;

    [Header("Bazaar")]
    public int bazaarGold = 500;
    public int bazaarMetal = 500;
    public int bazaarWood = 500;
    public int bazaarCement = 500;

    [Header("Forge")]
    public int forgeGold = 500;
    public int forgeMetal = 500;
    public int forgeWood = 500;
    public int forgeCement = 500;

    [Header("Bakery")]
    public int bakeryGold = 500;
    public int bakeryMetal = 500;
    public int bakeryWood = 500;
    public int bakeryCement = 500;

    [Header("Shop")]
    public int shopGold = 500;
    public int shopMetal = 500;
    public int shopWood = 500;
    public int shopCement = 500;

    public City_SO[] city_SO;
    public Castle_SO[] castle_SO;
    public Village_SO[] village_SO;

}
