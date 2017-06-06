script_manager = {}

script_manager.script_environment = { --the base for a script, currently not used
	print = print
	--etc...
}

script_manager.programs = {}

function script_manager:run_function(id, func_name)
	local script = self.programs[id]
	if script == nil then return end
	
	local func = script[func_name]
	if func == nil then return end

	func()
end

function script_manager:add(id, )