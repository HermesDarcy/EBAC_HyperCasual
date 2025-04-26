using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;



public class GameManager : MonoBehaviour
{

    [Header("Manager")]
    public bool onGame;
    public OrbitalManager orbitalManager;
    public float rotationSpeed = 30f;
    

    [Header("UI")]
    public GameObject pGame;
    public GameObject pStart,pReStart;
    public TMP_Text coinText, textCoinP, levelText;
    public Image imVict, imDefeat;

    [Header("Player_sets")]
    public PlayerMove playerMove;
    public float speed;
    public float latSpeed;
    private int coins;
    private float limtsPlane;


    [Header("Buttons")]
    public GameObject buttonRestart;
    public GameObject buttonNextLevel;
    
    


    


    private void Awake()
    {
        ManagerSets managerSets = new ManagerSets();
        managerSets = GameObject.FindAnyObjectByType<ManagerSets>();
        speed = managerSets.playerSpeed;
        playerMove.oldSpeed = speed;
        latSpeed = managerSets.playerlatSpeed;
        playerMove.latSpeed = latSpeed;

        int k = Random.Range(0, 7);
        //artManager.newArttype(k);

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pGame.SetActive(false);
        pStart.SetActive(true);
        pReStart.SetActive(false);
        imDefeat.gameObject.SetActive(false);
        coins = ManagerSets.Instance.score;
        int k = Random.Range(0, 6);
        levelText.text = "LEVEL " + ManagerSets.Instance.nunLevel.ToString();
        //artManager.newArttype(k);
        //ArtManager.Instance.newArttype(k);
    }

    

    public void startGame()
    {
        pGame.SetActive(true);
        pStart.SetActive(false);
        coinText.text = coins.ToString();
        levelText.text = "LEVEL " +  ManagerSets.Instance.nunLevel.ToString();
        onGame = true;
        Invoke("TimeToStart",0.5f);
    }

    private void TimeToStart()
    {
        playerMove.changeRun();
    }


    public void reeStart()
    {
        pReStart.SetActive(true);
        pGame.SetActive(false);
        buttonRestart.SetActive(true);
        buttonNextLevel.SetActive(false);
        imDefeat.gameObject.SetActive(true);
        imDefeat.transform.DOScale(4, 1.5f);
        textCoinP.text = coins.ToString();
        orbitalManager.isOrbit = true;
        
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void endLine()
    {
        pReStart.SetActive(true);
        pGame.SetActive(false);
        buttonRestart.SetActive(false);
        buttonNextLevel.SetActive(true);
        imVict.gameObject.SetActive(true);
        imVict.transform.DOScale(4, 1.5f);
        textCoinP.text = coins.ToString();
        orbitalManager.isOrbit = true;



    }

    public void ReStartScene(int s = 0)
    {
        ManagerSets.Instance.ResetLevels();
        Scene scene = SceneManager.GetActiveScene();
        //Debug.Log(scene.name);
        SceneManager.LoadScene(s);

    }

    public void NextLevel(int s = 0)
    {

        ManagerSets.Instance.newLevel(coins);
        
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
        SceneManager.LoadScene(s);
    }


    public void addCoins(int c = 1)
    {
        coins += c;
        coinText.text = coins.ToString();
        
    }

}

