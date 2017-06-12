using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotepadProgram : Program
{
    public override void Init(string[] args)
    {
        if (args.Length > 0)
        {
            int id = Convert.ToInt16(args[0]);
        }
    }

    public override void Tick()
    {
        
    }

    public override void Close()
    {
        
    }
}
