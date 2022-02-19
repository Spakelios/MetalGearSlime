using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownEye : MonoBehaviour
{
    private Material material;
    public GameObject BigSlime;
    public Light eyelight;
    //public SphereCollider eyeradius;

    private void Start()
    {
        var renderer = GetComponent<MeshRenderer>();
        material = Instantiate(renderer.sharedMaterial);
        renderer.material = material;
        BigSlime.GetComponent<MoveToBigSlime>().State = "EyeFind";
        material.SetColor("Colour", Color.yellow);
        material.SetColor("FColour", Color.yellow);
        eyelight.color = (Color.yellow);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BigSlime.GetComponent<MoveToBigSlime>().State = "Chase";
            material.SetColor("Colour", Color.red);
            material.SetColor("FColour", Color.red);
            eyelight.color = (Color.red);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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
