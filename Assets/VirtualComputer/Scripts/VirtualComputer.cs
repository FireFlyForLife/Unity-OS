﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LuaBindings;
using UnityEngine;
using LuaInterface;

public class VirtualComputer : MonoBehaviour
{
    public Canvas Screen;
    public List<Program> Programs = new List<Program>(); //TODO: Make this visible in the inspector
    private GameObject programHolder;

    //Reference to the Lua virtual machine
    private Lua luaVM;
    //Filename of the Lua file to load in the Streaming Assets folder
    public string LuaFileToLoad = "";

    void Start () {
        InitLua();
        InitProgramHolder();
    }

    void InitLua()
    {
        //Init LuaBinding class that demonstrates communication
        LuaBinding binding = new LuaBinding();
        DebugBinding debug = new DebugBinding();

        //Init instance of Lua virtual machine (Note: Can only init ONCE)
        luaVM = new Lua();
        luaVM.DoFile(Application.streamingAssetsPath + Path.DirectorySeparatorChar + "vm.lua");
        //Tell Lua about the LuaBinding object to allow Lua to call C# functions
        luaVM["luabinding"] = binding;
        luaVM["debug"] = debug;

        //Run the code contained within the file
        luaVM.DoFile(Application.streamingAssetsPath + "/" + LuaFileToLoad);

        //Trigger binding in c# to call the bound Lua function
        binding.MessageToLua();
    }

    void InitProgramHolder()
    {
        programHolder = new GameObject("Programs", typeof(RectTransform));
        programHolder.transform.SetParent(transform, false);
        programHolder.transform.SetAsFirstSibling();
    }
	
	void Update () {
	    foreach (Program program in Programs)
	    {
	        if (program.enabled)
	        {
	            program.Tick();
	        }
	    }
	}

    Program StartProgram()
    {
        Program program = programHolder.AddComponent<Program>();
        program.Init();

        Programs.Add(program);

        return program;
    }

    void CloseProgram(Program program)
    {
        int index = Programs.IndexOf(program);
        if(index != -1)
            CloseProgram(index);
    }

    void CloseProgram(int ProgramIndex)
    {
        Program program = Programs[ProgramIndex];
        program.Close();
        Programs.RemoveAt(ProgramIndex);
    }

    void OnDisable()
    {
        for (int i = 0; i < Programs.Count; i++)
        {
            CloseProgram(i);
        }
    }
}