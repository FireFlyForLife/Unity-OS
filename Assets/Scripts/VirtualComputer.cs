using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;

public class VirtualComputer : MonoBehaviour
{
    public Canvas Screen;

    //Reference to the Lua virtual machine
    private Lua luaVirtualMachine;
    //Filename of the Lua file to load in the Streaming Assets folder
    public string LuaFileToLoad = "";

    void Start () {

        //Init LuaBinding class that demonstrates communication
        LuaBinding binding = new LuaBinding();

        //Init instance of Lua virtual machine (Note: Can only init ONCE)
        luaVirtualMachine = new Lua();
        //Tell Lua about the LuaBinding object to allow Lua to call C# functions
        luaVirtualMachine["luabinding"] = binding;

        //Run the code contained within the file
        luaVirtualMachine.DoFile(Application.streamingAssetsPath + "/" + LuaFileToLoad);

        //Trigger binding in c# to call the bound Lua function
        binding.MessageToLua();
	}
	
	void Update () {
		
	}
}
