using DG.Tweening;
//using System;
using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using Play.HD.Singleton;
//using UnityEngine.UIElements;


public class PlayerMove : MonoBehaviour
{
    
    public bool inGame { get; private set; }
    public float speed { get; private set; }
    public bool noDeath { get; private set; }
    public Vector3 newScale { get; private set; }
    
    [Header("Sets")]
    public float oldSpeed;
    public float latSpeed;
    public float tapDist;
    public GameManager manager;
    public bool isJump = false;
   
    
    [Header("FBXs")]
    public GameObject cube;
    public GameObject shield;
    public GameObject magnetic;
    public GameObject smoke;
    public ParticleSystem skull;
    public AnimatorManager animatorManager;

    [Header("SFX")]
    public AudioClip audioPowerUp;
    public AudioClip audioDeath; 
    public AudioClip audioWin;
    
    private Vector2 startTouch, toTouch;
    
    private float moveTouch;
    [SerializeField]
    private float limtsPlane, forceUp;
    private float minY;
    private Rigidbody rb;
    private Vector3 oldScale;
    private AudioSource audioSource;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inGame = false;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        //audioSource.mute = true;
        minY = transform.position.y;
        speed =  oldSpeed;
        oldScale = Vector3.one;
        shield.SetActive(false);
        magnetic.SetActive(false);
        smoke.SetActive(false);
        animatorManager.OnPlay(AnimatorManager.typeAnimator.IDLE);
    }

    // Update is called once per frame
    void Update()
    {

        if (inGame == false) return;
        
        
        // uso do touch
        if (Input.touchCount > 0)
        {
            
            
            Touch toque = Input.GetTouch(0);
            Debug.Log(toque.tapCount);

            // In�cio do toque
            if (toque.phase == TouchPhase.Began)
            {
                startTouch = toque.position;
                //Debug.Log("inicio");
            }

            // Arrastando
            if (toque.phase == TouchPhase.Moved )
            {
                moveTouch = toque.position.x - startTouch.x;
                toTouch = toque.position;
                //Debug.Log("move" + moveTouch);
            }

            /*
            if((startTouch - toTouch).magnitude < tapDist && toque.phase == TouchPhase.Ended && isJump==false)
            {
                StartCoroutine(jump());
                isJump = true;
                
            }
            */
            
            // Fim do toque
            if (toque.phase == TouchPhase.Ended )
            {
                moveTouch = 0f ;
                //Debug.Log("fim");
            }

            



        }
        
        // uso do mouse
        
        if(Input.GetMouseButton(0)) 
        {
        
            moveTouch = (Input.mousePosition.x - startTouch.x) *10f;
            
        
        }
        startTouch = Input.mousePosition;
        

        movedPlayer();
    
    
    
    
    
    }


    private void movedPlayer()
    {
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, transform.position+ moveTouch * Vector3.right * latSpeed, Time.deltaTime * latSpeed);
        //transform.DOMoveX(transform.position.x + moveTouch * latSpeed * Time.deltaTime, Time.deltaTime * latSpeed);
        //transform.Translate(moveTouch * Vector3.right * latSpeed * Time.deltaTime);

        if (transform.position.x >limtsPlane)
        { 
            transform.position = new Vector3(limtsPlane,transform.position.y,transform.position.z);
        }
        
        if (transform.position.x < -limtsPlane)
        {
            transform.position = new Vector3(-limtsPlane, transform.position.y, transform.position.z);
        }
         /*
        if(transform.position.y <= minY)
        {
            transform.position = new Vector3(transform.position.x,minY,transform.position.z);
            isJump = false;
        }
         */
    }


    public void changeRun()
    {
        inGame = !inGame;
        if (inGame)
        {
            animatorManager.OnPlay(AnimatorManager.typeAnimator.RUN);
        }
    
    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            if(noDeath == false)
            {
                manager.reeStart();
                inGame = false;
                animatorManager.OnPlay(AnimatorManager.typeAnimator.DEAD);
                transform.DOMoveZ(-1f, 0.2f).SetRelative();
                skull.Play();
                audioSource.clip = audioDeath;
                audioSource.Play();
            }
            else
            {
                if(collision.gameObject.GetComponent<Wall_efects>() != null)
                {
                    collision.gameObject.GetComponent<Wall_efects>().invencibleImpact();
                }
                else
                {
                    Debug.Log("Wall n�o encontrado");
                }
                
            }
            
        }
        
        if (collision.gameObject.CompareTag("EndLine"))
        {
            manager.endLine();
            inGame = false;
            animatorManager.OnPlay(AnimatorManager.typeAnimator.IDLE);
            audioSource.clip = audioWin;
            audioSource.Play();
        }

        if (collision.gameObject.CompareTag("plane"))
        {
            isJump = false;
        }

        if (collision.gameObject.CompareTag("PowerUp"))
        {
           transform.DOScale(1.3f,.1f).SetLoops(4, LoopType.Yoyo);
           audioSource.clip = audioPowerUp;
           audioSource.Play();
        }
    }


    public void powerUpSpeed(float newSpeed, float istime)
    {
        speed = speed * newSpeed;
        if(speed > oldSpeed)
        {
            smoke.SetActive(true);
        }
        animatorManager.OnPlay(AnimatorManager.typeAnimator.RUN, newSpeed / oldSpeed);
        Invoke("resetPowerUps", istime);
        
    }

    public void doNewScale(float scale,float istime)
    {
        //transform.localScale = oldScale * scale;
        transform.DOScale(oldScale * scale, 1f);
        Invoke("resetPowerUps", istime);
    }


    public void PowerUpNoDeath(float istime)
    {
        noDeath = true;
        shield.SetActive(true);
        Invoke("resetPowerUps", istime);
    }

    public void PowerUpMagnetic(float istime = 3f) // PowerUpMagnetic
    {
        magnetic.SetActive(true);
        Invoke("resetPowerUps", istime);
    }

    public void PowerUpJump()
    {
        StartCoroutine(jump());
        isJump = true;
    }




    private void resetPowerUps()
    {
        speed = oldSpeed;
        smoke.SetActive(false);
        transform.DOScale(oldScale, 1f);
        shield.SetActive(false);
        noDeath = false;  
        magnetic.SetActive(false);
        if (inGame)
        {
            animatorManager.OnPlay(AnimatorManager.typeAnimator.RUN);
        }
    }







    IEnumerator jump()
    {
        rb.useGravity = true;
        rb.AddForce(Vector3.up * forceUp, ForceMode.Impulse);
        yield return new WaitForSeconds(1f);
        //rb.useGravity = false;
        
    }

}
