using System.Collections.Generic;
using UnityEngine;
using Play.HD.Singleton;

public class ArtManager : Singleton<ArtManager>
{
    public List<GameObject> objArts = new List<GameObject>();
    public List<Material> materials = new List<Material>();
    public ArtType artType;// {  get; private set; }
    public List<LevelSetup> levelSetups = new List<LevelSetup>();


    public enum ArtType
    {
        type_1,
        type_2,
        type_3,
        forest,
        snow,
        nono
    }


    public void newArttype(ArtType type)
    {
        artType = type;
    }


    public GameObject typeArt()
    {
        switch (artType)
        {
            case ArtType.type_1:
                return objArts[0];
            case ArtType.type_2:
                return objArts[1];
            case ArtType.type_3:
                return objArts[2];
            case ArtType.forest:
                return objArts[3];
            case ArtType.snow:
                return objArts[4];

        }

        return null;

    }

    public Material typeMaterial()
    {
        switch (artType)
        {
            case ArtType.type_1:
                return levelSetups[0].materialType;
            case ArtType.type_2:
                return levelSetups[1].materialType;
            case ArtType.type_3:
                return levelSetups[2].materialType;
            case ArtType.forest:
                return levelSetups[3].materialType;
            case ArtType.snow:
                return levelSetups[4].materialType;


        }

        return null;
    }

    public Color typeColor()
    {
        switch (artType)
        {
            case ArtType.type_1:
                return levelSetups[0].colorType;
            case ArtType.type_2:
                return levelSetups[1].colorType;
            case ArtType.type_3:
                return levelSetups[2].colorType;
            case ArtType.forest:
                return levelSetups[3].colorType;
            case ArtType.snow:
                return levelSetups[4].colorType;


        }

        return Color.green;
    }




    public void ChangeLevelArtType(ArtManager.ArtType artType)
    {
        var setup = levelSetups.Find(i=> i.type == artType);
        
    
    }

    
   
}

[System.Serializable]
public class LevelSetup
{
    public ArtManager.ArtType type;
    public Material materialType;
    public Color colorType;
}