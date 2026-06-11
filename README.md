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

