using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int killCount = 0;
   // public int bulletsDestroyedCount = 0;
    public int bossKillCount = 0;
    public int scoreTotal = 0;
    public int playerStatus = -1; //-1 == notPlayed, 0 == Lost, 1 == Won, 11 == error (not used now but may later for trycatches and the like)

    public void Start()
    {
        playerStatus = -1;  
    }
    private void Update()
    {
        scoreTotal = (killCount*10) /*+ (bulletsDestroyedCount * 1)*/ + (bossKillCount * 200);
    }
}
