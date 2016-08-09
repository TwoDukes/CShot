using UnityEngine;
using System.Collections;

public class wallPos : MonoBehaviour {

    public enum Pos { top, bottom, left, right};
    public Pos myPos;
	// Use this for initialization
	void Start () {

        switch (myPos)
        {
            case Pos.top:
                transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1, 0));
                break;

            case Pos.bottom:
                transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f , 0, 0));
                break;

            case Pos.left:
                transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0 , 0.5f, 0));
                break;

            case Pos.right:
                transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1 , 0.5f, 0));
                break;


        }
        
    }



}
