# 🌐 Introduction to Blazor

Blazor is a modern web framework from Microsoft that allows developers to build interactive web applications using C# instead of JavaScript. It is part of ASP.NET Core and enables full-stack .NET development with a unified language across backend and frontend.

Blazor applications are built using **components**, typically defined in `.razor` files, which combine HTML markup and C# logic in a single file.

---

# 🧠 Blazor Hosting Models

Blazor has two main execution models:

## 1. Blazor WebAssembly (WASM)
- Runs entirely in the browser
- Downloads the .NET runtime (`dotnet.wasm`)
- Executes C# directly in the browser via WebAssembly
- Fully client-side application

## 2. Blazor Server
- Runs on the server
- UI interactions are sent over a persistent SignalR connection
- Only UI diffs are sent to the browser
- Lower initial load time, but requires constant connection

---

# 🛠 Creating a Blazor Project (Terminal / Codespaces / Bash)

You create a Blazor project using the .NET CLI.

## 👉 Blazor WebAssembly

```bash
# Create project
dotnet new blazorwasm -o BlazorClient

# Enter folder
cd BlazorClient

# Run application
dotnet run
```

## 👉 Blazor Server

```bash
# Create project
dotnet new blazorserver -o BlazorServerApp

# Enter folder
cd BlazorServerApp

# Run application
dotnet run
```

After running, the app is available at:

```
https://localhost:5001
```

---

# ⚙ How Blazor Works

Blazor follows a **component-based architecture** similar to React or Angular:

## Core Concepts

### 1. Components
- Reusable UI building blocks
- Defined in `.razor` files
- Combine HTML + C#

### 2. Data Binding
- One-way binding:
  ```razor
  <p>@message</p>
  ```
- Two-way binding:
  ```razor
  <input @bind="message" />
  ```

### 3. Event Handling
```razor
<button @onclick="IncrementCount">Click</button>
```

### 4. Rendering System
- Blazor tracks UI state
- Updates only changed parts of the DOM (diff-based rendering)

### 5. Communication
- `HttpClient` → REST APIs (JSON/XML)
- SignalR → real-time communication (Blazor Server / optional WASM)

---

# 🔄 Blazor Component Lifecycle

Each component goes through a lifecycle:

| Method | When it runs | Purpose |
|--------|-------------|--------|
| OnInitialized | First initialization | Setup logic |
| OnInitializedAsync | Async initialization | API calls |
| OnParametersSet | When parameters change | React to parent updates |
| OnAfterRender | After UI render | DOM access |
| OnAfterRenderAsync | Async post-render logic | JS interop |
| Dispose | Component removed | Cleanup |

## Example Lifecycle Code

```csharp
@code {
    private string message = "";

    protected override async Task OnInitializedAsync()
    {
        message = "Component initialized";

        await Task.Delay(500); // simulate API call
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            Console.WriteLine("First render completed");
        }
    }

    public void Dispose()
    {
        Console.WriteLine("Component removed");
    }
}
```

---

# 🗂 Blazor Project Structure

A typical Blazor WebAssembly project looks like this:

```
BlazorClient/
├── wwwroot/             # Static files (CSS, JS, images)
│   ├── css/
│   ├── js/
│   └── index.html
│
├── Pages/               # Route-based UI pages
│   ├── Index.razor
│   ├── Counter.razor
│   ├── FetchData.razor
│
├── Shared/              # Shared UI components
│   ├── MainLayout.razor
│   └── NavMenu.razor
│
├── Program.cs           # App startup configuration
├── App.razor            # Root component + router
├── _Imports.razor       # Global usings
├── BlazorClient.csproj  # Project dependencies
```

---

## 📌 Key Files Explained

### Program.cs
Entry point of the application.

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });

await builder.Build().RunAsync();
```

---

### App.razor
Defines routing for the application.

```razor
<Router AppAssembly="@typeof(App).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData"
                   DefaultLayout="@typeof(MainLayout)" />
    </Found>

    <NotFound>
        <p>Page not found</p>
    </NotFound>
</Router>
```

---

### _Imports.razor
Global imports for all Razor files.

```razor
@using System.Net.Http
@using Microsoft.AspNetCore.Components
@using Microsoft.AspNetCore.Components.Web
```

---

### Pages Example

```razor
@page "/counter"

<h3>Counter</h3>

<p>Count: @count</p>

<button @onclick="Increment">Click me</button>

