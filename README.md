# RoboSimulator
just playing around with clean architecture

# Task
A REST service to simulate robot moving and recording the number of the unique places visited by the robot. Written in C#.

Example instruction: 
```json
{
    "start": {
        "x": 10,
        "y": 22
    },
    "commmands": [
        {
            "direction": "east",
            "steps": 5
        },
        {
            "direction": "north",
            "steps": 3
        },
        {
            "direction": "west",
            "steps": 2
        }
    ]
}
```

Example response: 
```json
{
    "id": 23,
    "timestamp": "2023-10-18T09:29:56.2380207Z",
    "commands": 10584,
    "result": 318243,
    "duration": 0.1868691
}
```

Expected result should be stored in a relational database table:
| id | timestamp | commmands | result | duration |
| --- | ----------- | ----- | ------- | --------- |
| 1234 | 2018-05-12 12:45:10.851596 +02:00 | 2 | 4 | 0.000123 |


# Acknoledgements
Based on the work presented in https://github.com/jasontaylordev/CleanArchitecture

Adhering to Clean Architecture principles for developing software.

