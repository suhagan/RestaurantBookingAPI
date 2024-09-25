# Restaurant Booking API

This API is designed to manage bookings, customers, tables, and menu items for a restaurant. Below are the available endpoints and examples of how to interact with them.

---

## API Endpoints

### 1. **Bookings**
- **GET** `/Bookings`: Retrieve a list of all bookings.
- **GET** `/Bookings/{id}`: Retrieve a specific booking by its ID.
- **POST** `/Bookings`: Create a new booking.
- **PUT** `/Bookings/{id}`: Update an existing booking.
- **DELETE** `/Bookings/{id}`: Delete a booking by its ID.

#### Example: **GET** `/Bookings`

**Request:** `No input is needed.`
**Response:**

```json
[
  {
    "bookingId": 1,
    "tableId": 5,
    "guestIdId": 1,
    "bookingDate": "2024-09-25T01:56:21.208",
    "bookingTime": "2024-09-25T01:56:21.208",
    "numberOfGuests": 4
  }
]
```
**HTTP Status:** `200 OK`

---

#### Example: **POST** `/bookings`

**Request:**

```json
{
  "tableId": 5,
  "guestIdId": 1,
  "bookingDate": "2024-09-25T01:56:21.208Z",
  "bookingTime": "2024-09-25T01:56:21.208Z",
  "numberOfGuests": 4
}
```

**Response:**

```json
{
  "bookingId": 1,
  "tableId": 5,
  "guestIdId": 1,
  "bookingDate": "2024-09-25T01:56:21.208Z",
  "bookingTime": "2024-09-25T01:56:21.208Z",
  "numberOfGuests": 4
}
```
**HTTP Status:** `201`

---

### 2. **Customers**
- **GET** `/Customers`: Retrieve a list of all customers.
- **GET** `/Customers/{id}`: Retrieve a specific customer by their ID.
- **POST** `/Customers`: Create a new customer.
- **PUT** `/Customers/{id}`: Update an existing customer.
- **DELETE** `/Customers/{id}`: Delete a customer by their ID.

#### Example: **GET** `/Customers`

**Request:** `No input is needed.`

**Response:**

```json
[
  [
  {
    "guestId": 1,
    "guestName": "Marshal Viktor",
    "guestPhone": "98765413",
    "guestEmail": "marshal.viktor@xyz.se",
    "guestAddress": "Södertälje"
  }
]
]
```
**HTTP Status:** `200 OK`

#### Example: **POST** `/Customers`

**Request:** 

```json
[
  {
  "guestName": "Marshal Viktor",
  "guestPhone": "98765413",
  "guestEmail": "marshal.viktor@xyz.se",
  "guestAddress": "Södertälje"
 }
]
```

**Response:**

```json
[
  {
  "guestId": 1,
  "guestName": "Marshal Viktor",
  "guestPhone": "98765413",
  "guestEmail": "marshal.viktor@xyz.se",
  "guestAddress": "Södertälje"
}
]
```
**HTTP Status:** `201`
---

### 3. **Tables**
- **GET** `/Tables`: Retrieve a list of all tables.
- **GET** `/Tables/{id}`: Retrieve a specific table by its ID.
- **POST** `/Tables`: Add a new table.
- **PUT** `/Tables/{id}`: Update an existing table.
- **DELETE** `/Tables/{id}`: Delete a table by its ID.

#### Example: 
**a. Get all Tables:**
**Endpoint:** `GET /api/Tables`
**Request URL:** `[GET /api/Tables](http://localhost:5067/api/Tables)`
**Request:** No input needed
**Response:**
```json
[
  {
    "tableId": 1,
    "numOfSeats": 2,
    "tableNumber": 1
  },
  {
    "tableId": 3,
    "numOfSeats": 4,
    "tableNumber": 3
  },
  {
    "tableId": 4,
    "numOfSeats": 5,
    "tableNumber": 4
  },
  {
    "tableId": 5,
    "numOfSeats": 6,
    "tableNumber": 5
  },
  {
    "tableId": 6,
    "numOfSeats": 8,
    "tableNumber": 6
  },
  {
    "tableId": 7,
    "numOfSeats": 10,
    "tableNumber": 7
  }
]
```
**HTTP Status:** `200 OK`

**b. Create a new Tables:**
**Endpoint:** `POST /api/Tables`
**Request URL:** `[POST /api/Tables](http://localhost:5067/api/Tables)`
**Request:** 
```json
{

  "numOfSeats": 8,
  "tableNumber": 10
}
```
**Response:**
```json
{
  "tableId": 8,
  "numOfSeats": 8,
  "tableNumber": 10
}
```
**HTTP Status:** `201`

**c. Delete a Tables:**
**Endpoint:** `DELETE /api/Tables/7`
**Request URL:** `[DELETE /api/Tables](http://localhost:5067/api/Tables)`
**Request:** `{id}`
**Response:** `204`

---

### 4. **Menu Items**
- **GET** `/MenuItems`: Retrieve a list of all menu items.
- **GET** `/MenuItems/{id}`: Retrieve a specific menu item by its ID.
- **POST** `/MenuItems`: Add a new menu item.
- **PUT** `/MenuItems/{id}`: Update an existing menu item.
- **DELETE** `/MenuItems/{id}`: Delete a menu item by its ID.

#### Example: **GET** `/MenuItems`

**Request:** `No input is needed.`

**Response:**

```json
[
  {
    "menuId": 1,
    "itemName": "Ceaser Salad",
    "itemPrice": 79,
    "itemAvailable": true
  },
  {
    "menuId": 2,
    "itemName": "Green Salad",
    "itemPrice": 79,
    "itemAvailable": true
  },
  {
    "menuId": 3,
    "itemName": "Tryffel Burger",
    "itemPrice": 139,
    "itemAvailable": true
  },
  {
    "menuId": 4,
    "itemName": "Gold Burger",
    "itemPrice": 149,
    "itemAvailable": true
  },
  {
    "menuId": 6,
    "itemName": "Hallomi Burger",
    "itemPrice": 139,
    "itemAvailable": true
  },
  {
    "menuId": 7,
    "itemName": "Hallomi Salad",
    "itemPrice": 79,
    "itemAvailable": true
  }
]
```
**HTTP Status:** `200 OK`

#### Example: **POST** `/menuitems`

**Request:**

```json
{
  
  "itemName": "Phil's Burger",
  "itemPrice": 155,
  "itemAvailable": true
}
```

**Response:**

```json
{
  "menuId": 8,
  "itemName": "Phil's Burger",
  "itemPrice": 155,
  "itemAvailable": true
}
```

**HTTP Status:** `201`
---

## Error Handling

The API returns appropriate HTTP status codes in response to errors:

- **400 Bad Request**: The request was malformed or missing required data.
- **404 Not Found**: The requested resource could not be found.
- **500 Internal Server Error**: A server-side error occurred.
