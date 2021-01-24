#### 1. Name the three things all variables have.

	All C# variables have a name, a type, and a value. The name is how you refer to it in code, and
	tell it apart from another variable. The type indicates what type of data can be stored in the
	variable. The value is the contents of the variable.

#### 2. True/False. All variables must always be declared before being used.

	True. You can only use a variable on or after the line it is used.

#### 3. How many times must a variable be declared?

	One. You can only declare a variable once. However, you can assign values to variables as many
	times as you want.

#### 4. Which of the following are legal C# variable names? `answer`, `1stValue, `value1`, `$message`, `delete-me`, `delete_me`, `PI`.

	`answer`, `value1`, `delete_me` and `PI` all follow the rules. A variable cannot begin with a
	number, so `1stValue` is not legal. A variable cannot contain the `$` symbol, so `$message` is
	not legal. A variable cannot contain a `-`, so `delete-me` is not legal.
	
	
#### 1.	True/False. Anything on the stack can be accessed at any time.

	False. The only things that can be accessed on the stack are things in the top frame--the current method.
	Everything else is buried away and not immediately accessible.

#### 2.	True/False. The stack keeps track of local variables.

	True. Local variables are placed on the stack.

#### 3.	True/False. The contents of a value type can be placed in the heap.

	True. Value types end up on the heap anytime they are a part of another object that lives on the heap.
	For example, an `int[]` will contain many value-typed variables directly inside, even though the entire
	array is on the heap.

#### 4.	True/False. The contents of a value type are always placed in the heap.

	False. When a value type is a local variable, then the contents of that variable will be on the stack
	and not the heap.

#### 5.	True/False. The contents of reference types are always placed in the heap.

	True. The variable containing a reference may be on the stack or the heap, but its contents will
	always live elsewhere, and always on the heap.

#### 6.	True/False. The garbage collector cleans up old, unused space on the heap and stack.

	False. It does do this for the heap, but the stack does not need help cleaning up old memory from
	the garbage collector.

#### 7.	True/False. If `a` and `b` are arrays that reference the same object, modifying a will affect b as well.

	True. They refer to the same object in memory, and thus a change made through one variable affects
	that shared object, and can be seen through the other reference.

#### 8.	True/False. If `a` and `b` are ints with the same value, modifying `a` will affect `b` as well.

	False. Value types represent different memory locations. In this case, `a` and `b` are separate
	locations; modifying one will change its own memory, but leave the other untouched.