using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MoveToBigSlime : MonoBehaviour
{

    private Material material;
    public GameObject player;
    // public Transform goal;
    public Vector3 StartPosition;
    public string tagtodetect;
    public string State;
    public NavMeshAgent agent;
    public Animator animator;
    public bool playerseen = false;

    public float losetime;
    public float searchtime;
    public float maxsearchtime;
    public Color basecolour;

    public GameObject HeldEye;





    private void Start()
    {
        var renderer = GetComponent<SkinnedMeshRenderer>();
        material = Instantiate(renderer.sharedMaterial);
        renderer.material = material;
        searchtime = maxsearchtime;
        animator = GetComponent<Animator>();
        StartPosition = transform.position;
        player = GameObject.FindGameObjectWithTag(tagtodetect);
        agent = GetComponent<NavMeshAgent>();


    }

    private void OnDestroy()
    {
        if (material != null)
        {
            Destroy(material);
        }
    }

    void Update()
    {

        EnemyState();
    }

    void EnemyState()
    {
        switch (State)
        {

            case "Chase":

                //  player = GameObject.FindGameObjectWithTag(tagtodetect);

                agent.destination = player.gameObject.transform.position;

                break;

            case "Idle":
                // NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.destination = StartPosition;
                material.SetColor("Colour", basecolour);


                break;

            case "LosingPlayer":

                agent.destination = player.gameObject.transform.position;
                losetime -= 1;
                if (losetime <= 0)
                {
                    State = "Searching";
                    agent.stoppingDistance = 0f;

                    animator.SetBool("FoundPlayer", true);
                    losetime = 600;

                }


                break;

            case "EyeFind":
                if (searchtime == maxsearchtime)
                {
                    material.SetColor("Colour", Color.yellow);
                    StartCoroutine(SearchingForPlayer());
                    Debug.Log("only once");
                }
                searchtime -= 1;
                if (searchtime <= 0)
                {
                    State = "Idle";
                    agent.stoppingDistance = 3f;

                    animator.SetBool("FoundPlayer", false);
                    searchtime = maxsearchtime;
                }
                break;
        }





    }


    IEnumerator SearchingForPlayer()
    {
        yield return new WaitForSeconds(2f);
        agent.destination = player.gameObject.transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            animator.SetBool("FoundPlayer", true);


            material.SetColor("Colour", Color.red);
            State = "Chase";
            agent.stoppingDistance = 0f;


        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            State = "LosingPlayer";

            losetime = 600;
        }
    }



}

