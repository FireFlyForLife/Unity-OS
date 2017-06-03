function WriteFromLua(text)  -- Simple function to call the function inside LuaBinding.cs to out a message
	luabinding:MessageFromLua(text)
end

luabinding:BindMessageFunction(WriteFromLua)

luabinding:MessageFromLua("Welcome! lua here :)")

debug:log("Now my function!");