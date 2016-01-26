using UnityEngine;
using System.Collections;

public class FoodEnlarge : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
		/*if (col.gameObject.tag.Equals ("Player") && (this.gameObject.GetComponent<Food>().isShoot)) {
			if (col.gameObject.GetComponent<ColorChanger> ().mycolor == this.gameObject.GetComponent<ColorChanger> ().mycolor)
				col.gameObject.SendMessage ("Enlarge");
			else
				col.gameObject.SendMessage ("Shrink");
			Destroy (this.gameObject);
		}*/
	}
}
