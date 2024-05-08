using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompoundUIManager : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public TMP_Text compoundName;
    public int soldierQuantity = 15;


    private void Start()
    {
        if (target.gameObject.name == "Player")
        {
            compoundName.text = soldierQuantity.ToString();

        }
        else
        {
            compoundName.text = target.gameObject.name.ToString();

        }

    }
    void FixedUpdate()
    {

        compoundName.transform.position = Camera.main.WorldToScreenPoint(target.position + offset);
    }

   
}
