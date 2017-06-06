using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGameComputer
{
    public abstract class Program : MonoBehaviour, IProgram
    {
        public VirtualComputer Computer { get; private set; }
        public ProgramManager ProgramManager { get; private set; }
        public Window Window { get; private set; }

        public void SetupComputer(VirtualComputer pc, ProgramManager m, Window w)
        {
            Computer = pc;
            ProgramManager = m;
            Window = w;
        }

        public abstract void Init();
        public abstract void Tick();
        public abstract void Close();

    } 
}