# TicTacToeAPI

## /games
List of all games

- 200 (Success): Returns game ids
```json
{
  "GameIds": [ 0, 2, 3 ]
}
```


## /game/create
Create a game

- 200 (Success): Returns the game and its id
```json
{
   ID: 4
   "Game": {
     Size: 3
     "Cells": [
       [
         "None",
         "None",
         "None"
       ],
       [
         "None",
         "None",
         "None"
       ],
       [
         "None",
         "None",
         "None"
       ]
     ],
     "NextPlayer": "X",
     "Winner": "None"
   }
}
```


## /game/\{game id\}
Show game info

- 200 (Success): Returns the game
```json
{
   Size: 3
   "Cells": [
     [
       "None",
       "None",
       "None"
     ],
     [
       "None",
       "None",
       "None"
     ],
     [
       "None",
       "None",
       "None"
     ]
   ],
   "NextPlayer": "X",
   "Winner": "None"
}
```

- 404: Id is not found


## /game/\{game id\}/remove
Remove game

- 200 (Success)
- 404: Id is not found


## /game/\{game id\}/reset
Reset game

- 200 (Success): Returns the game
```json
{
   Size: 3
   "Cells": [
     [
       "None",
       "None",
       "None"
     ],
     [
       "None",
       "None",
       "None"
     ],
     [
       "None",
       "None",
       "None"
     ]
   ],
   "NextPlayer": "X",
   "Winner": "None"
}
```

- 404: Id is not found


## /game/\{game id\}/move?x={x}&y={y}
Next move

- 200 (Success): Returns the game
```json
{
   Size: 3
   "Cells": [
     [
       "None",
       "None",
       "None"
     ],
     [
       "None",
       "None",
       "None"
     ],
     [
       "None",
       "None",
       "None"
     ]
   ],
   "NextPlayer": "X",
   "Winner": "None"
}
```

- 404: Id is not found
- 400: Parameters are not set or the game rules are violated



## /
Shows this file