using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] public TMP_Text menuText;
    GameObject Judge;
    ScoreCounter scoreCounter;

    private void Start()
    {
        Judge = GameObject.Find("Judge");
        scoreCounter = Judge.GetComponent<ScoreCounter>();
    }
    void Update()
    {
        int kills = scoreCounter.killCount;
        //int bulletsDestroyed = scoreCounter.bulletsDestroyedCount;
        int bossKills = scoreCounter.bossKillCount;
        int score = scoreCounter.scoreTotal;
        int playerStatus = scoreCounter.playerStatus;
        
        if (playerStatus == 1)
        {
            menuText.text = $"Congrats! You beat the game!\n\n" +
                $"Kills: {kills} X10 points\n" +
            //$"Bullets: {bulletsDestroyed} X1 point\n" +
            $"Boss: {bossKills} X200 points\n" +
            $"Total Score: {score}";
        } else if (playerStatus == 0)
        {
            menuText.text = $"Dang thats rough\n\n" +
                $"Kills: {kills} X10 points\n" +
            //$"Bullets: {bulletsDestroyed} X1 point\n" +
            $"Boss: {bossKills} X200 points\n" +
            $"Total Score: {score}";
        }else if (playerStatus == -1)
        {
            menuText.text = $"A Newcomer!\n" +
                $"Always nice to see";
        } else
        {
            menuText.text = $"ERROR";
        }
    }
}
