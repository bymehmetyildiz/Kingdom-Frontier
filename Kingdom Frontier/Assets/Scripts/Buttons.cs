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

    public bool interactable;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (isPointerOver)
        {
            if (this.gameObject.name == "BuildBarrack")
            {                
                gold.text = "Gold: " + Compound_SO_BaseClass.Instance.barrackGold;
                metal.text = "Metal: " + Compound_SO_BaseClass.Instance.barrackMetal;
                wood.text = "Wood: " + Compound_SO_BaseClass.Instance.barrackWood;
                cement.text = "Cement: " + Compound_SO_BaseClass.Instance.barrackCement;
            }
            else if (this.gameObject.name == "BuildBazaar")
            {
                 
                gold.text = "Gold: " + Compound_SO_BaseClass.Instance.bazaarGold;
                metal.text = "Metal: " + Compound_SO_BaseClass.Instance.bazaarMetal;
                wood.text = "Wood: " + Compound_SO_BaseClass.Instance.bazaarWood;
                cement.text = "Cement: " + Compound_SO_BaseClass.Instance.bazaarCement;
            }
            else if (this.gameObject.name == "BuildBlacksmith")
            {
                
                gold.text = "Gold: " + Compound_SO_BaseClass.Instance.forgeGold;
                metal.text = "Metal: " + Compound_SO_BaseClass.Instance.forgeMetal;
                wood.text = "Wood: " + Compound_SO_BaseClass.Instance.forgeWood;
                cement.text = "Cement: " + Compound_SO_BaseClass.Instance.forgeCement;
            }
            else if (this.gameObject.name == "BuildBakery")
            {
                
                gold.text = "Gold: " + Compound_SO_BaseClass.Instance.bakeryGold;
                metal.text = "Metal: " + Compound_SO_BaseClass.Instance.bakeryMetal;
                wood.text = "Wood: " + Compound_SO_BaseClass.Instance.bakeryWood;
                cement.text = "Cement: " + Compound_SO_BaseClass.Instance.bakeryCement;
            }
            else if (this.gameObject.name == "BuildWorkshop")
            {
                
                gold.text = "Gold: " + Compound_SO_BaseClass.Instance.shopGold;
                metal.text = "Metal: " + Compound_SO_BaseClass.Instance.shopMetal;
                wood.text = "Wood: " + Compound_SO_BaseClass.Instance.shopWood;
                cement.text = "Cement: " + Compound_SO_BaseClass.Instance.shopCement;
            }
            else
            {
                gold.text = "Gold: ";
                metal.text = "Metal: ";
                wood.text = "Wood: ";
                cement.text = "Cement: ";
            }
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
