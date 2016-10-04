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
            //Vector3 spawnPos = new Vector3(10.0F,0.5F,10.0F);
            Vector3 spawnPos = new Vector3(Random.Range(-19.0F, 19.0F), y, Random.Range(-19.0F, 19.0F));
            //Vector3 spawnPos = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), y, Random.Range(-spawnValues.z, spawnValues.z));
            //Random.Range(-spawnValues.x, spawnValues.x), y, Random.Range(-spawnValues.z, spawnValues.z)
            Instantiate(enemyPrefab, spawnPos + transform.TransformPoint(0,0,0), gameObject.transform.rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
