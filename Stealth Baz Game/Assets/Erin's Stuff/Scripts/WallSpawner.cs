using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{

    public GameObject Brick;
    public float Waittime;
    public Transform SpawnPoint;
    public float wallheight, wallwidth, wallthickness;
    public float despawntime;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(SpawnWall());
        }
        
    }
    IEnumerator SpawnWall()
    {
        for (int z = 0; z < wallthickness; z++)
        {
            for (int y = 0; y < wallheight; y++)
            {
                for (int i = 0; i < wallwidth; i++)
                {
                    var position = new Vector3(i, y, z*2);


                    GameObject brick = Instantiate(Brick, position + SpawnPoint.position, Quaternion.identity);


                    yield return new WaitForSeconds(Waittime);
                    Destroy(brick, despawntime);
                }
            }
        }
        //StartCoroutine(SpawnWall());
    }
}
