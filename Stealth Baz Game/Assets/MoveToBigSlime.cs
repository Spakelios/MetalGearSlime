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

    public bool isholdingeye;

    public GameObject HeldEye;
    public GameObject ThrownEye;





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
        Debug.Log(isholdingeye);
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
                animator.SetBool("HasEye", true);


                break;

            case "LosingPlayer":

                agent.destination = player.gameObject.transform.position;
                losetime -= 1;
                if (losetime <= 0)
                {
                    State = "EyeFind";
                    agent.stoppingDistance = 0f;

                   // animator.SetBool("FoundPlayer", true);
                    losetime = 600;

                }


                break;

            case "EyeFind":
                if (searchtime == maxsearchtime)
                {
                    material.SetColor("Colour", Color.yellow);
                    StartCoroutine(SearchingForEye());
                    Debug.Log("only once");
                }
                //searchtime -= 1;
               // if (searchtime <= 0)
               // {
               //     State = "Idle";
               //     agent.stoppingDistance = 3f;
               //
               //     animator.SetBool("FoundPlayer", false);
              //      searchtime = maxsearchtime;
              //  }
                break;
        }





    }


    IEnumerator SearchingForEye()
    {
        if (ThrownEye.activeSelf == true)
        { 
            tagtodetect = "Eye";
            player = GameObject.FindGameObjectWithTag(tagtodetect);
       
        
            yield return new WaitForSeconds(2f);
            agent.destination = player.gameObject.transform.position;
        }

    }

    private void OnTriggerEnter(Collider other)
    {

       // if (other.gameObject.CompareTag("Player") && isholdingeye == true)
        //{
//
  //          foundplayer();
    //        
    //

      //  }

        if (other.gameObject.CompareTag("Eye"))
        {
            isholdingeye = true;
            State = "Idle";
            HeldEye.SetActive(true);
            animator.SetBool("HasEye", true);
            losetime = 600;
            other.gameObject.SetActive(false);
        }
    }

   // private void OnTriggerExit(Collider other)
   // {

       // if (other.gameObject.CompareTag("Player"))
        //{/
          //  State = "LosingPlayer";

        //    losetime = 600;
      //  }
  //  }

    public void foundplayer()
    {
        isholdingeye = false;
        tagtodetect = "Player";
        player = GameObject.FindGameObjectWithTag(tagtodetect);

        animator.SetBool("HasEye", false);


        material.SetColor("Colour", Color.red);
        HeldEye.gameObject.SetActive(false);
        ThrownEye.gameObject.transform.position = HeldEye.transform.position + this.transform.up * 2;
        ThrownEye.gameObject.SetActive(true);


        //State = "Chase";
        agent.stoppingDistance = 0f;
    }

}

