#### 1.	Which parameters are optional?

	`y` and `z` are optional. They both provide a default value.

#### 2.	What values do `x`, `y`, and `z` have if called with `DoSomething(1, 2);`

	The `1` is the argument given for `x`, the `2` is the argument given for `y`, and `z` will take on its default value, which is `4`.

#### 3.	What values do `x`, `y`, and `z` have if called with the following: `DoSomething(x: 2, z: 9);`

	The parameter `x` is given a value of `2`, `y` is not directly assigned anything but is optional and takes on its default value of `3`,
	and `z` is assigned a value of `9`.

#### 4.	True/False. Optional parameters must be defined after all required parameters.

	True. This is the rule. You cannot make some parameters optional and then go back to defining non-optional parameters.

#### 5.	True/False. A parameter that has the `params` keyword must be the last.

	True. This is also the rule. `params` must be the last item in the list.

#### 6.	What keyword is added to a parameter to make an extension method?

	Applying the `this` keyword to the first parameter is what makes something an extension method.

#### 7.	What keyword is used to indicate that a parameter is passed by reference?

	The `ref` and `out` keywords specify passing by value. (There is also `in`, though the book does not cover that in any depth.)

#### 8.	Given the method `void DoSomething(int x, params int[] numbers) { ... }` which of the following are allowed? (a) `DoSomething();` (b) `DoSomething(1);` (c) `DoSomething(1, 2, 3, 4, 5);` (d) `DoSomething(1, new int[] { 2, 3, 4, 5 });`

	(a) is not allowed because `DoSomething` requires the parameter `x`.
	(b) is allowed because the number is what is assigned to `x`. `numbers` will be empty in this case.
	(c) is allowed because `1` is assigned to `x` while the rest of the numbers are put into the `numbers` array.
	(d) is allowed. The only difference between (c) and (d) is that (d) does not ask the compiler to pack the values into 
	    the array, but just does it directly in the calling code.