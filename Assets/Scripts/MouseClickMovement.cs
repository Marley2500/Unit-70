using UnityEngine;
using UnityEngine.AI;


public class MouseClickMovement : MonoBehaviour
{

    private NavMeshAgent agent;
    public GameObject powerUpObject;


    void Awake()

    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()

    {

        if (Input.GetMouseButtonDown(0))

        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))

            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
