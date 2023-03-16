# TicTacToeAPI

## Endpoints

### /games
List of all games

- 200 (Success): Returns game ids
```json
{
  "GameIds": [ 0, 2, 3 ]
}
```


### /game/create
Create a game

- 200 (Success): Returns the game and its id
```json
{
  "Id": 5,
  "Game": {
    "Field": "___,___,___,",
    "NextPlayer": "X",
    "Winner": null
  }
}
```


### /game/\{game id\}
Show game info

- 200 (Success): Returns the game
```json
{
  "Field": "XOX,_O_,___,",
  "NextPlayer": "X",
  "Winner": null
}
```

- 404: Id is not found


### /game/\{game id\}/remove
Remove game

- 200 (Success)
- 404: Id is not found


### /game/\{game id\}/reset
Reset game

- 200 (Success): Returns the game
```json
{
  "Field": "___,___,___,",
  "NextPlayer": "X",
  "Winner": null
}
```

- 404: Id is not found


### /game/\{game id\}/move?x={x}&y={y}
Next move

- 200 (Success): Returns the game
```json
{
  "Field": "XOX,___,___,",
  "NextPlayer": "O",
  "Winner": null
}
```
```json
{
  "Field": "XOX,XO_,_O_,",
  "NextPlayer": "X",
  "Winner": "O"
}
```

- 404: Id is not found
- 400: Parameters are not set or the game rules are violated



### /
Shows this file


## Some extra info
The API can also send binary packages using protobuf.
Use ContentType "application/x-protobuf" in the request header.
You can see the packet formats [here](/DTOs).