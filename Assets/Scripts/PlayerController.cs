using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
    private int count;
	public float speed;
    public Text countText;
    
    public Text winText;
    
	void Start() 
	{
		rb = GetComponent<Rigidbody> ();
        count = 0;
        SetCountText(); 
        winText.text = string.Empty;
	}

	void FixedUpdate () 
	{ 
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		rb.AddForce (movement * speed);
	}
    
    void OnTriggerEnter (Collider other) 
    {
        if (other.gameObject.CompareTag("Pick Up")) 
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
            
            GameObject[] pickups = GameObject.FindGameObjectsWithTag(@"Pick Up");
            
            if (pickups.Length == 0) {
                winText.text = "You Win!!";
            }
        }
    }
    
    void SetCountText() 
    {
        countText.text = string.Format("Count: {0}", count.ToString());
    }
}
