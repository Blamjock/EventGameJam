using UnityEngine;
using System.Collections;

/*public enum myColors
{
	Blue,
	Green
}*/

public class GameController : MonoBehaviour {
	[HideInInspector]
	public static GameController instance;

	public Player player1;
	public Player player2;
    public GameObject spawnArea;
    public GameObject protonPrefab;
    public GameObject electronPrefab;
    public int maxFood;
    
    private int foodCount;
	//private myColors mycolor;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A))
			player1.moveHorizontal (-1);
		if (Input.GetKey (KeyCode.D) )
			player1.moveHorizontal (1);
		if (Input.GetKey (KeyCode.W))
			player1.moveVertical (1);
		if (Input.GetKey (KeyCode.S))
			player1.moveVertical (-1);
		
		if (Input.GetKey (KeyCode.LeftArrow))
			player2.moveHorizontal (-1);
		if (Input.GetKey (KeyCode.RightArrow))
			player2.moveHorizontal (1);
		if (Input.GetKey (KeyCode.UpArrow))
			player2.moveVertical (1);
		if (Input.GetKey (KeyCode.DownArrow))
			player2.moveVertical (-1);

        /*if (!player1.gameObject.activeSelf)
            if ((Time.time - player1.startDisable) > player1.disableTime)
                player1.restart();
        if (!player2.gameObject.activeSelf)
            if ((Time.time - player2.startDisable) > player2.disableTime)
                player2.restart();*/

        if(foodCount < maxFood)
        {
            Vector3 randomPosition;
            randomPosition.x = spawnArea.transform.position.x + Random.Range(-spawnArea.GetComponent<MeshRenderer>().bounds.extents.x, spawnArea.GetComponent<MeshRenderer>().bounds.extents.x);
            randomPosition.y = spawnArea.transform.position.y + Random.Range(-spawnArea.GetComponent<MeshRenderer>().bounds.extents.y, spawnArea.GetComponent<MeshRenderer>().bounds.extents.y);
            GameObject myprefab = (Random.Range(0, 2) == 0) ? protonPrefab : electronPrefab;
            randomPosition.z = myprefab.transform.position.z;
            GameObject enemy = Instantiate(myprefab, randomPosition, myprefab.transform.rotation) as GameObject;
            foodCount++;
        }
    }

    public void removeFood()
    {
        foodCount--;
    }
}
