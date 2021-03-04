# ESP8266 Fridge Sensor using DHT

A .NET Core REST API for my fridge sensor micro-controller.

Runs in a docker container. Stores data in a SQLite database.

Build:
`docker build --file Fridge-Sensor-API/Dockerfile --tag fridge-sensor .`

Suggest run command:
`docker run --detach --publish 32771:80 --volume=/path/to/persisent/storage:/var/local/data --name fridge-sensor fridge-sensor`
Copy `Records.db` to */path/to/persisent/storage*
