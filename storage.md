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