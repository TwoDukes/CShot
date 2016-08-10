using UnityEngine;
using System.Collections;

public class EmitterBase : MonoBehaviour {

    public GameObject Red, Green, health;
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
        GameObject tempG, tempR, tempH;
        yield return new WaitForSeconds(0.5f);

        while (firing) {
            float rand = Random.Range(0, 10);
            if(rand < 6)
            {
                tempR = Instantiate(Red, transform.position, Quaternion.identity) as GameObject;
                //tempR.transform.parent = gameObject.transform;
            }
            else if( rand < 9)
            {
               tempG = Instantiate(Green, transform.position, Quaternion.identity) as GameObject;
                //tempG.transform.parent = gameObject.transform;
            }
            else
            {
                tempH = Instantiate(health, transform.position, Quaternion.identity) as GameObject;
            }
            yield return new WaitForSeconds(startDelay);
            shots++;
        }
        
    }
}
