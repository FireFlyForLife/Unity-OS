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

        public List<IProgram> Programs;

        public LuaFunction on_tick;

        void Start()
        {
            Computer = GetComponentInParent<VirtualComputer>();

            IProgram[] programs = GetComponents<IProgram>();
            Programs = new List<IProgram>(programs);

            foreach (IProgram program in Programs)
            {
                program.Init(new string[0]);
            }
        }

        void Update()
        {
            on_tick.CallIfNotNull();
        }

        public T StartCustomProgram<T>(string[] args = null) where T : Component, IProgram
        {
            T program = gameObject.AddComponent<T>();

            AddCustomProgram(program, args);

            return program;
        }

        public void AddCustomProgram(IProgram program, string[] args = null)
        {
            Programs.Add(program);

            program.Init(args ?? new string[0]);
        }

        public T StartProgram<T>(string[] args = null) where T : Program
        {
            T program = gameObject.AddComponent<T>();

            AddProgram(program, args);

            return program;
        }

        public void AddProgram(Program program, string[] args = null)
        {
            Programs.Add(program);

            program.SetupComputer(Computer);

            program.Init(args ?? new string[0]);
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
