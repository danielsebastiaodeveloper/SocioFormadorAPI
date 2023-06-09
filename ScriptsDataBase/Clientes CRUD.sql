SELECT *
FROM Clientes;

INSERT INTO Clientes (Nombre, Apellido, Email, CiudadId)
VALUES ('Daniel', 'Sebastiao', 'daniel.2.sebastiao@atos.net', 1);
INSERT INTO Clientes (Nombre, Apellido, Email, CiudadId)
VALUES ('Hector', 'Cisneros', 'hector-delfino.cisneros@atos.net', 1);
INSERT INTO Clientes (Nombre, Apellido, Email, CiudadId)
VALUES ('Juan', 'Lima', 'juan.lima@atos.net', 1);

SELECT *
FROM Clientes;

UPDATE Clientes
SET Nombre = 'Carolina'
WHERE Id = 3;

SELECT *
FROM Clientes;

DELETE
FROM Clientes
Where Id = 3;

SELECT *
FROM Clientes;