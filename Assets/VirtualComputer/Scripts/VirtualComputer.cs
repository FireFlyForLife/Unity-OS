using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LuaBindings;
using UnityEngine;
using LuaInterface;

namespace InGameComputer
{
    public class VirtualComputer : MonoBehaviour
    {
        public Canvas Screen;
        public AudioSource Audio;
        public ProgramManager ProgramManager;

        //Reference to the Lua virtual machine
        public Lua luaVM;
        //Filename of the Lua file to load in the Streaming Assets folder
        //public string LuaFileToLoad = "";

        void Start()
        {
            Audio = GetComponent<AudioSource>();

            InitProgramHolder();

            InitLua();
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
            luaVM.DoFile(Application.streamingAssetsPath + "/" + "luademo.lua");

            //Trigger binding in c# to call the bound Lua function
            binding.MessageToLua();
        }

        void InitProgramHolder()
        {
            Transform procTransform = transform.Find("Programs");

            GameObject programHolder;
            if (procTransform)
            {
                programHolder = procTransform.gameObject;
                ProgramManager = programHolder.GetComponent<ProgramManager>();
                if (!ProgramManager)
                {
                    ProgramManager = programHolder.AddComponent<ProgramManager>();
                }
            }
            else
            {
                programHolder = new GameObject("Programs", typeof(RectTransform), typeof(ProgramManager));
                programHolder.transform.SetParent(transform, false);
                programHolder.transform.SetAsFirstSibling();

                ProgramManager = programHolder.GetComponent<ProgramManager>();
            }
        }

        void Update()
        {
            
        }

        //Program StartProgram()
        //{
        //    Program program = programHolder.AddComponent<Program>();
        //    program.Init();

        //    Programs.Add(program);

        //    return program;
        //}

        //void CloseProgram(Program program)
        //{
        //    int index = Programs.IndexOf(program);
        //    if (index != -1)
        //        CloseProgram(index);
        //}

        //void CloseProgram(int ProgramIndex)
        //{
        //    Program program = Programs[ProgramIndex];
        //    program.Close();
        //    Programs.RemoveAt(ProgramIndex);
        //}

        //void OnDisable()
        //{
        //    for (int i = 0; i < Programs.Count; i++)
        //    {
        //        CloseProgram(i);
        //    }
        //}
    } 
}
