using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;


public class GameManager : MonoBehaviour
{
    
    public GameObject pGame,pStart,pReStart;
    public bool onGame;
    
    public TMP_Text coinText, textCoinP;
    public Image imVict, imDefeat;

    [Header("Player_sets")]
    public PlayerMove playerMove;
    public float speed;
    public float latSpeed;

    private int coins;
    private float limtsPlane;

    private void Awake()
    {
        playerMove.speed = speed;
        playerMove.latSpeed = latSpeed;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pGame.SetActive(false);
        pStart.SetActive(true);
        pReStart.SetActive(false);
        imDefeat.gameObject.SetActive(false);
        coins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        pGame.SetActive(true);
        pStart.SetActive(false);
        onGame = true;
        playerMove.changeRun();
    }

    public void reeStart()
    {
        pReStart.SetActive(true);
        pGame.SetActive(false);
        imDefeat.gameObject.SetActive(true);
        imDefeat.transform.DOScale(4, 1.5f);
        textCoinP.text = coins.ToString();

    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void endLine()
    {
        pReStart.SetActive(true);
        pGame.SetActive(false);
        imVict.gameObject.SetActive(true);
        imVict.transform.DOScale(4, 1.5f);
        textCoinP.text = coins.ToString();
    }

    public void startScene(int s = 0)
    {
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
