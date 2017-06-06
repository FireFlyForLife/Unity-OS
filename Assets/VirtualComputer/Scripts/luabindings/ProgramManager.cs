using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;

namespace InGameComputer
{
    public class ProgramManager : MonoBehaviour
    {
        public LuaFunction on_tick;

        void Start()
        {

        }

        void Update()
        {
            on_tick.CallIfNotNull();
        }

        public void StartProgram(Program program)
        {

        }
    } 
}
