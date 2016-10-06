using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed;
    private int count;
    private Rigidbody rb;
    public Text countText;
    public Text winText;
    public Text ruleText;
    public GameObject enemy;
    // Use this for initialization
    /*void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        ruleText.text = "Collect 15 tokens to win and Avoid the black sphere";
        SetCountText();
        ruleText.text = "";
        winText.text = "";
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (gameObject!=null)
        {
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(movement * speed);
        }
       
        
    }
    void OnTriggerEnter(Collider other)
    {
        //Collect the object and increase the count
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        //Winning Condition
        if (count == 15)
        {
            winText.text = "You Win!";       
            //gameObject.SetActive(false);
            enemy.SetActive(false);
            Destroy(enemy);
            StartCoroutine(pause());
            
            
        }
    }
    // Restart the scene
    IEnumerator pause()
    {
        yield return new WaitForSeconds(5);
        ruleText.text = "Restarting the game";
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
