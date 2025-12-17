CREATE TABLE categorias (
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(150) NOT NULL,
    descripcion TEXT,
    estado BOOLEAN NOT NULL DEFAULT TRUE
);
 
INSERT INTO categorias (nombre, descripcion, estado)
VALUES
    ('Periféricos', 'Teclados, mouse, auriculares y accesorios', TRUE),
    ('Hardware', 'Componentes internos como placas, memorias y procesadores', TRUE),
    ('Monitores', 'Pantallas y equipos relacionados', TRUE),
	('Games', 'Todo lo relacionados a videojuegos', TRUE);
 
select * from categorias p;

 
CREATE TABLE productos (
    id SERIAL PRIMARY KEY,
    codigo VARCHAR(50) NOT NULL,
    nombre VARCHAR(150) NOT NULL,
    descripcion TEXT,
    precio DECIMAL(50,2) NOT NULL,
    activo BOOLEAN NOT NULL DEFAULT TRUE,
    categoria_id INT NOT NULL,
    fecha_creacion TIMESTAMP NOT NULL DEFAULT NOW(),
    fecha_actualizacion TIMESTAMP NULL,
    cantidad_stock INT NOT NULL DEFAULT 0,
 
    CONSTRAINT fk_productos_categorias
        FOREIGN KEY (categoria_id)
        REFERENCES categorias (id)
);
 
CREATE UNIQUE INDEX idx_productos_codigo ON productos(codigo);
 
INSERT INTO productos (codigo, nombre, descripcion, precio, activo, categoria_id, cantidad_stock)
VALUES 
('TEC-001', 'Teclado Mecánico RGB', 'Teclado mecánico para gaming con switches brown.', 350000, TRUE, 1, 25),
('MOU-002', 'Mouse Gamer 7200 DPI', 'Mouse ergonómico con iluminación RGB.', 220000, TRUE, 1, 40),
('CPU-003', 'Procesador AMD Ryzen 5 5600X', '6 núcleos, 12 hilos, excelente rendimiento.', 1800000, TRUE, 2, 10),
('GPU-004', 'Tarjeta Gráfica RTX 3060 12GB', 'NVIDIA RTX 3060 con 12GB GDDR6.', 3500000, TRUE, 2, 5),
('PSS-005', 'Play Station 5 Sony', 'Consola de play station 5 sin ranura', 3800000, TRUE, 4, 5);
 
select * from productos p;