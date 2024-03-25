using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using UnityEditor.PackageManager;

public class UIPanelManager : MonoBehaviour
{
    private static UIPanelManager instance;

    [Header("Compound Panel")]
    [SerializeField] private TMP_Text compoundName;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text profit;    
    [SerializeField] private GameObject panel;
    private RaycastHit hit;
    public bool isPanelActive;

    [Header("Manage Panel")]
    [SerializeField] private RectTransform managePanel;
    private float transitionDuration = 0.5f;
    private bool isManagePanelActive;
    private Vector2 startPosition;
    private Vector2 endPosition;
    [SerializeField] private TMP_Text compoundLevel;
    [SerializeField] private TMP_Text compoundGold;
    [SerializeField] private TMP_Text compoundMetal;
    [SerializeField] private TMP_Text compoundWood;
    [SerializeField] private TMP_Text compoundCement;

    //Upgrades
    [SerializeField] private TMP_Text barrack;
    [SerializeField] private TMP_Text bazaar;
    [SerializeField] private TMP_Text forge;
    [SerializeField] private TMP_Text bakery;
    [SerializeField] private TMP_Text shop;

    //Timer
    [SerializeField] private TMP_Text timerText;
    CompoundManager _compoundManager;


    public static UIPanelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIPanelManager>();
            }

            return instance;
        }
    }


    void Start()
    {
        startPosition = new Vector2(-1320.0f, 0.0f);
        endPosition = new Vector2(-90.0f, 0.0f);
        managePanel.anchoredPosition = startPosition;
        isManagePanelActive = false;
        isPanelActive = false;
        panel.gameObject.SetActive(false);
       
    }

    
    void Update()
    {

        if (isPanelActive)
        {
            panel.gameObject.SetActive(true);
        }
        else
        {
            panel.gameObject.SetActive(false);
        }
        OnMouseClick();

        if(isManagePanelActive)
            timerText.text = _compoundManager.timeText;


    }

    private void OnMouseClick()
    {    

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.GetComponent<CompoundManager>() != null)
                {
                    if (!isPanelActive)
                    {

                        isPanelActive = true;
                        CompoundManager compoundManager = hit.collider.gameObject.GetComponent<CompoundManager>();
                        _compoundManager = compoundManager;
                        
                        compoundGold.text = "Gold: " + compoundManager.gold;
                        compoundMetal.text = "Metal: " + compoundManager.metal;
                        compoundWood.text = "Wood: " + compoundManager.wood;
                        compoundCement.text = "Cement: " + compoundManager.cement;

                        barrack.text = "Barrack: " + compoundManager.barrack;
                        bazaar.text = "Bazaar: " + compoundManager.bazaar;
                        forge.text = "Forge: " + compoundManager.forge;
                        bakery.text = "Bakery: " + compoundManager.bakery;
                        shop.text = "Shop: " + compoundManager.shop;

                        

                        if (hit.collider.gameObject.tag == "City")
                        {
                            int compoundIndex = compoundManager.index;
                            compoundManager.compound.CompoundInitialize(compoundIndex);
                            compoundName.text = compoundManager.compound.name;
                            image.sprite = compoundManager.compound.image;
                            profit.text = "Yearly Profit: " + compoundManager.compound.Profit().ToString();
                            compoundLevel.text = "City Level: " + compoundManager.level;
                        }
                        else if (hit.collider.gameObject.tag == "Village")
                        {
                            int compoundIndex = compoundManager.index;
                            compoundManager.compound.CompoundInitialize(compoundIndex);
                            compoundName.text = compoundManager.compound.name;
                            image.sprite = compoundManager.compound.image;
                            profit.text = "Yearly Profit: " + compoundManager.compound.Profit().ToString();
                            compoundLevel.text = "Village Level: " + compoundManager.level;
                        }
                        else if (hit.collider.gameObject.tag == "Castle")
                        {
                            int compoundIndex = compoundManager.index;
                            compoundManager.compound.CompoundInitialize(compoundIndex);
                            compoundName.text = compoundManager.compound.name;
                            image.sprite = compoundManager.compound.image;
                            profit.text = "Yearly Profit: " + compoundManager.compound.Profit().ToString();
                            compoundLevel.text = "Castle Level: " + compoundManager.level;
                        }
                    }
                }
                else
                {
                    return;
                }

                
            }
        }
    }

    public void ClosePanel()
    {
        if (isPanelActive && !isManagePanelActive)
        {
            isPanelActive = false;
            panel.gameObject.SetActive(false);
        }
        
        
    }

    public void Manage()
    {
        if (!isManagePanelActive)
        {
            StartCoroutine(AnimatePanel(startPosition, endPosition));
            isManagePanelActive = true;


        }
        else if (isManagePanelActive)
        {
            StartCoroutine(AnimatePanel(endPosition, startPosition));
            isManagePanelActive = false;
        }
    }

    IEnumerator AnimatePanel(Vector2 from, Vector2 to)
    {
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            managePanel.anchoredPosition = Vector2.Lerp(from, to, elapsedTime / transitionDuration);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        managePanel.anchoredPosition = to;

    }

    public void BuildBarracks()
    {
        _compoundManager.BuildBarrack();

        
    }


   



}
