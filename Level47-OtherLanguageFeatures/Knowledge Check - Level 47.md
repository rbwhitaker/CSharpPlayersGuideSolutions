#### 1. True/False. The `const` keyword is equivalent to the `readonly` keyword.

	False. `const` is for compile-time constants. `readonly` is a runtime constant. With `const`,
	the compiler determines what value the constant has and substitutes that value anywhere the
	code refers to it. It is slightly faster than `readonly`, but is also much more limited.

#### 2. What is the name of the class that lets you inspect (reflection) a type’s definition at runtime?

	The `System.Type` class is the primary origination point of reflection. Instances of `System.Type`
	represent the metadata for a specific type available in the program.

#### 3. What keyword allows you to jump to a named location elsewhere in the method?

	`goto`. But don't use it. Find a way to structure the code to avoid it, and use loops, `if`s, `return`s,
	`break`s, `continue`s, and other similar features. You always end up regretting `goto` eventually.

#### 4. What keyword will enable you to split a class’s definition into multiple parts?

	The `partial` keyword lets you split a type definition across multiple files (or even multiple slices
	within a single file, though the first is more common).

#### 5. Name two bit manipulation operators.

	There are quite a few. The bitshift operators `>>` and `<<`, and the logical operators `&`, `|`, `^`, and `&`.

#### 6. True/False. An enumeration definition can contain a class definition.

	False. While a class can contain other type definitions, including an enumeration or another class,
	enumerations cannot include additional type definitions.

#### 7. True/False. A class definition can contain an enumeration definition.

	True. Classes can contain other type definitions inside of them as members. This is typically done
	only when the nested type is very closely related to the containing type.

#### 8. What preprocessor directives begin and end a section of `DEBUG`-only code?

	`#if DEBUG` starts a block that is only included when the `DEBUG` symbol is defined, and `#endif` will end it.

#### 9. What keyword is involved when automatically cleaning up objects that implement `IDisposable`?

	The `using` keyword is reused for automatically cleaning up `IDisposable`, as a part of `using` statements
	(contrasted with `using` directives at the top of the file).

#### 10. True/False. You can create never-ending sequences with the `yield` keyword.

	True. And this is one of the coolest features of `IEnumerable`s and the `yield` keyword. You can produce
	arbitrarily long sequences.
