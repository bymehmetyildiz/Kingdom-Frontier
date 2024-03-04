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


    public City_SO[] city_SO;
    public Castle_SO[] castle_SO;
    public Village_SO[] village_SO;

}
