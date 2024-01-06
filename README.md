# Match Game

This is a simple WPF application that implements a memory game with animal emojis.

## Features

- **Timer**: The game includes a timer that tracks the time elapsed since the start of the game.
- **Match Tracking**: The application keeps track of the number of matches found by the user.
- **Game Setup**: At the start of the game, animal emojis are randomly assigned to the TextBlocks in the main grid.
- **Click Handling**: The application handles mouse down events on the TextBlocks and the timer TextBlock.

## How to Play

1. Click on a TextBlock to reveal an animal emoji.
2. Click on another TextBlock to reveal a second animal emoji.
3. If the emojis match, they will remain visible. If not, they will be hidden again.
4. The game is over when all matches are found. The timer will stop and the message "Play again?" will be displayed.
5. Click on the timer TextBlock to set up a new game.

## Code Structure

The `MainWindow` class contains the main logic of the game. It includes methods for setting up the game, handling timer ticks, and handling mouse down events on the TextBlocks and the timer TextBlock.

## Future Improvements

- Add different difficulty levels by increasing the number of emojis.
- Implement a high score system that tracks the fastest times.
