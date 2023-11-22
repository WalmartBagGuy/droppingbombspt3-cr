using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Spawner spawner;
    public GameObject title;
    private Vector2 screenBounds;
    public GameObject playerPrefab
    private GameObject player;
    private bool gameStarted = false;
        
        void Awake()
        {
            spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
            screenBounds = camera.main.ScreenToWorldPoint(new Vector3 (Screen.width, Screen.height, Camera.main.transform.position.z));
            player = playerPrefab;
        }
    void Start()
    {
        spawner.active = false;
        title.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
     if(!gameStarted) 
     { 
       if (Input.anyKeyDown)
       {
              //spawner.active = true;
              //title.SetActive(false);
              ResetGame();
       }
     }
    }
    var nextBomb = GameObject.FindGameObjectsWithTag("Bomb");

    foreach (GameObject bombObgect in nextBomb)
    {
        if (bombObgect.transform.position.y < (-screenBounds.y) - 12)
        {
            Destroy(bombObgect);
        }
    }
    void ResetGame()
    {
        spawner.active = true;
        title.SetActive(false);
        player = Instantiate(playerPrefab, new Vector3(0,0,0), playerPrefab.transform.rotation);
        gameStarted = true;

    }
}
