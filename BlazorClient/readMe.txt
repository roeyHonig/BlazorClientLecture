Blazor WebAssembly - Initial Application Flow

User opens browser
        |
        v
https://client-app.com
        |
        v
Browser downloads:
    - index.html
    - CSS
    - blazor.webassembly.js
    - dotnet.wasm
    - Application DLLs
        |
        v
WebAssembly Engine
(built into browser)
        |
        v
.NET Runtime
(running inside WASM)
        |
        v
Blazor Components
(Home.razor, Products.razor, ...)
        |
        v
Application is now running
inside the browser






What Actually Executes Where?
SERVER
------
Serves files only

    index.html
    CSS
    JS
    dotnet.wasm
    Application DLLs


BROWSER
--------
Executes application

    WebAssembly Engine
            |
            v
      .NET Runtime
            |
            v
       C# Code
            |
            v
   Blazor Components






   First API Call From Blazor

   User navigates to:

/products

        |
        v

Products.razor loaded

        |
        v

OnInitializedAsync()

        |
        v

HttpClient.GetFromJsonAsync()

        |
        v

GET /api/products

        |
        v

API returns JSON

        |
        v

JSON -> ProductDto objects

        |
        v

State updated

        |
        v

Blazor automatically re-renders UI






Cross-Origin Request (Normal Scenario)
Blazor Client
https://client-app.com

        |
        | GET /api/products
        |
        v

API Server
https://api.company.com

        |
        | Response
        | Access-Control-Allow-Origin
        |
        v

Browser checks CORS policy

        |
        +---- Allowed -> JavaScript receives response
        |
        +---- Denied  -> Browser blocks response




Why Browsers Need CORS

Without CORS:

evil-site.com
        |
        |
        +---- Reads your bank account
        |
        +---- Reads your emails
        |
        +---- Reads private APIs

Browser security would be broken


Therefore:

Browser enforces CORS
before exposing responses
to JavaScript





The Browser's CORS Decision

Request sent
      |
      v

Response received
      |
      v

Does response contain:

Access-Control-Allow-Origin ?

      |
      +---- YES
      |       |
      |       v
      |   Response exposed
      |   to JavaScript
      |
      +---- NO
              |
              v
       Browser blocks access



Important Lesson
A CORS error does NOT always mean:

"Your CORS configuration is wrong"


Sometimes:

Request
    |
    v
Redirect
    |
    v
Authentication Page
    |
    v
Missing CORS Headers
    |
    v
Browser reports CORS failure