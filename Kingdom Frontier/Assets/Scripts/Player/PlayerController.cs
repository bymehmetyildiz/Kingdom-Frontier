using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;
    public static PlayerController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerController>();
            }

            return instance;
        }
    }

    public bool openMenu;

    private Camera mainCamera;
    private NavMeshAgent agent;
    private Animator animator;

    public CompoundManager compoundManager;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
        openMenu = false;
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // Attempt to move the agent to a point sampled on the NavMesh
                if (NavMesh.SamplePosition(hit.point, out NavMeshHit navHit, 1.0f, NavMesh.AllAreas))
                {
                    agent.SetDestination(navHit.position);
                }
                else if (hit.collider.gameObject.GetComponent<CompoundManager>() != null)
                {
                    // If there's a CompoundManager, set the destination to the hit's position
                    agent.SetDestination(hit.transform.position);
                }
            }
        }
        
        Aninmation();
    }

    private void Aninmation()
    {
        animator.SetFloat("velocity", agent.velocity.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<CompoundManager>() != null)
        {
            openMenu = true;
            compoundManager = other.GetComponent<CompoundManager>();            
        }
       
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<CompoundManager>() != null)
        {
            UIPanelManager.Instance.ClosePanel();
        }
    }

}
