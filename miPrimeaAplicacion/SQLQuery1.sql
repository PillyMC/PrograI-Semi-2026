
CREATE TABLE USTR159126 (
    idUsuario INT IDENTITY(1,1) PRIMARY KEY,
    usuario VARCHAR(35) NOT NULL,
    clave VARCHAR(35) NOT NULL,
    nombre VARCHAR(65) NOT NULL,
    dirección VARCHAR(85) NOT NULL,
    teléfono VARCHAR(9) NOT NULL
);

-- Inserción de 3 registros requeridos (Punto 1 del examen)
INSERT INTO USTR159126 (usuario, clave, nombre, dirección, teléfono)
VALUES 
('admin123', 'Clave1234', 'Carlos Ruiz', 'Calle Principal #12, Usulután', '7890-1234'),
('mendoza_j', 'Pass2026', 'Juan Mendoza', 'Av. Peralta #45, San Salvador', '7123-4567'),
('ana_lopez', 'Secure99', 'Ana López', 'Barrio El Centro, San Miguel', '7555-8888');