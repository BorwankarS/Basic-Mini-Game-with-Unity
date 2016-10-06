using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public GameObject player;
    public float xMin = 19F;
    public float xMax = -19F;
    public float zMin = 19F;
    public float zMax = -19F;
    private float y = 0.5F;
    public float spawnWait;
    public int startWait;
    public bool stop;
    public int no_of_objects=0;
    // Use this for initialization
    void Start () {
        StartCoroutine(waitSpawner());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);
        while (player!=null)
        {
            // Instantiate the new object within the field boundary
            Vector3 spawnPos = new Vector3(Random.Range(-19.0F, 19.0F), y, Random.Range(-19.0F, 19.0F));
            Instantiate(enemyPrefab, spawnPos + transform.TransformPoint(0,0,0), gameObject.transform.rotation);
            no_of_objects = no_of_objects + 2;
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
