using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour {

    public GameObject Enemy;
    public int spawnTime;

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("Spawn");
    }

    public void startUp()
    {
        StartCoroutine("Spawn");
    }
    // Update is called once per frame
    IEnumerator Spawn()
    {
 
        { 
            yield return new WaitForSeconds(spawnTime);
            Instantiate(Enemy, transform.position, Quaternion.identity);
        }
    }
}
