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




UI playground
User presses key
        |
        v
oninput event fires
        |
        v
Blazor event handler
        |
        v
Update component state
        |
        v
Blazor re-renders UI
        |
        v
(Optional)
Call REST API
for search suggestions





=========================================
BROWSER STORAGE OVERVIEW
=========================================

                 Browser
                     |
    -------------------------------------
    |           |           |           |
 Cookies   LocalStorage SessionStorage IndexedDB
                                            |
                                         Cache API

Purpose:
Store data on the client side
without calling the server



=========================================
COOKIES
=========================================

Browser
   |
   | Request
   |
   v
Server

Set-Cookie:
theme=dark

   |
   v

Browser stores cookie

Future requests:

Cookie:
theme=dark



=========================================
COOKIES - KEY CHARACTERISTIC
=========================================

Cookies
   |
   +--> Browser Storage
   |
   +--> Automatically sent with requests



=========================================
LOCAL STORAGE
=========================================

Application
      |
      v
LocalStorage

theme = dark
token = abc123
username = john

Data remains after browser restart



=========================================
LOCAL STORAGE DEMO FLOW
=========================================

Save
    |
    v
LocalStorage
    |
    v
Refresh page
    |
    v
Value still exists



=========================================
SESSION STORAGE
=========================================

Browser Tab
     |
     v
SessionStorage

shoppingCart = [...]
searchTerm = "mouse"

Close tab
     |
     v

Data gone



=========================================
LOCAL STORAGE VS SESSION STORAGE
=========================================

                LocalStorage    SessionStorage
------------------------------------------------
Refresh Page         Yes              Yes
Close Tab            Yes              No
Close Browser        Yes              No
Storage Limit        ~5-10MB          ~5-10MB
Sent To Server       No               No



=========================================
WHEN TO USE SESSION STORAGE
=========================================

Temporary user state:

- Wizard progress
- Search filters
- Shopping cart draft



=========================================
INDEXEDDB - SIMPLE VIEW
=========================================

LocalStorage

key -> value

username -> john
theme -> dark



=========================================
INDEXEDDB - DATABASE VIEW
=========================================

Database
    |
    +-- Products
    |
    +-- Orders
    |
    +-- Customers



=========================================
INDEXEDDB - OFFLINE APPLICATIONS
=========================================

Offline Applications

Offline Notes
Offline CRM
Offline Inventory
Offline POS
Progressive Web Apps



=========================================
INDEXEDDB - EXAMPLE STRUCTURE
=========================================

Application
      |
      v
IndexedDB

+------------+
| Products   |
+------------+
| Id | Name  |
| 1  | Mouse |
| 2  | Screen|
+------------+



=========================================
INDEXEDDB - MAIN IDEA
=========================================

LocalStorage
    small/simple

IndexedDB
    large/structured



=========================================
CACHE API - FIRST REQUEST
=========================================

Browser
   |
   v
Server

GET /logo.png

Response

Cache stores response



=========================================
CACHE API - SUBSEQUENT REQUEST
=========================================

Browser
   |
   v
Cache API

logo.png found

No network request



=========================================
CACHE API - REAL WORLD FLOW
=========================================

First visit:
    Download images

Second visit:
    Load images from cache

Faster application



=========================================
BROWSER STORAGE SUMMARY
=========================================

Cookies
    Authentication
    Sent automatically

LocalStorage
    Persistent key/value

SessionStorage
    Per-tab storage

IndexedDB
    Client-side database

Cache API
    Stores HTTP responses