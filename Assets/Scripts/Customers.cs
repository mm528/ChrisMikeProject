using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customers : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform position;
    public NavMeshAgent Agent;
    public Vector3 myPos2; // Position Customer
    public float moveSpeed; //Speed of the Customer
    public int count; //Take each Checkpoint

    public List<GameObject> players;
    private bool actriveMethod = true;

    private float nextFire = 0.0f;
    private float fireRate = 0.5f;
    public GameObject[] extraCustomer;
    void activateMeth()
    {
       
        if (actriveMethod == true)
        {




        extraCustomer = GameObject.FindGameObjectsWithTag("ExtraC");
        actriveMethod = false;
        //     for (int k = 20; k <= 29; k++)
        //     {
        //         if (actriveMethod == true){
        //         players.Add(GameObject.Find("" + k));
        //         }
        //     }
        //     Debug.Log(players.Count);
        //     if (actriveMethod == true){
        //     foreach (GameObject pl in players)
        //     {
        //         //Debug.Log(pl.name);
        //         pl.SetActive(false);

        //     }
        //     };
        //     actriveMethod = false;
        // }
        // else
        // {
        //     Debug.Log("Not");
        // }
        }
    }
    void Start()
    {
      
        
        activateMeth();

        Agent = GetComponent<NavMeshAgent>();
        myPos2 = transform.position;

      

        for (int i = 0; i <= 8; i++)
        {
            GameObject.Find("" + i).GetComponent<Renderer>().enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
        }

      
        MoveToCheckpoint(GameObject.Find("" + count).transform.position);
        if (count == 9)
        {

            count = 0;
        }
    }

    void MoveToCheckpoint(Vector3 point)
    {

        Vector3 myPos = transform.position;
        Vector3 difference = point - myPos;
        Vector3 direction = difference.normalized;


        transform.position += direction * Time.deltaTime * moveSpeed;
        transform.rotation = Quaternion.LookRotation(direction);



        Agent.isStopped = false;
        Agent.SetDestination(point);


    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("" + count))
        {
            int previous = count;
            //Destroy(other);
            count = Random.Range(0, 7) + 1;
            while (count == previous)
            {
                count = Random.Range(0, 9);
            }
           // Debug.Log("Touch");
        };


    }

    void ActivateElementGameObjects(){
        int randomNumber = Random.Range(0,9);

            
         //Debug.Log(extraCustomer[randomNumber].name);
            


        }
    



}