@code {
    private int count = 0;

    private void Increment()
    {
        count++;
    }
}
```

---

### Shared Components
Reusable UI parts like navigation menus or layouts.

Example:
- MainLayout
- NavMenu

---

### wwwroot
Static files served directly to the browser:
- CSS
- JavaScript
- Images
- index.html (WASM host page)

---

# 🧭 Summary

Blazor is a modern framework for building web applications using C#.

### Key ideas:

- UI is built from components
- Logic and UI live together in `.razor` files
- Lifecycle methods control initialization and rendering
- HttpClient is used for API communication
- SignalR enables real-time communication (especially in Blazor Server)
- Project structure separates UI, logic, and static assets

---

# 🚀 Final Concept

Blazor allows you to build:

- SPA applications (Single Page Applications)
- Real-time apps (with SignalR)
- API-driven UIs
- Full-stack .NET applications using only C#

All without leaving the .NET ecosystem.



# 🧱 Blazor Template Project Structure & UI Model

When you create a new Blazor project (WebAssembly or Server), you automatically get a **pre-built application shell**.

This shell includes:
- A sidebar navigation menu
- A layout system
- Example pages (Counter, FetchData, Home)
- A routing system
- Component-based UI structure

This is not just UI — it demonstrates the **core architecture of Blazor applications**.

---

# 🧭 The Default UI Layout (What You See in the Browser)

When the app runs, the UI is composed of:

```
+---------------------------------------------------+
| Top Bar / Header (optional depending on template) |
+-------------------+-------------------------------+
| Sidebar NavMenu   | Page Content Area            |
|                   |                               |
| - Home           |   Routed Page (.razor)        |
| - Counter        |                               |
| - Fetch Data     |                               |
| - etc...         |                               |
+-------------------+-------------------------------+
```

The layout is **component-driven**, not HTML pages.

---

# 🧩 Core Concept: Everything is a Component

In Blazor:

> Even pages, layouts, and UI widgets are components.

A component is a `.razor` file that contains:

- HTML markup
- C# logic
- Data binding
- Event handling

Example:

```razor
<h3>Hello @name</h3>

<input @bind="name" />

<button @onclick="ChangeName">Change</button>

@code {
    private string name = "World";

    private void ChangeName()
    {
        name = "Blazor User";
    }
}
```

---

# 📁 Blazor Template Project Structure Explained

A default Blazor project contains:

```
BlazorApp/
├── Pages/
├── Shared/
├── wwwroot/
├── App.razor
├── MainLayout.razor
├── NavMenu.razor
├── Program.cs
├── _Imports.razor
```

---

## 📄 Pages Folder

### What it is:
Contains **route-based components (pages)**.

Each file usually represents a URL.

Example:

```razor
@page "/counter"
```

This means:

```
URL: /counter
Component: Counter.razor
```

---

### Example: Counter.razor

```razor
@page "/counter"

<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">
    Click me
</button>

@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

### What this demonstrates:
- State (`currentCount`)
- Event handling (`@onclick`)
- UI re-render automatically when state changes

---

## 🧩 Shared Folder

### What it is:
Contains **reusable components used across pages**

Examples:
- Layouts
- Navigation menu
- Headers/footers

---

### MainLayout.razor

This defines the **overall structure of every page**.

```razor
@inherits LayoutComponentBase

<div class="page">
    <div class="sidebar">
        <NavMenu />
    </div>

    <main>
        @Body
    </main>
</div>
```

### Key idea:

```
@Body = the currently selected page
```

So when you navigate:

```
/counter → Counter.razor
/home    → Home.razor
```

They are injected into `@Body`.

---

## 🧭 NavMenu.razor (Sidebar Menu)

This is the **navigation component**.

```razor
<nav>
    <ul>
        <li>
            <NavLink href="/" Match="NavLinkMatch.All">
                Home
            </NavLink>
        </li>

        <li>
            <NavLink href="/counter">
                Counter
            </NavLink>
        </li>

        <li>
            <NavLink href="/fetchdata">
                Fetch Data
            </NavLink>
        </li>
    </ul>
</nav>
```

### What it demonstrates:

- Navigation without page reload
- SPA behavior (Single Page Application)
- Active link highlighting
- Routing system integration

---

# 🔄 Routing System (How Navigation Works)

Blazor does NOT reload pages.

Instead:

```
User clicks link
        ↓
Router intercepts request
        ↓
Loads matching .razor component
        ↓
Injects into @Body
        ↓
UI updates without refresh
```

---

# ⚙ App.razor (The Router Entry Point)

