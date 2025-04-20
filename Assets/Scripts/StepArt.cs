using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class StepArt : MonoBehaviour
{
    
    public List<GameObject> objects = new List<GameObject>();
    public ArtManager artManager;
    
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        artManager = GameObject.Find("ArtManager").GetComponent<ArtManager>();
        
        CreateArt(artManager.typeArt());
        
        searchChilds();
    }




    public void CreateArt(GameObject obj, int num = 2)
    {
        if (obj == null) return;
        float div = 12 / (num+1);
        for (int i = 0; i < num; i++)
        {
            GameObject temp =  Instantiate(obj, transform);
            temp.transform.localPosition = new Vector3(-6.5f, 1f, div+div*i);
            temp = Instantiate(obj, transform);
            temp.transform.localPosition = new Vector3(6.5f, 1f, div + div * i);

        }
        searchChilds();
    }

    private void searchChilds()
    {
        foreach (Transform child in transform)
        {
            objects.Add(child.gameObject);
        }
        newColors();
        objects.Clear();
    }


   
    private void newColors()
    {
        Color cor = new Color(Random.value, Random.value, Random.value);
        foreach (var obj in objects)
        {
            if(obj.GetComponent<MeshRenderer>() != null && obj.CompareTag("Tree") ==  false)
            {
                obj.GetComponent<MeshRenderer>().material.color = cor;
            }
                   
            
        
        }
            
    }


}


        
    