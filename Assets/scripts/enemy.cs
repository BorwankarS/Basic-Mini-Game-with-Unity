﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class enemy : MonoBehaviour {
    Transform enemy_pos;
    public GameObject player;
    public float f_RotSpeed;
    public float f_MoveSpeed;
    public Text lostText;
    // Use this for initialization
    void Start () {
        lostText.text = "";
        enemy_pos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    IEnumerator restartScene()
    {
        f_RotSpeed = 0f;
        f_MoveSpeed = 0f;
        yield return new WaitForSeconds(5);
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
    // Update is called once per frame
    void Update () {
        
        if (player!=null)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(enemy_pos.position - transform.position), f_RotSpeed * Time.deltaTime);

            transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
        }
       
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            lostText.text = "You Lost The Game!";
            StartCoroutine(restartScene());
        }

    }
}
