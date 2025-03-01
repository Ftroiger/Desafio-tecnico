# API de Productos

## 📌 Requisitos
Dependencias necesarias para ejecutar la API:
- AutoMapper (14.0.0)
- Microsoft.EnityFrameworkCore (9.0.2)
- Microsoft.EnityFrameworkCore.Tools (9.0.2)
- Microsoft.EnityFrameworkCore.Design (9.0.2)
- Microsoft.EnityFrameworkCore.Sqlite (9.0.2)
- SQLite (para base de datos en memoria)

## 🚀 Instalación y Ejecución

1. **Clonar el repositorio:**
   ```sh
   git clone https://github.com/usuario/desafio-tecnico.git
   cd desafio-tecnico
   ```

2. **Instalar NuGet Package**

3. **Ejecutar la API**

## 📄 Endpoints:

### 1️⃣ Obtener todos los productos
**Método:** GET  
**URL:** `http://localhost:7240/producto/producto/getAll`  
**Respuestas:**
- `200 OK`: Lista de productos
- `404 Not Found`: No hay productos disponibles
- `500 Internal Server Error`: Error en el servidor

### 2️⃣ Obtener un producto por ID
**Método:** GET  
**URL:** `http://localhost:7240/producto/producto/getById/{id}`  
**Respuestas:**
- `200 OK`: Devuelve el producto
- `404 Not Found`: Producto no encontrado
- `422 Unprocessable Entity`: ID inválido
- `500 Internal Server Error`: Error en el servidor

### 3️⃣ Insertar un nuevo producto
**Método:** POST  
**URL:** `http://localhost:7240/producto/producto/create`  
**Cuerpo:**
```json
{
  "name": "Producto 1",
  "description": "Descripción del producto 1",
  "price": 1000,
  "quantity": 10
}
```
**Respuestas:**
- `200 OK`: Producto creado
- `400 Bad Request`: Datos inválidos
- `500 Internal Server Error`: Error en el servidor

### 4️⃣ Modificar un producto
**Método:** PUT  
**URL:** `http://localhost:7240/producto/producto/update/{id}`  
**Cuerpo:** Igual al de creación  
**Respuestas:**
- `200 OK`: Producto actualizado
- `400 Bad Request`: Datos inválidos
- `500 Internal Server Error`: Error en el servidor

### 5️⃣ Eliminar un producto
**Método:** DELETE  
**URL:** `http://localhost:7240/producto/producto/delete/{id}`  
**Respuestas:**
- `200 OK`: Producto eliminado con mensaje de éxito
- `404 Not Found`: Producto no encontrado
- `500 Internal Server Error`: Error en el servidor



