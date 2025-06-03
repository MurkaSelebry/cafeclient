-- USERS: System staff
CREATE TABLE USERS (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    username TEXT NOT NULL UNIQUE,
    password_hash TEXT NOT NULL,
    full_name TEXT NOT NULL,
    role TEXT NOT NULL, -- e.g., administrator, manager, waiter
    date_created DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- LOYALTY_LEVELS: Loyalty tiers
CREATE TABLE LOYALTY_LEVELS (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL UNIQUE, -- e.g., Standard, Silver, Gold, Platinum
    min_points INTEGER NOT NULL,
    discount_percent REAL NOT NULL -- SQLite uses REAL for decimal values
);

-- CLIENTS: Cafe customers
CREATE TABLE CLIENTS (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    first_name TEXT NOT NULL,
    last_name TEXT NOT NULL,
    phone TEXT,
    email TEXT,
    birth_date DATE,
    loyalty_level_id INTEGER,
    bonus_points INTEGER NOT NULL DEFAULT 0,
    registration_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (loyalty_level_id) REFERENCES LOYALTY_LEVELS(id)
);

-- MENU_ITEMS: Cafe menu
CREATE TABLE MENU_ITEMS (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    description TEXT,
    price REAL NOT NULL,
    category TEXT,
    is_active INTEGER NOT NULL DEFAULT 1 -- 1 = true, 0 = false
);

-- ORDERS: Customer orders
CREATE TABLE ORDERS (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    client_id INTEGER NOT NULL,
    user_id INTEGER NOT NULL,
    order_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    total_amount REAL NOT NULL,
    discount_amount REAL NOT NULL DEFAULT 0,
    bonus_points_used INTEGER NOT NULL DEFAULT 0,
    bonus_points_earned INTEGER NOT NULL DEFAULT 0,
    status TEXT NOT NULL, -- e.g., Open, Closed, Cancelled
    FOREIGN KEY (client_id) REFERENCES CLIENTS(id),
    FOREIGN KEY (user_id) REFERENCES USERS(id)
);

-- ORDER_ITEMS: Items in an order
CREATE TABLE ORDER_ITEMS (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    order_id INTEGER NOT NULL,
    menu_item_id INTEGER NOT NULL,
    quantity INTEGER NOT NULL,
    price REAL NOT NULL, -- price at the time of order
    notes TEXT,
    FOREIGN KEY (order_id) REFERENCES ORDERS(id),
    FOREIGN KEY (menu_item_id) REFERENCES MENU_ITEMS(id)
);