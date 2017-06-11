using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGameComputer
{
    public interface IProgram
    {
        void Init(string[] args);

        void Tick();

        void Close();
    } 
}
