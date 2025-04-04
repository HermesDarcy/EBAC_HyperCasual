using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool inGame { get; private set; }
    public float speed;
    public float latSpeed;
    public GameManager manager;
    private float startTouch, moveTouch;
    [SerializeField]
    private float limtsPlane;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inGame = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (inGame == false) return;
        
        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);
            

            // Início do toque
            if (toque.phase == TouchPhase.Began)
            {
                startTouch = toque.position.x;
                //Debug.Log("inicio");
            }

            // Arrastando
            if (toque.phase == TouchPhase.Moved )
            {
                moveTouch = toque.position.x - startTouch;
                //Debug.Log("move" + moveTouch);
            }

            // Fim do toque
            if (toque.phase == TouchPhase.Ended )
            {
                moveTouch = 0f ;
                //Debug.Log("fim");
            }
        }
        movedPlayer();
    }


    private void movedPlayer()
    {
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(moveTouch * Vector3.right * latSpeed * Time.deltaTime);
        if (transform.position.x >limtsPlane)
        { 
            transform.position = new Vector3(limtsPlane,transform.position.y,transform.position.z);
        }
        
        if (transform.position.x < -limtsPlane)
        {
            transform.position = new Vector3(-limtsPlane, transform.position.y, transform.position.z);
        }

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

        

    }

}
