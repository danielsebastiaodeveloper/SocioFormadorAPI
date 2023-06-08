SELECT * FROM Clientes;

INSERT INTO Clientes (Nombre, Apellido, CorreoElectronico) VALUES ('Daniel', 'Sebastiao', 'daniel.2.sebastiao@atos.net');
INSERT INTO Clientes (Nombre, Apellido, CorreoElectronico) VALUES ('Hector', 'Cisneros', 'hector-delfino.cisneros@atos.net');
INSERT INTO Clientes (Nombre, Apellido, CorreoElectronico) VALUES ('Juan', 'Lima', 'juan.lima@atos.net');

SELECT * FROM Clientes;

UPDATE Clientes SET Nombre = 'Carolina' WHERE Id = 3;

SELECT * FROM Clientes;

DELETE FROM Clientes Where Id = 3;

SELECT * FROM Clientes;