This is the **core routing engine**:

```razor
<Router AppAssembly="@typeof(App).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData"
                   DefaultLayout="@typeof(MainLayout)" />
    </Found>

    <NotFound>
        <p>Page not found</p>
    </NotFound>
</Router>
```

### What it does:

- Matches URL → component
- Injects layout
- Handles missing routes

---

# 🌐 Data Binding in Blazor UI

## 1. One-Way Binding

```razor
<p>@message</p>
```

UI reflects state.

---

## 2. Two-Way Binding

```razor
<input @bind="message" />
```

Changes in UI update the variable automatically.

---

## 3. Event Binding

```razor
<button @onclick="DoSomething">Click</button>
```

---

## Example Combined:

```razor
<h3>@title</h3>

<input @bind="title" />

<button @onclick="Reset">Reset</button>

@code {
    private string title = "Hello Blazor";

    private void Reset()
    {
        title = "Reset!";
    }
}
```

---

# 🧠 Component State Concept

Blazor components are **stateful**:

- Variables inside `@code` are the state
- UI automatically re-renders when state changes
- No manual DOM updates needed

---

# 🔁 Component Rendering Flow

```
User Action
    ↓
Event Handler (C#)
    ↓
State Changes
    ↓
Blazor Re-renders Component
    ↓
UI Updates Automatically
```

---

# 📦 wwwroot Folder

This is where static files live:

- CSS
- JavaScript
- Images
- index.html (for WASM)

Example:

```
wwwroot/
├── css/app.css
├── js/site.js
└── index.html
```

---

# 🧾 _Imports.razor

This file defines **global imports for all components**.

Instead of writing:

```csharp
@using System.Net.Http
@using Microsoft.AspNetCore.Components
```

in every file, you define them once:

```razor
@using System.Net.Http
@using Microsoft.AspNetCore.Components
@using Microsoft.AspNetCore.Components.Web
```

---

# 🚀 Summary

The Blazor template project demonstrates:

- Component-based architecture
- SPA navigation without page reload
- Layout system with reusable UI
- Routing system via App.razor
- State-driven UI updates
- Strong separation of:
  - Pages
  - Shared components
  - Static assets

---

# 🧠 Final Mental Model

```
User clicks UI
      ↓
Component event triggers C# method
      ↓
State changes
      ↓
Blazor re-renders only affected UI
      ↓
No full page reload ever happens
```

This is the core difference between Blazor and traditional server-rendered web apps.




# 🌐 CORS (Cross-Origin Resource Sharing)

CORS is a browser security mechanism that controls how web applications interact with APIs from different domains.

It is not a backend limitation — it is a **browser-enforced rule**.

---

# 🔄 Cross-Origin Request (Normal Scenario)

```
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
        +---- Allowed  → JavaScript receives response
        |
        +---- Denied   → Browser blocks response
```

---

# 🛡 Why Browsers Need CORS

Without CORS, malicious websites could silently access sensitive data.

Example:

```
evil-site.com
        |
        +---- Reads your bank account
        +---- Reads your emails
        +---- Calls private APIs
```

This would completely break web security.

### Therefore:

- The browser enforces CORS
- It blocks unsafe cross-origin access before JavaScript can see the response

---

# ⚙ The Browser’s CORS Decision Process

```
Request sent
      |
      v

Response received
      |
      v

Does response contain:

Access-Control-Allow-Origin ?
```

### Decision Tree:

```
        +----------------------+
        | Header exists?       |
        +----------------------+
                 |
        +--------+--------+
        |                 |
       YES               NO
        |                 |
        v                 v
Response exposed     Browser blocks
to JavaScript       access completely
```

---

# ⚠ Important Lesson

A CORS error does NOT always mean:

> "Your backend CORS configuration is wrong"

It can also happen when:

```
Request
    |
    v
Redirect (302)
    |
    v
Login / Authentication page
    |
    v
Missing CORS headers
    |
    v
Browser reports CORS failure
```

So the real issue may be:
- Authentication
- Redirects
- Missing headers
- Not just CORS policy itself

---

# 🎯 UI + Blazor Interaction Example (Real Scenario)

CORS often appears during API calls from Blazor apps.

### Example Flow:

```
User presses key
        |
        v
oninput event fires
        |
        v
Blazor event handler (C#)
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
        |
        v
Browser enforces CORS check
```

---

# 🧠 Key Takeaway

- CORS is a **browser security feature**
- It controls cross-domain API access
- The server must explicitly allow it
- Blazor (like React) is fully subject to CORS rules
- Errors often come from indirect issues (redirects/auth), not just config

