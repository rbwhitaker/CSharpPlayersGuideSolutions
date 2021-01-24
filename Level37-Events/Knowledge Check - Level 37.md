#### 1.	True/False. Events allow one object to notify another object when something occurs.

	True. This is the intended purpose of events.

#### 2.	True/False. Any method can be attached to a specific event.

	False. The parameter and return types must match. The name and contents of a method do
	not matter.

#### 3.	True/False. Once attached to an event, a method cannot be detached from an event.

	False. You can detach or unsubscribe an event handler after the fact; and you should
	do this whenever you are done using an event, because otherwise, the object that contains
	the handler will stay in memory longer than it should have (an event leak).