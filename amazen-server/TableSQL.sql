-- CREATE TABLE profiles (
--     id VARCHAR(255) NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     email VARCHAR(255) NOT NULL,
--     picture VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- )

-- CREATE TABLE items (
--     id INT NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     color VARCHAR(255) NOT NULL,
--     isAvailable TINYINT,
--     price INT NOT NULL,
--     PRIMARY KEY (id)
-- )

-- CREATE TABLE wishlists (
--     id INT NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     creatorId VARCHAR(255),
--     PRIMARY KEY (id)
-- )

-- CREATE TABLE wishlistitems (
--     id INT NOT NULL AUTO_INCREMENT,
--     itemId INT,
--     wishlistId INT NOT NULL,
--     creatorId VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id),

--     FOREIGN KEY (itemId)
--     REFERENCES items (id)
--     ON DELETE CASCADE,

--     FOREIGN KEY (wishlistId)
--     REFERENCES wishlists (id)
--     ON DELETE CASCADE,

--     FOREIGN Key (creatorId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE
-- )

-- CREATE TABLE itemwishlists (
--     id INT NOT NULL AUTO_INCREMENT,
--     itemId INT NOT NULL,
--     wishlistId INT,
--     creatorId VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id),

--     FOREIGN KEY (itemId)
--     REFERENCES items (id)
--     ON DELETE CASCADE,

--     FOREIGN KEY (wishlistId)
--     REFERENCES wishlists (id)
--     ON DELETE CASCADE,

--     FOREIGN Key (creatorId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE
-- )
