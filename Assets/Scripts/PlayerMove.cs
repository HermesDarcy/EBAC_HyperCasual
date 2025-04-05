using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    public bool inGame { get; private set; }
    public float speed;
    public float latSpeed;
    public float tapDist;
    public GameManager manager;
    public Vector2 startTouch, toTouch;
    public float moveTouch;
    [SerializeField]
    private float limtsPlane, forceUp;
    private float minY;
    private Rigidbody rb;
    public bool isJump = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inGame = false;
        rb = GetComponent<Rigidbody>();
        minY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (inGame == false) return;
        
        
        // uso do touch
        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);
            

            // Início do toque
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

            if((startTouch - toTouch).magnitude < tapDist && toque.phase == TouchPhase.Ended && isJump==false)
            {
                StartCoroutine(jump());
                isJump = true;
                
            }
            
            
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            manager.reeStart();
            inGame = false;
        }
        
        if (collision.gameObject.CompareTag("EndLine"))
        {
            manager.endLine();
            inGame = false;
        }

        if (collision.gameObject.CompareTag("plane"))
        {
            isJump = false;
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
