using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCommander : MonoBehaviour
{
    [SerializeField] GameObject Swarm;
    [SerializeField] GameObject Player;
    GameObject Judge; //In the future, since I know that the SceneCommander is Always goingto be in the same room as the Judge, I should have all the Score and Judge stuff go through the Commander insteasd of willynilly througought the different scripts. Formatiing was never a strong suit.
    ScoreCounter scoreCounter;

    private void Start()
    {
        Judge = GameObject.Find("Judge");
        scoreCounter = Judge.GetComponent<ScoreCounter>();
    }
    void Update()
    {
        int currentSceneNumb = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneNumb == 0)
        {
            SceneManager.LoadScene(1);//Scene 0 is just for loading the immortal Judge that watches the game and tracks the points
        }

        if (Swarm)
        {
            if (Swarm.transform.childCount <= 0 && currentSceneNumb < SceneManager.sceneCountInBuildSettings - 1) //killed all
            {
                SceneManager.LoadScene(currentSceneNumb + 1);//Load next level
            }
            else if (Swarm.transform.childCount <= 0 && currentSceneNumb == SceneManager.sceneCountInBuildSettings - 1) //killed all and last level
            {
                scoreCounter.playerStatus = 1; //won
                SceneManager.LoadScene(1);//Menu
            }
            else if (Player.gameObject.GetComponent<CollisionHandler>().health <= 0) //died
            {
                scoreCounter.playerStatus = 0; //lost
                SceneManager.LoadScene(1);//Menu
            }
        }
        
    }
}
