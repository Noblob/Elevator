using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorUp : MonoBehaviour
{
    public float up = 100f;
    public float range = 3f;

    public GameObject elevator;
    public bool isRasing = false;

    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Shoot();
        }
    }

    void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                StartCoroutine(MoveElevator());
            }
        }
    }

    IEnumerator MoveElevator()
    {
        isRasing = true;
        elevator.GetComponent<Animator>().Play("Elevator Up");
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(30.0f);
        elevator.GetComponent<Animator>().Play("New State");
        isRasing = false;
    }
}
