-- Active: 1681199865739@@127.0.0.1@3306@dataLayer

DROP TABLE IF EXISTS dog;

CREATE TABLE dog (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    breed VARCHAR(255),
    birth_date DATE
);


INSERT INTO dog (name, breed, birth_date) VALUES ('Fido', 'Corgi', '2022-01-04'), ('Rex', 'Dalmatian', '2015-05-04'), ('Jean Marc', 'Daschund', '2019-07-25');

SELECT * FROM dog;