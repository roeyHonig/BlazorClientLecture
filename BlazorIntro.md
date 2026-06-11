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