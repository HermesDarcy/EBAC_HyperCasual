using UnityEngine;
using DG.Tweening;

public class ArtStep : MonoBehaviour  // placa e lateral
{
    
    private MeshRenderer mr;
    public ArtManager artManager;
    private float dgTime = 1f;
    private Ease ease = Ease.OutBack;
    

    private void Start()
    {
        artManager = GameObject.Find("ArtManager").GetComponent<ArtManager>();
        mr = GetComponent<MeshRenderer>();
        newMaterial(artManager.typeMaterial());
        changeColor(artManager.typeColor());
    }


    private void newMaterial(Material mat)
    {
        if (mat == null) return;
        
        mr.material = mat;
    }

    private void changeColor(Color cor)
    {
        foreach (Transform child in transform)
        {
            if(child.CompareTag("plate"))
            {
                child.GetComponent<MeshRenderer>().material.color = Color.white;
                child.GetComponent<MeshRenderer>().material.DOColor(cor,dgTime).SetEase(ease);
            }
        }
        
    }


    
}
