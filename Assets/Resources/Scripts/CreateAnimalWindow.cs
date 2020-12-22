using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class CreateAnimalWindow : EditorWindow
{
    [MenuItem("Custom Tools/ Create Animal Prefabs")]

    public static void CreateShowCase()
    {
        EditorWindow window = GetWindow<CreateAnimalWindow>("Create Animal Prefabs");
    }

    Dictionary<string, Type> typeDict;
    public void OnGUI()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Create Prefabs"))
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
                typeDict.Add(petAnim, Type.GetType(petAnim));


            }

            foreach (KeyValuePair<string, Type> kv in typeDict)
            {
                CreateAnimal(kv.Value);
            }
        }
        GUILayout.EndHorizontal();

    }

    private void CreateAnimal(Type animalType)
    {

        GameObject newPetObj = null;


        try
        {
            newPetObj = new GameObject();
            newPetObj.name = animalType.Name;

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
    //private void MyFunc<T>(T typeExample)
    //{
    //    Type t = typeof(T);
    //}
    public void OnEnable()
    {


        
    }


}
