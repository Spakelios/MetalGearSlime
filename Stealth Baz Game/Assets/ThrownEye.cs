using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownEye : MonoBehaviour
{
    private Material material;
    public GameObject BigSlime;
    public Light eyelight;
    public GameObject player;
    public Rigidbody rb;
    public TrailRenderer trail;
    public Gradient gred, gyellow, gpink;
    //public SphereCollider eyeradius;

    private void Start()
    {
        var renderer = GetComponent<MeshRenderer>();
        material = Instantiate(renderer.sharedMaterial);
        renderer.material = material;
        BigSlime.GetComponent<MoveToBigSlime>().State = "EyeFind";
        material.SetColor("Colour", Color.yellow);
        material.SetColor("FColour", Color.yellow);
        trail.colorGradient = gyellow; 
        eyelight.color = (Color.yellow);

        gameObject.transform.LookAt(player.transform.position);
        rb.AddForce(transform.forward * 50);
        Debug.Log("yeahnoitsworking");
    }

    void OnEnable()
    {

        gameObject.transform.LookAt(player.transform.position + new Vector3(0,3,0));
        rb.AddForce(transform.forward * 500);
        Debug.Log("yeahnoitsworking");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BigSlime.GetComponent<MoveToBigSlime>().State = "Chase";
            material.SetColor("Colour", Color.red);
            material.SetColor("FColour", Color.red);
            eyelight.color = (Color.red);
            trail.colorGradient = gred;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trail.colorGradient = gyellow;
            eyelight.color = (Color.yellow);
            material.SetColor("Colour", Color.yellow);
            material.SetColor("FColour", Color.yellow);
            BigSlime.GetComponent<MoveToBigSlime>().State = "EyeFind";
        }
    }

    private void OnDestroy()
    {
        if (material != null)
        {
            Destroy(material);
        }
    }

}
