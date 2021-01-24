#### 1.	What keyword indicates that a method might schedule some of its work to run asynchronously?

	The `async` keyword needs to be on any method that calls an `await`.

#### 2.	What keyword indicates that code beyond that point should run once the task has completed?

	The `await` keyword indicates that the code beyond it should run once the awaited element completes.

#### 3.	Name three return types that can be used with the `async` keyword.

	There are quite a few, but `void`, `Task`, `Task<TResult>` are the most common. `ValueTask` and
	`ValueTask<T>`, as well as `IAsyncEnumerable<T>` are other correct options.

#### 4.	True/False. Code is always faster when run asynchronously.

	False. Sometimes, the overhead of pushing work around to different threads and the effort expended
	to make and manage threads causes work to be slower. You should be cognizant of this possibility;
	measure the performance with and without asynchrony or multiple threads to ensure you are getting
	the benefit that you hoped to get. Code is substantially more complicated with multiple threads or
	with asynchrony than without it. You should only take on that burden of more complicated code if
	it gets you solid performance gains.

#### 5.	What return type would be best for an async method that does the following:
    a. The work does not produce a value, but you need to know when it finishes.
    b. You do not care when the task completes.
    c. The task creates a result that you need to use afterward. 
	
	(a) If you need to know when it finishes, you cannot use `void`. If it produces no result, `Task` is
	the version you're looking for, typically.
	(b) If you do not care when the task completes (fire and forget) then `void` may be the right choice.
	(c) If the task produces a result that you need to use, `Task<T>` is usually what you want.