---



# 🗄 Browser Storage Overview

```
                 Browser
                     |
    -------------------------------------
    |           |           |           |
 Cookies   LocalStorage SessionStorage IndexedDB
                                            |
                                         Cache API
```

**Purpose:**  
Store data on the client side without calling the server.

---

# 🍪 Cookies

```
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
```

## Key Characteristics

- Stored in the **browser**.
- **Automatically sent** with every HTTP request to the server.
- Ideal for **authentication tokens, session identifiers**.

---

# 💾 LocalStorage

```
Application
      |
      v
LocalStorage

theme = dark
token = abc123
username = john
```

- Persistent: **remains after browser restart**.
- Key-value storage (string only).
- Maximum storage: ~5-10MB depending on browser.

## Demo Flow

```
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
```

---

# 📝 SessionStorage

```
Browser Tab
     |
     v
SessionStorage

shoppingCart = [...]
searchTerm = "mouse"
```

- Lives **only within a browser tab**.
- Closed tab = data gone.
- Key-value storage (string only).
- Maximum storage: ~5-10MB.

---

# 🔄 LocalStorage vs SessionStorage

| Feature           | LocalStorage | SessionStorage |
|------------------|-------------|----------------|
| Refresh Page      | Yes         | Yes            |
| Close Tab         | Yes         | No             |
| Close Browser     | Yes         | No             |
| Storage Limit     | ~5-10MB     | ~5-10MB        |
| Sent to Server    | No          | No             |

**When to use SessionStorage:**  
- Temporary user state, e.g., wizard progress, search filters, shopping cart draft.

---

# 🗃 IndexedDB

### Simple View

```
LocalStorage
key -> value

username -> john
theme -> dark
```

### Database View

```
Database
    |
    +-- Products
    |
    +-- Orders
    |
    +-- Customers
```

### Main Idea

- LocalStorage: small/simple key-value store.  
- IndexedDB: large/structured client-side database.

### Offline Applications

- Offline Notes
- Offline CRM
- Offline Inventory
- Offline POS
- Progressive Web Apps (PWA)

### Example Structure

```
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
```

---

# 🛠 Cache API

### First Request

```
Browser
   |
   v
Server

GET /logo.png

Response

Cache stores response
```

### Subsequent Request

```
Browser
   |
   v
Cache API

logo.png found

No network request
```

### Real-World Flow

- First visit: Download images & data from network.
- Second visit: Load resources from cache.  
- **Result:** Faster application, offline-friendly.

---

# 📌 Browser Storage Summary

- **Cookies** – Authentication, automatically sent with requests.  
- **LocalStorage** – Persistent key/value storage.  
- **SessionStorage** – Per-tab storage.  
- **IndexedDB** – Client-side structured database.  
- **Cache API** – Stores HTTP responses for offline/faster access.



# Server Communication in Blazor

A Blazor WebAssembly application runs inside the browser.

Because the application executes on the client side, it often needs to communicate with servers in order to:

* Load data
* Save data
* Authenticate users
* Receive real-time updates

The most common technologies are:

* REST APIs
* JSON
* XML
* WebSockets
* SignalR

---

# Overview

```text
Blazor Component
        |
        v

    HttpClient

        |
        +---- REST API
        |
        +---- JSON / XML

        |
        v

Server

        |
        +---- SignalR
        |
        +---- WebSockets

        |
        v

UI Updated
```

---

# REST API

REST APIs are the most common way for frontend applications to communicate with servers.

A Blazor component sends an HTTP request using HttpClient.

The server processes the request and returns a response.

Common HTTP methods:

| Method | Purpose     |
| ------ | ----------- |
| GET    | Read data   |
| POST   | Create data |
| PUT    | Update data |
| DELETE | Remove data |

Flow:

```text
User Opens Products Page
          |
          v

    Products.razor

          |
          v

      HttpClient

          |
          | GET /api/products
          |
          v

       REST API

          |
          | JSON Response
          |
          v

      ProductDto

          |
          v

      Blazor UI
```

## Blazor Example

```csharp
@page "/products"
@inject HttpClient Http

<h3>Products</h3>

@if (products == null)
{
    <p>Loading...</p>
}
else
{
    <ul>
        @foreach(var p in products)
        {
            <li>@p.Name - $@p.Price</li>
        }
    </ul>
}

@code {

    private List<ProductDto>? products;

    protected override async Task OnInitializedAsync()
    {
        products =
            await Http.GetFromJsonAsync<List<ProductDto>>(
                "https://api.company.com/products");
    }

    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public decimal Price { get; set; }
    }
}
```

