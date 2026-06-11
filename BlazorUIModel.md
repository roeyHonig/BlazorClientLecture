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