using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using UnityEditor;

public class ExampleScript : MonoBehaviour
{
    // Start is called before the first frame update

    Dictionary<string, Type> typeDict;

    void Start()
    {
        typeDict = new Dictionary<string, Type>();
        string[] allAnimalTypes = System.IO.Directory.GetFiles(Application.dataPath + "/Animals/", "*.cs");
        string[] allAnimalSprite = System.IO.Directory.GetFiles(Application.dataPath + "/AnimalSprite/", "*.png");

       
        for (int i = 0; i < allAnimalTypes.Length; i++)
        {
            allAnimalTypes[i] = System.IO.Path.GetFileNameWithoutExtension(allAnimalTypes[i]);
            allAnimalSprite[i] = System.IO.Path.GetFileNameWithoutExtension(allAnimalSprite[i]);

        }

        Debug.Log(allAnimalSprite[0]);

        foreach (string petAnim in allAnimalTypes)
        {
            typeDict.Add(petAnim,Type.GetType(petAnim));

 
        }

        foreach(KeyValuePair<string, Type> kv in typeDict)
        {
            CreateAnimal(kv.Value);
        }    

      
    }
   
    void Update()
    {
        
    }

    private void MyFunc<T>(T typeExample)
    {
        Type t = typeof(T);
    }


    private void CreateAnimal(Type animalType)
    {

        GameObject newPetObj = null;


        try
        {
            newPetObj = new GameObject();
            //System.Type petType = Type.GetType(animalType);
            Pet pet = (Pet)newPetObj.AddComponent(animalType);
            string petType = animalType.Name;

            newPetObj.AddComponent<SpriteRenderer>();
            

            UnityEditor.PrefabUtility.SaveAsPrefabAsset(newPetObj, "Assets/Resources/AnimalPrefabs/" + petType + ".prefab");


            
            //pet.PetThePet();
        }
        catch (Exception E)
        {

            Debug.LogError("Failed to create Animal , Error : " + E.ToString());
            GameObject.Destroy(newPetObj);
        }


    }
}
