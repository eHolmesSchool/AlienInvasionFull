using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCommander : MonoBehaviour
{
    [SerializeField] GameObject Swarm;
    [SerializeField] GameObject Player;

    // Update is called once per frame
    void Update()
    {
        int currentSceneNumb = SceneManager.GetActiveScene().buildIndex;

        if (Swarm.transform.childCount <= 0 && currentSceneNumb < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(currentSceneNumb + 1);
        }
        else if (Swarm.transform.childCount <= 0 && currentSceneNumb == SceneManager.sceneCountInBuildSettings - 1 || Player.gameObject.GetComponent<CollisionHandler>().health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
