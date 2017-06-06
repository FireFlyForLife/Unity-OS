using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LuaInterface;

namespace InGameComputer
{
    public class LuaProgram : Program
    {
        public string ScriptId { get; set; }

        public override void Init()
        {
            runFunction("init");
        }

        public override void Tick()
        {
            runFunction("tick");
        }

        public override void Close()
        {
            runFunction("close");
        }

        private void runFunction(string function)
        {
            LuaTable programTable = Computer.luaVM.GetTable("program[" + ScriptId + "]");

            if (programTable == null) return;
            
            foreach (object key in programTable.Keys)
            {
                string name = key as string;
                if (name != null && name == function)
                {
                    LuaFunction func = programTable[function+"()"] as LuaFunction;
                    if (func != null)
                    {
                        func.Call();
                    }
                }
            }
            
        }
    } 
}

