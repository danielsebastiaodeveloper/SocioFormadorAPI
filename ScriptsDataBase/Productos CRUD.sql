Select *
from Pedidos;

INSERT INTO Pedidos (ClienteId, Total, Cantidad)
VALUES (1, 1000, 5);
INSERT INTO Pedidos (ClienteId, Total, Cantidad)
VALUES (1, 15300.5, 10);
INSERT INTO Pedidos (ClienteId, Total, Cantidad)
VALUES (1, 299.99, 3);
INSERT INTO Pedidos (ClienteId, Total, Cantidad)
VALUES (2, 0, 0);

SELECT *
FROM Pedidos;

UPDATE Pedidos
SET Cantidad = 1
WHERE Id = 4;

SELECT *
FROM Pedidos;

DELETE
FROM Pedidos
Where Id = 4;

SELECT *
FROM Pedidos;