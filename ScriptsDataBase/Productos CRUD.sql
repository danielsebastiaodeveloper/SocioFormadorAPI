Select * from Pedidos;

INSERT INTO Pedidos (ClienteId, Producto, Cantidad) VALUES (1, 'Producto A', 5);
INSERT INTO Pedidos (ClienteId, Producto, Cantidad) VALUES (1, 'Producto B', 10);
INSERT INTO Pedidos (ClienteId, Producto, Cantidad) VALUES (1, 'Producto C', 3);
INSERT INTO Pedidos (ClienteId, Producto, Cantidad) VALUES (2, 'Producto D', 0);

SELECT * FROM Pedidos;

UPDATE Pedidos SET Cantidad = 1 WHERE Id = 4;

SELECT * FROM Pedidos;

DELETE FROM Pedidos Where Id = 4;

SELECT * FROM Pedidos;