This component calls a REST API when the page loads and displays the returned products.

---

# JSON

JSON (JavaScript Object Notation) is the most common format used by REST APIs.

Example JSON response:

```json
[
  {
    "id": 1,
    "name": "Keyboard",
    "price": 100
  }
]
```

Blazor automatically converts JSON into C# objects.

## DTO Example

```csharp
public class ProductDto
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public decimal Price { get; set; }
}
```

Flow:

```text
JSON Response
        |
        v

ProductDto

        |
        v

Blazor Component

        |
        v

Rendered UI
```

The DTO acts as a bridge between the JSON response and the Blazor UI.

---

# XML

Before JSON became dominant, XML was the most common format for exchanging data.

Example XML:

```xml
<Product>
    <Id>1</Id>
    <Name>Keyboard</Name>
    <Price>100</Price>
</Product>
```

Comparison:

| JSON              | XML                      |
| ----------------- | ------------------------ |
| Smaller           | More verbose             |
| Easier to read    | More structured          |
| Most common today | Common in legacy systems |

## Blazor Example

```csharp
@inject HttpClient Http

@code {

    private string xmlContent = "";

    protected override async Task OnInitializedAsync()
    {
        xmlContent =
            await Http.GetStringAsync(
                "https://api.company.com/products/xml");
    }
}
```

In modern applications, JSON is usually preferred over XML.

---

# WebSockets

REST APIs are request/response based.

The client requests information.

The server responds.

Some applications require real-time communication where the server can send information whenever something changes.

Examples:

* Chat applications
* Notifications
* Stock prices
* Multiplayer games

Flow:

```text
Blazor Client
        |
        | Open Connection
        |
        v

Server

        |
        | Connection Remains Open
        |
        v

Server Sends Updates

        |
        +---- Chat Message
        |
        +---- Notification
        |
        +---- Price Change
        |
        v

UI Updates Instantly
```

## JavaScript WebSocket Example

Blazor usually accesses browser WebSocket APIs through JavaScript.

```javascript
const socket =
    new WebSocket(
        "wss://server.example.com");

socket.onmessage = event =>
{
    console.log(event.data);
};
```

Working directly with WebSockets is possible, but requires handling connection management manually.

---

# SignalR

SignalR is Microsoft's framework for real-time communication.

SignalR uses WebSockets internally whenever possible.

SignalR adds:

* Automatic reconnect
* Connection management
* Message serialization
* Easier APIs

Flow:

```text
Blazor Client
        |
        v

SignalR Connection

        |
        v

SignalR Hub

        |
        +---- Broadcast Message
        |
        +---- Notification
        |
        +---- Live Update
        |
        v

Connected Clients
```

---

## SignalR Server Example

```csharp
using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
    public async Task SendMessage(
        string user,
        string message)
    {
        await Clients.All.SendAsync(
            "ReceiveMessage",
            user,
            message);
    }
}
```

The Hub acts as a central communication point.

---

## SignalR Blazor Client Example

```csharp
@page "/chat"

@using Microsoft.AspNetCore.SignalR.Client

@code {

    private HubConnection? hubConnection;

    protected override async Task OnInitializedAsync()
    {
        hubConnection =
            new HubConnectionBuilder()
                .WithUrl(
                    "https://server/chatHub")
                .Build();

        hubConnection.On<string, string>(
            "ReceiveMessage",
            (user, message) =>
            {
                Console.WriteLine(
                    $"{user}: {message}");
            });

        await hubConnection.StartAsync();
    }
}
```

Whenever the server sends a message, the Blazor component receives it immediately.

---

# REST vs SignalR

```text
REST API

Client -----> Server
       Request

Client <----- Server
       Response
```

```text
SignalR

Client <=====> Server

Connection remains open

Messages can travel
in both directions
at any time
```

---

# Summary

| Technology | Typical Usage                     |
| ---------- | --------------------------------- |
| REST API   | Load and save data                |
| JSON       | Data format used by REST APIs     |
| XML        | Legacy data format                |
| WebSockets | Low-level real-time communication |
| SignalR    | Real-time communication in .NET   |

Most modern Blazor applications use:

1. REST APIs for CRUD operations.
2. JSON as the data format.
3. SignalR for real-time updates.
4. WebSockets underneath SignalR.

```
```

