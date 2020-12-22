using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        name = this.GetType().ToString();
       // Debug.Log("My pet type is : " + name);
        
    }

    // Update is called once per frame
   public void PetThePet()
    {
        Debug.Log("You have patted : " + name);
    }
}
