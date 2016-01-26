using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float speed;
    //public float disableTime;
	//[HideInInspector]
    //public float startDisable;
	//public float sizeModifier;
	//public int maxSizeChange;
	//public float shootForce = 100;
	public int countParticles;
    public int time2Death = 3;

    private Rigidbody rb;
    private float startCountdown;
    private bool isDying = false;
    //private Vector3 startposition;
    //private Quaternion startrotation;
    //private Vector3 startscale;
	//private int contEnlarge;
	//private GameObject myfood;
    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody> ();
        countParticles = 1;
        //startposition = transform.position;
        //startrotation = transform.rotation;
        //startscale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if(isDying)
        {
            Debug.Log((time2Death - (int)(Time.time - startCountdown)));
        }
        if(isDying && ((Time.time - startCountdown) > time2Death))
        {
            Destroy(this.gameObject);
        }
	}

	public void moveHorizontal(float direction)
	{
		transform.Translate ( transform.right * speed * direction);
	}

	public void moveVertical(float direction)
	{
		transform.Translate ( transform.up * speed * direction);
	}
	

	void OnCollisionEnter(Collision col)
	{
        /*if (col.gameObject.tag.Equals("Player"))
        {
            if ((col.gameObject.GetComponent<ColorChanger>().mycolor == this.gameObject.GetComponent<ColorChanger>().mycolor) && (transform.localScale.x < col.gameObject.transform.localScale.x))
            {
				col.gameObject.SendMessage("Enlarge");
                startDisable = Time.time;
                this.gameObject.SetActive(false);
            }
        }*/

    }

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag.Equals ("Food") && (col.gameObject.transform.parent == null) && (countParticles < 4)) {
			col.gameObject.SendMessage ("setParent", this.gameObject.transform);
			//myfood = col.gameObject;
		}
    }

    public void addParticle()
    {
        if(countParticles == 0)
            isDying = false;
        countParticles++;
        if (countParticles == 4)
        {
            isDying = true;
            startCountdown = Time.time;
        }
    }

    public void removeParticle()
    {
        if (countParticles == 4)
            isDying = false;
        countParticles--;
        if (countParticles == 0)
        {
            isDying = true;
            startCountdown = Time.time;
        }
    }

	void OnTriggerExit(Collider col)
	{
		//if(col.gameObject.tag.Equals("Food"))
			//col.gameObject.SendMessage("unsetTarget");

    }

	/*void addSpeed(float speedAdder)
	{
		speed += speedAdder;
	}*/

	/*public void Enlarge()
	{
		if (contEnlarge < maxSizeChange) {
			transform.localScale += new Vector3 (sizeModifier, sizeModifier, sizeModifier);
			foreach (Transform child in transform) {
				float newScale = child.gameObject.GetComponent<Food> ().startScale.x / transform.localScale.x * startscale.x;
				child.gameObject.transform.localScale = new Vector3 (newScale, newScale, newScale);
			}
			contEnlarge ++;
		}
    }*/

	/*public void Shrink()
	{

	}*/

    /*public void PushAway()
    {
		myfood.SendMessage ("setIsShoot");
        myfood.SendMessage("Shoot", shootForce);
		//myfood.GetComponent<Rigidbody>().AddForce(shootForce * -myfood.transform.forward);
		myfood = null;
    }*/

    /*public void restart()
    {
        this.gameObject.SetActive(true);
        transform.position = startposition;
        transform.rotation = startrotation;
        transform.localScale = startscale;
    }*/
}
