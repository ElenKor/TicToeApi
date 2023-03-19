# TicToeApi

## Описание 
  REST API для игры в крестики нолики для разработки сайта и мобильного приложения для игры в крестики нолики 3x3 для двух игроков.  
  Игра проходит по обычным правилам.
## Как запустить проект 
### С использованием Visual studio 2022 и docker 
Проект реализован с использование SQL Server 2022, запущенный через docker 
1. Клонируйте данный репозиторий на свой ПК
2. Запустите проект в Visual Studio 2022
3. Запустите docker на своем ПК
4. В терминале перейдите в папку проекта и пропишите команду docker-compose up 
5. Запустите приложение - откроется Swagger 
6. Выполните необходимые запросы 

## EndPoints 
[Код реализации GamesController](https://github.com/ElenKor/TicToeApi/blob/main/Controllers/GamesController.cs)

* ***Получить список всех игр***
  - GET/Api/Games     

Request URL `https://localhost:5001/api/games`

Пример Response body
  ```{
   "id": 1,  
    "board": "XXXOO0000",  
    "currentPlayer": 2,  
    "isOver": true,  
    "winner": 1
  },
   {
    "id": 2,
    "board": "XO0X0OX00",
    "currentPlayer": 2,
    "isOver": true,
    "winner": 1
  } 
 ```
 * ***Начать игру*** 
   - Post/api/Games
    
Пример Response body
```
{
  "id": 6,
  "board": "000000000",
  "currentPlayer": 1,
  "isOver": false,
  "winner": 0
}
```
* ***Получить информацию об игре по id игры*** 
    - Get/api/Games/{id}  

Request URL https://localhost:7073/api/Games/2 

Пример Response body
```
{
  "id": 2,
  "board": "XXXOO0000",
  "currentPlayer": 2,
  "isOver": true,
  "winner": 1
}
```
* ***Сделать ход в игре***
  - Put/api/Games/{id}  

Request URL https://localhost:7073/api/Games/6?positionFromNullToEight=1  

Пример Response body
```
{
  "id": 6,
  "board": "0X0000000",
  "currentPlayer": 2,
  "isOver": false,
  "winner": 0
}
```
## Models 
[Код реализации Models](https://github.com/ElenKor/TicToeApi/blob/main/Models/Game.cs)
### Описание полей базы данных
  - Id = id игры
  - Board = игровое поле с ходами игроков, в начале игры инициализированно нулями, далее X - ход 1 игрока, O - ход 2 игрока, 0 - пустое поле, свободное для хода
  - CurrentPlayer = игрок, совершающий ход
  - IsOver = статус игры 
  - Winner = победитель текущей игры (1 - игрок X, 2 - игрок O, 0 - если игра завершена, то ничья)
  
 


