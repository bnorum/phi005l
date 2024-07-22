Long form writing project made for PHI005L at Hofstra University.

I wanted to emulate the atmosphere of old IRC and other online group chats.
This project implements a text parser, of which the syntax goes as follows:

A line of dialogue:
```b 1.5 "Hello World!"```<br>

In the script for the parser, a hashmap of names are defined to shorten names to an abbreviation for convience here.<br>
```brady 1.5 "Hello World!"```<br>
This is effectively the same line of code. <br>
If the abbreviation is not in the map, then it just uses the name. If the *name* doesn't exist, then it makes a new speaker color.

1.5 represents the amount of delay prior to a message being sent after the prior message. I did this intentionally, because I wanted messages to be
unskippable and scattered like that of an online chat

The game also features a rhythm game bullet hell section whenever a decision is made. The player is stationaary and given control of a blocker. 
