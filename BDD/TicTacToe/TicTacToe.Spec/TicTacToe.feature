Feature: Tic Tac Toe
	In order to determine who the winner of the game as
	As a Player
	I want to be told who (if anyone) won the game

Scenario: Empty board ends with a tie
	Given I have a tic tac toe board
	And the board is empty
	When I determine the winner
	Then the result no winner yet

Scenario: When X is accross the top then X wins
	Given I have a tic tac toe board
	And the top row is all "X"
	When I determine the winner
	Then the result is "X" wins

Scenario: When O is accross the top then O wins
	Given I have a tic tac toe board
	And the top row is all "O"
	When I determine the winner
	Then the result is "O" wins

Scenario: When I have a table that look this way, find the winner
	Given I have a tic tac toe board
	And it looks like this
	| Col1 | Col2 | Col3 |
	| X    |      | O    |
	| X    | O    |      |
	| X    | O    |      |
	When I determine the winner
	Then the result is "X" wins

