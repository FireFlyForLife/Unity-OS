using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaBindings
{
    public class DebugBinding
    {
        public void log(string message)
        {
            Debug.Log(message);
        }
    }

}