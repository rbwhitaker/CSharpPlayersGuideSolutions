#### 1. True/False. Unsafe code is inherently dangerous.

	False. It leaves the realm where the compiler and runtime can protect you, but that doesn't
	make it unsafe. It just opens the pathway to certain unsafe operations if used recklessly.

#### 2. What keyword makes something an unsafe context?

	`unsafe` is the keyword, applied to a block, a method, or a type, that makes the section of
	code an unsafe context. You must also configure your project to allow unsafe code to use this.

#### 3. What keyword pins a reference in place?

	The `fixed` keyword pins a referenced object in place until it is done being used.

#### 4. How do you denote a type that is a pointer to an int?

	`int*`. The `*`, when used as a part of a type, indicates a pointer type. So `int*` is an `int` pointer.
