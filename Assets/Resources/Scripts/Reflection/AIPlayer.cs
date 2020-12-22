using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Reflection;

public class AIPlayer : MonoBehaviour
{
    public int moveSpeed  ;
    public List<String> availabelCommands = new List<string>();
   





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //[ReflectionTarget]
    public void Move(Vector2 pos)
    {
        transform.position = pos;
    }

    [ReflectionTarget]
    public void Shoot(Vector2 direction)
    {

    }

    [ReflectionTarget]
    public void ChangeMoveSpeed(int newSpeed)
    {
        moveSpeed = newSpeed;

    }

    [ReflectionTarget]
    public void Speak(string NewName)
    {
        Debug.Log(NewName);
    }


    [ReflectionTarget]
    public void Wait()
    {
        Debug.Log("AI is waiting ");
    }

    [ReflectionTarget]
    public void NotUsingAttr()
    {

    }












}
