using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    private Slider[] slider;
    [SerializeField] private TMP_Text[] soldierAmount;
    
    public int takenArchers;
    public int takenInfantries;
    public int takenCavalries;
    private int currentArchers;
    private int currentInfantries;
    private int currentCavalries;

    void Start()
    {
        slider = GetComponentsInChildren<Slider>();
    }


    void Update()
    {
        currentArchers = UIPanelManager.Instance._compoundManager.archerQuantity;
        currentInfantries = UIPanelManager.Instance._compoundManager.infantryQuantity;
        currentCavalries = UIPanelManager.Instance._compoundManager.cavalryQuantity;


        slider[0].maxValue = currentArchers;
        takenArchers = (int)slider[0].value;
        soldierAmount[0].text = takenArchers.ToString();

        slider[1].maxValue = currentInfantries;
        takenInfantries = (int)slider[1].value;
        soldierAmount[1].text = takenInfantries.ToString();

        slider[2].maxValue = currentCavalries;
        takenCavalries = (int)slider[2].value;
        soldierAmount[2].text = takenCavalries.ToString();

        
    }

    public void TakeSoldiers()
    {
        PlayerController.Instance.GetComponentInChildren<CompoundUIManager>().soldierQuantity += takenArchers + takenCavalries + takenInfantries;

        UIPanelManager.Instance._compoundManager.archerQuantity -= takenArchers;
        UIPanelManager.Instance._compoundManager.infantryQuantity -= takenInfantries;
        UIPanelManager.Instance._compoundManager.cavalryQuantity -= takenCavalries;

        UIPanelManager.Instance.archerText.text = "Archer: " + UIPanelManager.Instance._compoundManager.archerQuantity;
        UIPanelManager.Instance.infantryText.text = "Infantry: " + UIPanelManager.Instance._compoundManager.infantryQuantity;
        UIPanelManager.Instance.cavalryText.text = "Cavalry: " + UIPanelManager.Instance._compoundManager.cavalryQuantity;

        slider[0].value = 0;
        slider[1].value = 0;
        slider[2].value = 0;

    }



}
