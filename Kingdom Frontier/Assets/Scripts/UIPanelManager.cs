using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        OnMouseClick();

        if (isPanelActive)
        {
            panel.gameObject.SetActive(true);
        }
        else
        {
            panel.gameObject.SetActive(false);

        }

    }

    private void OnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "City" && !isPanelActive)
                {
                    CompoundManager compoundManager = hit.collider.gameObject.GetComponent<CompoundManager>();
                    int compoundIndex = compoundManager.index;
                    compoundManager.compound.CompoundInitialize(compoundIndex);
                    isPanelActive = true;
                    compoundName.text = compoundManager.compound.name;
                    image.sprite = compoundManager.compound.image;
                    profit.text = "Yearly Profit: " + compoundManager.compound.Profit().ToString();
                    compoundLevel.text = "City Level: " + compoundManager.level;
                    

                }
                else if (hit.collider.gameObject.tag == "Village" && !isPanelActive)
                {
                    CompoundManager compoundManager = hit.collider.gameObject.GetComponent<CompoundManager>();
                    int compoundIndex = compoundManager.index;
                    compoundManager.compound.CompoundInitialize(compoundIndex);
                    isPanelActive = true;
                    compoundName.text = compoundManager.compound.name;
                    image.sprite = compoundManager.compound.image;
                    profit.text = "Yearly Profit: " + compoundManager.compound.Profit().ToString();
                    compoundLevel.text = "Village Level: " + compoundManager.level;
                   

                }
                else if (hit.collider.gameObject.tag == "Castle" && !isPanelActive)
                {
                    CompoundManager compoundManager = hit.collider.gameObject.GetComponent<CompoundManager>();
                    int compoundIndex = compoundManager.index;
                    compoundManager.compound.CompoundInitialize(compoundIndex);
                    isPanelActive = true;
                    compoundName.text = compoundManager.compound.name;
                    image.sprite = compoundManager.compound.image;
                    profit.text = "Yearly Profit: " + compoundManager.compound.Profit().ToString();
                    compoundLevel.text = "Castle Level: " + compoundManager.level;


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



}
