using System;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using NUnit.Compatibility;
using UnityEngine;

namespace InGameComputer
{
    public class ProgramManager : MonoBehaviour
    {
        public VirtualComputer Computer;

        public List<IProgram> Programs = new List<IProgram>();
        public List<Program> StartupPrograms = new List<Program>();

        public LuaFunction on_tick;

        void Start()
        {
            Computer = GetComponentInParent<VirtualComputer>();
        }

        void Update()
        {
            on_tick.CallIfNotNull();
        }

        public T StartProgram<T>() where T : Program
        {
            T program = gameObject.AddComponent<T>();
            
            program.Init();

            AddProgram(program);

            return program;
        }

        public void AddProgram(IProgram program)
        {
            Programs.Add(program);
        }

        public void AddProgram(Program program)
        {
            
        }

        public void CloseProgram(IProgram program)
        {
            int index = Programs.IndexOf(program);
            if (index != -1)
                CloseProgram(index);
        }

        public void CloseProgram(int programIndex)
        {
            IProgram program = Programs[programIndex];
            program.Close();
            Programs.RemoveAt(programIndex);
        }
    }
}
