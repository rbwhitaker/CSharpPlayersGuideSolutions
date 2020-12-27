#### 1.	True/False. You can attach a debugger to a program built in the Release configuration.

	True. It is a common mistake to think that you can only debug in the Debug configuration
	(after all, the name sort of implies that) but you can attach a debugger to any program.
	The Release configuration has optimized code that can sometimes make for a less effective
	debugging session, but it more or less works the same.

#### 2.	True/False. The Debug configuration creates larger and slower executables than Release.

	True. The Debug configuration (by default) is not optimized. So it will be a little bigger
	and a little slower.

#### 3.	True/False. The debugger will suspend your program if an unhandled exception occurs.

	True. When an exception is thrown, the debugger will suspend your program and give you a chance
	to inspect everything that is happening so that you can fix it.

#### 4.	True/False. In some cases, you can edit your source code while execution is paused and resume with the changes.

	True. This is one of the debugger and Visual Studio's nicest features. Not all situations
	allow for it. Take advantage of it when you can, but worst case, you close down your running
	program, make the edit, and recompile and rerun it.
