using UnityEngine;
using System.Collections;

public class EmitterBase : MonoBehaviour {

    public GameObject Red, Green;
    public int shots, shotsTarget;
    public float speed, startDelay;
    bool firing = true;

    GameObject player;



	// Use this for initialization
	void Start () {
        
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("Spawn");
    }
	
    void Update()
    {
        if (player.GetComponent<playerController>().alive != true)
        {
            firing = false;
        }
        else if(firing == false && player.GetComponent<playerController>().alive == true)
        {
            firing = true;
            StartCoroutine("Spawn");
        }
    }

    IEnumerator Spawn()
    {
        GameObject tempG, tempR;
        yield return new WaitForSeconds(0.5f);

        while (firing) {
            float rand = Random.Range(0, 4);
            if(rand < 3)
            {
                tempR = Instantiate(Red, transform.position, Quaternion.identity) as GameObject;
                //tempR.transform.parent = gameObject.transform;
            }
            else
            {
                tempG = Instantiate(Green, transform.position, Quaternion.identity) as GameObject;
                //tempG.transform.parent = gameObject.transform;
            }
            yield return new WaitForSeconds(startDelay);
            shots++;
        }
        
    }
}
