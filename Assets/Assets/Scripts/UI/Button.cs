using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    string LevelName = "Level1";
    
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(LevelName);
    }
}