using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGameComputer
{
    public interface IProgram
    {
        void Init();

        void Tick();

        void Close();
    } 
}
