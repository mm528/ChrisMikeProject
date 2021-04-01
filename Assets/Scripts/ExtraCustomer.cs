using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ExtraCustomer : MonoBehaviour
{
    private float nextFire = 0.0f;
    private float fireRate = 0.5f;
    public Transform position;
    public NavMeshAgent Agent;
    public Vector3 myPos2;
    private float moveSpeed = 0.8f;
    private int count = 0;
    public GameObject[] extraCustomer;
    private int listnu = 0;
    private bool answer=true;
    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        myPos2 = transform.position;

        // Agent.speed = 0;
        extraCustomer = GameObject.FindGameObjectsWithTag("ExtraC");
        extraCustomer[listnu].GetComponent<NavMeshAgent>().acceleration = 30f; //Change Speed in order to COME more Customer IN
        //Debug.Log(extraCustomer.Length);

    }

    // Update is called once per frame
    void Update()
    {

        if (count == 9)
        {
            Debug.Log("Here");

            count = 0;
            // MoveToCheckpoint(GameObject.Find("" + count).transform.position);
        }

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
        }
        if (nextFire > 3)
        {
            nextFire = 0;
            if (listnu <= extraCustomer.Length-1)
            {
                extraCustomer[listnu].GetComponent<NavMeshAgent>().speed = 30f; //Change Speed in order to COME more Customer IN
                 extraCustomer[listnu].GetComponent<NavMeshAgent>().acceleration = 20f; //Change Speed in order to COME more Customer IN
                  extraCustomer[listnu].GetComponent<NavMeshAgent>().angularSpeed = 8f; //Change Speed in order to COME more Customer IN
                 MoveToCheckpoint(GameObject.Find("" + count).transform.position);
                 
            }else{
                answer = false;
                 MoveToCheckpoint(GameObject.Find("" + count).transform.position);
            }

        }

          


        







    }

    void MoveToCheckpoint(Vector3 point)
    {

        Vector3 myPos = transform.position;
        Vector3 difference = point - myPos;
        Vector3 direction = difference.normalized;


        transform.position += direction * Time.deltaTime * moveSpeed;
        //transform.rotation = Quaternion.LookRotation(direction);



        Agent.isStopped = false;
        Agent.SetDestination(point);


    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("" + count))
        {
            if (answer == true){
            listnu++;
            };
            int previous = count;
            //Destroy(other);
            count = Random.Range(0, 8) + 1;
            while (count == previous)
            {
                count = Random.Range(0, 6);
            }
            // Debug.Log("Touch");
        };


    }

}
