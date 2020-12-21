#### 1.	True/False. Lambda expressions are a special type of method.

    True. One that does not have a formal name and cannot be reused.

#### 2.	True/False. You can name a lambda expression.

    False. Lambda expressions cannot have a name. Lambdas are meant to be
    discarded after use. If you want something you can use and reuse,
    consider either a local function or even just a private method in the
    class you are working in.

#### 3.	Convert the following to a lambda: `bool IsNegative(int x) { return x < 0; }`

    `x => x < 0`

#### 4.	True/False. Lambda expressions can only have one parameter.

    The syntax is simpler when you only have one parameter (you don't need parentheses),
	but you can define a lambda with 0 or many parameters by using parentheses.