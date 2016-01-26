using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {
	public float rotationSpeed;
	public float speed;
	public int electricCharge;
	public float delay = 5;

	private float startExit;
    //public Vector3 startScale;
	//public bool isShoot;

    //private Transform target;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		startExit = 0;
		rb = GetComponent<Rigidbody> ();
        //startScale = transform.localScale;
		//isShoot = false;
	}

	//
	//transform.Translate(-col.transform.position*0.5f);
	//

	// Update is called once per frame
	void Update () {
		if (transform.parent != null) {
//			transform.LookAt (transform.parent.position, transform.up);
			transform.RotateAround (transform.parent.position, transform.forward, rotationSpeed);	
			//rb.MovePosition(transform.position + transform.forward * speed);
			float distance = Vector3.Distance(transform.position, transform.parent.position);
			if(distance < transform.parent.GetComponent<SphereCollider>().radius)
				transform.position = Vector3.MoveTowards(transform.position,transform.parent.position , - speed);
			if(distance > transform.parent.GetComponent<SphereCollider>().radius)
				transform.position = Vector3.MoveTowards(transform.position,transform.parent.position ,  speed);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag.Equals("Food"))
		   {
			if(((col.gameObject.GetComponent<Food>().electricCharge * electricCharge) < 0) && (electricCharge > 0) && (transform.parent != col.gameObject.transform.parent) && (transform.parent!= null))
			{
                transform.parent.SendMessage("removeParticle");
                if (col.gameObject.transform.parent.GetComponent<Player>().countParticles < 4)
				{
					transform.parent = col.gameObject.transform.parent;
					transform.Translate(-col.gameObject.transform.position*0.5f);
					col.gameObject.transform.parent.SendMessage("addParticle");
				}
			}
			else if(((col.gameObject.GetComponent<Food>().electricCharge * electricCharge) > 0) && (transform.parent != col.gameObject.transform.parent) && (transform.parent != null))
			{
                transform.parent.SendMessage("removeParticle");
                col.gameObject.transform.parent.SendMessage("removeParticle"); ;
                transform.Translate(-col.transform.position*4f);
				transform.parent = null;
				startExit = Time.time;
				col.gameObject.transform.Translate(-col.transform.position*4f);
				col.gameObject.transform.parent = null;
				col.gameObject.GetComponent<Food>().startExit = Time.time;
			}
		}
	}

	public void setParent( Transform newparent)
	{
        if (((Time.time - startExit) > delay) || (startExit == 0))
        {
            transform.SetParent(newparent);
            transform.parent.SendMessage("addParticle");
        }
	}

    void OnDestroy()
    {
        GameController.instance.removeFood();
    }

	/*public void Shoot(float shoot)
	{
		target = null;
		transform.SetParent (null);
        rb.AddForce(transform.forward * -shoot);
        transform.localScale = startScale;
	}*/

	/*public void setIsShoot()
	{
		isShoot = true;
	}*/
}
