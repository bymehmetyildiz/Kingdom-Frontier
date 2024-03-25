using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Buttons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isPointerOver;

    [SerializeField] private TMP_Text gold;
    [SerializeField] private TMP_Text metal;
    [SerializeField] private TMP_Text wood;
    [SerializeField] private TMP_Text cement;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (isPointerOver)
        {
            if (this.gameObject.name == "BuildBarrack")
            {
                gold.text = "Gold: " + Compound_SO_BaseClass.Instance.barrackGold.ToString();
                metal.text = "Metal: " + Compound_SO_BaseClass.Instance.barrackMetal.ToString();
                wood.text = "Wood: " + Compound_SO_BaseClass.Instance.barrackWood.ToString();
                cement.text = "Cement: " + Compound_SO_BaseClass.Instance.barrackCement.ToString();
            }
            else if (this.gameObject.name == "BuildBazaar")
            {
                
                gold.text = "Gold: " + Compound_SO_BaseClass.Instance.bazaarGold.ToString();
                metal.text = "Metal: " + Compound_SO_BaseClass.Instance.bazaarMetal.ToString();
                wood.text = "Wood: " + Compound_SO_BaseClass.Instance.bazaarWood.ToString();
                cement.text = "Cement: " + Compound_SO_BaseClass.Instance.bazaarCement.ToString();
            }
            else if (this.gameObject.name == "BuildBlacksmith")
            {                
                gold.text = "Gold: " + Compound_SO_BaseClass.Instance.forgeGold.ToString();
                metal.text = "Metal: " + Compound_SO_BaseClass.Instance.forgeMetal.ToString();
                wood.text = "Wood: " + Compound_SO_BaseClass.Instance.forgeWood.ToString();
                cement.text = "Cement: " + Compound_SO_BaseClass.Instance.forgeCement.ToString();
            }
            else if (this.gameObject.name == "BuildBakery")
            {                
                gold.text = "Gold: " + Compound_SO_BaseClass.Instance.bakeryGold.ToString();
                metal.text = "Metal: " + Compound_SO_BaseClass.Instance.bakeryMetal.ToString();
                wood.text = "Wood: " + Compound_SO_BaseClass.Instance.bakeryWood.ToString();
                cement.text = "Cement: " + Compound_SO_BaseClass.Instance.bakeryCement.ToString();
            }
            else if (this.gameObject.name == "BuildWorkshop")
            {                
                gold.text = "Gold: " + Compound_SO_BaseClass.Instance.shopGold.ToString();
                metal.text = "Metal: " + Compound_SO_BaseClass.Instance.shopMetal.ToString();
                wood.text = "Wood: " + Compound_SO_BaseClass.Instance.shopWood.ToString();
                cement.text = "Cement: " + Compound_SO_BaseClass.Instance.shopCement.ToString();
            }
        }
        else
        {
            gold.text = "Gold: ";
            metal.text = "Metal: ";
            wood.text = "Wood: ";
            cement.text = "Cement: ";
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;
    }
}
