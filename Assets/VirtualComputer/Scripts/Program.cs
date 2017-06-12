using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program : MonoBehaviour, IProgram
{
    public Window Window;
    public VirtualComputer Computer;

    public virtual void Init(string[] args)
    {
        Init();
    }

    public virtual void Init() { }

    public virtual void Tick() { }

    public virtual void Close() { }

    
}
