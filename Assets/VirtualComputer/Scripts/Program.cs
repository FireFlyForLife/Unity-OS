using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGameComputer
{
    public class  ProgramStartArguments<TProgram> where TProgram : Component, IProgram
    {
        
    }

    public class Program : MonoBehaviour, IProgram
    {
        public VirtualComputer Computer { get; private set; }

        #region Convenience Propperties
        public ProgramManager ProgramManager { get { return Computer != null ? Computer.ProgramManager : null; } }
        #endregion

        [SerializeField]private Window window;
        public Window Window
        {
            get { return window; }
            private set { window = value; }
        }
        
        //if Window is empty
        public GameObject WindowPrefab;

        public void SetupComputer(VirtualComputer pc)
        {
            Computer = pc;
            if (!Window)
            {
                Window = Computer.CreateWindow(WindowPrefab);
            }
        }

        public virtual void Init() { }
        public virtual void Init(string[] args)
        {
            Init();
        }
        public virtual void Tick() { }
        public virtual void Close() { }

    } 
}