CREATE TABLE Productos (
    ProductoID INT IDENTITY(1,1) PRIMARY KEY, -- ID autoincremental
    Nombre VARCHAR(100) NOT NULL,            -- Nombre del producto
    Precio DECIMAL(10, 2) NOT NULL,          -- Precio del producto
    Stock INT NOT NULL,                      -- Cantidad en inventario
    CategoriaID INT NOT NULL,                -- ID de categoría
    FechaCreacion DATETIME DEFAULT GETDATE() -- Fecha de creación automática
);

-- Crear tabla para Categorías
CREATE TABLE Categorias (
    CategoriaID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(255)
);

-- Crear tabla para Proveedores
CREATE TABLE Proveedores (
    ProveedorID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Telefono VARCHAR(15),
    Email VARCHAR(100),
    Direccion VARCHAR(255)
);
