
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using Play.HD.Singleton;


public class LevelManager : MonoBehaviour
{

    public GameObject stepBegin, stepEnd;
    public List<GameObject> steps;
    public List<GameObject> elements;
    public Transform container;
    public int numSteps;
    public float durTime = 0.1f;
    public Ease ease = Ease.OutBack;
    
    private List<GameObject> levelSteps = new List<GameObject>();
    private List<GameObject> elementsSteps = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //int k = Random.Range(0, 6);
        //ArtManager.Instance.newArttype(k);
        numSteps = ManagerSets.Instance.numsteps;
        SpanwSteps(numSteps);
        container = GameObject.Find("container").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ClearSteps();
            SpanwSteps(numSteps);
            
            ZeroScaleSteps();
            StartCoroutine(ResetScaleSteps());
            int k = Random.Range(0, 6);
            ArtManager.Instance.newArttype(k);
        }
    }

    
    public void newLevel()
    {
        /*
        numSteps += 5;
        ClearSteps();
        SpanwSteps(numSteps);

        ZeroScaleSteps();
        StartCoroutine(ResetScaleSteps());
        */
        int k = Random.Range(0, 6);
        ArtManager.Instance.newArttype(k);
    }
    

    private void SpanwSteps(int ns)
    {
        GameObject temp = Instantiate(stepBegin,container);
        levelSteps.Add(temp);
        for (int i = 0; i < ns; i++)
        {
            int k = Random.Range(0, steps.Count);
            temp = Instantiate(steps[k], container);
            temp.transform.localPosition = levelSteps[i].transform.localPosition + new Vector3(0,0,12);
            levelSteps.Add(temp);
            //temp.GetComponent<StepArt>().CreateArt(artManager.typeArt());

            if(Random.Range(0,6) < 2)
            {
                float x = Random.Range(-5f, 5f);
                float z = Random.Range(1f, 11f);
                Vector3 tempPos = temp.transform.position + new Vector3(x, 1.2f, z);
                k = Random.Range(0, elements.Count);
                temp = Instantiate(elements[k], container);
                temp.transform.position = tempPos;
                elementsSteps.Add(temp);
            }
            

        }
        temp = Instantiate(stepEnd, container);
        temp.transform.localPosition = levelSteps[levelSteps.Count -1].transform.localPosition + new Vector3(0, 0, 12);
        levelSteps.Add(temp);

    }





    public void ClearSteps()
    {
        for(int i = levelSteps.Count-1; i >= 0; i--)  
        {
            Destroy(levelSteps[i].gameObject);
        }
        levelSteps.Clear();

        for (int i = elementsSteps.Count-1; i >= 0; i--)
        {
            Destroy(elementsSteps[i].gameObject);
        }
        elementsSteps.Clear(); 
    }


    private void ZeroScaleSteps()
    {
        foreach(var element in levelSteps)
        {
            element.transform.localScale = Vector3.zero;
        }
        foreach(var element in elementsSteps)
        {
            element.transform.localScale = Vector3.zero;
        }

    }


    IEnumerator ResetScaleSteps()
    {
        yield return new WaitForEndOfFrame();
        Debug.Log(levelSteps.Count);
        foreach (var element in levelSteps)
        {
            element.transform.DOScale(1,durTime).SetEase(ease);
            yield return new WaitForEndOfFrame();
        }
        foreach (var element in elementsSteps)
        {
            element.transform.DOScale(1, durTime).SetEase(ease);
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }

}
