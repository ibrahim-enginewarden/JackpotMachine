# Jackpot Machine

A simple slot machine game made in Unity using C#. The player can place bets, spin the reels, and try to win coins by matching all three symbols.

---

# Game Overview

The game starts with 200 coins.

Players can choose between different betting amounts and pull the lever to spin the reels.

If all three symbols match:
- the player wins a 5x reward,
- and a jackpot popup appears.

If the symbols do not match:
- the selected bet is lost,
- and a try again popup appears.

The game continues until all coins are used.

---

# Instructions to Run the WebGL Build

## Play Online

Playable WebGL Build:

https://ibrahim-enginewarden.github.io/JackpotMachine/

---

## Run Locally

1. Open the project folder in VS Code.
2. Install the "Live Server" extension.
3. Open the `docs` folder.
4. Right click `index.html`.
5. Select `Open with Live Server`.

---

# Bonus Features

- Betting system with multiple bet values
- Coin economy system
- Dynamic bet button availability based on remaining coins

---

# Thought Process and Approach

- The project was developed by first focusing on the main gameplay loop and ensuring that the slot machine interaction felt functional and responsive before adding additional systems.

- The lever interaction was designed to act as the main gameplay trigger, controlling the start of the reel spinning process and the transition between gameplay states.

- The reel spinning system was implemented to create the feel of a working slot machine while keeping the movement smooth and visually understandable.

- Random symbol generation was added using Unity’s `Random.Range()` function so that each spin produces unpredictable outcomes similar to a real slot machine system.

- Win/loss detection was built by comparing the final generated symbols after the reels stop spinning. Matching symbols reward the player, while non-matching symbols result in the selected bet being lost.

- After the core gameplay loop was stable, additional systems such as betting, coin management, and result popups were added to make the game feel more interactive and replayable while maintaining a simple and organized structure.
