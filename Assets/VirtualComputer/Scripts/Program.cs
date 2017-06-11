using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGameComputer
{
    public class Program : MonoBehaviour, IProgram
    {
        public VirtualComputer Computer { get; private set; }

        #region Convenience_Propperties
        public ProgramManager ProgramManager {
            get {
                if (Computer != null)
                    return Computer.ProgramManager;
                return null;
            }
        }
        #endregion

        public Window Window { get; private set; }

        public void SetupComputer(VirtualComputer pc, Window w)
        {
            Computer = pc;
            Window = w;
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