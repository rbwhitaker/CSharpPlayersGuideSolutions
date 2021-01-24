#### 1.	True/False. You can define your own, brand new operator using operator overloading.

	Unfortunately, this is false. You cannot define new operators in C#.

#### 2.	True/False. You can overload all C# operators.

	False. There are many that can be overloaded, but some would be rather dangerous to overload. (Assignment, for one.)
	
#### 3.	True/False. Operator overloads must be public and static.

	True. This is necessary for operator overloading. They must all be `static`, `public`, and defined in the class of one
	of the types involved in the operation.
