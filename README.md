# dfo_aspnetcore_webapi
This is DFO code challenge

-----------------------------------------------------

To run the Web api

Step 1: Configure `UseInMemoryDatabase` to `true` in `appsettings.json` or `appsettings.Development.json`

Step 2: Open the solution, right click on DFO_aspnetcore_api, then click run or debug

There are 4 APIs 


**Create user**

URL: https://localhost:5001/api/user

Method: **POST**

Content-Type: `applcation/json`

Body example

`{
  "name": "lam mai",
  "email": "emai2@dxc.com",
  "userName": "lamemmv2",
  "password": "-Tz<Uhx_y_3=sw*r",
  "confirmPassword": "-Tz<Uhx_y_3=sw*r",
  "age": 24,
  "address": "243 Tan Hoa Dong"
}`

**Get all users**

URL: https://localhost:5001/api/user

Method: **GET**

**Get a user**

URL: https://localhost:5001/api/user/1

Method: GET

**Update user**

URL: https://localhost:5001/api/user/1

Method: **PUT**

Content-Type: applcation/json

Body example

`{
  "id": 1,
  "name": "lam mai1",
  "age": 26,
  "address": "243 Tan Hoa Dong"
}`
