# marsrover

N: North
S: South
E: East
W: West

L: Left
R: Right
M: Move

The commands are sent as a single multiline string. 
The first line describes the plateu boundaries, and the next lines descibe the start and movement orders for each rover.

for the follwing input

5 5
1 1 N
MRML

5 5
Create a 5x5 space for the rovers to roam in
1 2 N
Rover starts at pos 1,2 facing North
MRML
Move North => now at 1 2 N
Turn Right => now at 1 2 E
Move East => now at 2 2 E
Turn Left => now at 2 2 N

Steps 
A single rover that does not move
A single rover that can turn (once)
A single rover that can move (once)
