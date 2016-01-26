using UnityEngine;
using System.Collections;

public class FoodVelocity : MonoBehaviour {
	public float speedAdder;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /*void OnCollisionEnter(Collision col)
	{
        if (col.gameObject.tag.Equals("Player"))
        {
            col.gameObject.SendMessage("addSpeed", speedAdder);
            Destroy(this.gameObject);
        }
    }*/
}
