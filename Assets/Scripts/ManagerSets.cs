using UnityEngine;
using Play.HD.Singleton;

public class ManagerSets : Singleton<ManagerSets>
{
    public float playerSpeed;
    public float playerlatSpeed;
    public int numsteps = 10;
    public int nunLevel = 0;
    public int score = 0;


    public void newLevel(int sc)
    {
        numsteps += 5;
        nunLevel++;
        playerSpeed++;
        int k = Random.Range(0, 6);
        ArtManager.Instance.newArttype(k);
        score += sc;
    }

    public void ResetLevels()
    {
        numsteps = 10;
        nunLevel = 0;
        score = 0;
        playerSpeed =10;
    }


}
