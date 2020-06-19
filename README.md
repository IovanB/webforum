# WebForum API 
Web forum API with simple CRUD operations, SQL Server and Docker.

So far, this API stands users on any permission , as long as it's logged in.

![alt text](https://github.com/IovanB/webforum/blob/master/imgswagger.png)

Tecnologies:

- .NETCORE 3.1
- Entityframework
- Docker
- SQL Server
- JwtToken
- Swagger
- Xunit


# Getting Started
Warning : <b>You should have Docker running on your computer first</b>

1. Clone the project: 
        `https://github.com/IovanB/webforum.git`
2. Through prompt command go to folder webforum\WebForum where the docker-compose.yml file is. Then type `docker-compose up -d --build`

3. Check with the command `docker ps` which port the swagger is up.  Then type localhost:{port shown on the prompt line}

4. You can also run the API on Visual Studio

# How to use

1. You first need to create an User in order to use the API
2. Log in with your new user
3. Take the Jwt Bearer Token, click on the Authorize button on your upper-left, then type bearer YOURTOKEN 

![alt text](https://github.com/IovanB/webforum/blob/master/token.png)

![alt text](https://github.com/IovanB/webforum/blob/master/autho.png)

## Scheme
1. This API works on the following scheme
  - Category
  - Topic
  - Post
  - Comment

## Unit test
1. This API comes with Xunit test.


## Improvments: 
1. User permissions
2. Password cryptography
3. DTO
4. Integration test

