-- DROP TABLE profiles

-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),
--   PRIMARY KEY(id)
-- )

-- SELECT * FROM vaultkeeps
-- DROP TABLE keeps

-- CREATE TABLE keeps
-- (
--   id INT AUTO_INCREMENT,
--   creatorId VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   img VARCHAR(255) NOT NULL,
--   views INT,
--   shares INT,
--   keeps INT,
--   PRIMARY KEY(id),

--   FOREIGN KEY (creatorId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE
-- )

-- CREATE TABLE vaults
-- (
--   id INT AUTO_INCREMENT,
--   creatorId VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   isPrivate TINYINT,
--   PRIMARY KEY(id),

--   FOREIGN KEY (creatorId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE
-- )

-- CREATE TABLE vaultkeeps
-- (
--   id INT AUTO_INCREMENT,
--   creatorId VARCHAR(255) NOT NULL,
--   vaultId INT,
--   keepId INT,
--   PRIMARY KEY(id),

--   FOREIGN KEY (creatorId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE,

--   FOREIGN KEY (vaultId)
--     REFERENCES vaults (id)
--     ON DELETE CASCADE,

--   FOREIGN KEY (keepId)
--     REFERENCES keeps (id)
--     ON DELETE CASCADE
-- );