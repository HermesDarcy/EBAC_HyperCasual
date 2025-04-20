using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject stepBegin, stepEnd;
    public List<GameObject> steps;
    public List<GameObject> elements;
    public Transform container;
    public int numSteps;
    
    private List<GameObject> levelSteps = new List<GameObject>();
    private List<GameObject> elementsSteps = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpanwSteps(numSteps);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ClearSteps();
            SpanwSteps(numSteps);
        }
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


}
