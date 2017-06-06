using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuaInterface
{
    public static class LuaFunctionExtension
    {
        public static object[] CallIfNotNull(this LuaFunction function, params object[] args)
        {
            if (function != null)
                return function.Call(args);

            return new object[0];
        }
    }
}