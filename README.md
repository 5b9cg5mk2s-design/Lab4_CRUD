# Laboratorio #4 - Sistema de Gestión de Productos con MySQL y Windows Forms

**Fecha:** 06/10/2026

## Contenido del Repositorio

Este laboratorio consiste en el desarrollo de un sistema de gestión de productos utilizando Windows Forms, Programación Orientada a Objetos (POO) y una base de datos MySQL.

La aplicación permite realizar operaciones CRUD (Crear, Consultar, Actualizar y Eliminar), gestionar imágenes de productos, implementar validaciones mediante interfaces gráficas y aplicar principios de diseño de software como el patrón Repository y la inversión de dependencias.

El sistema incorpora funcionalidades avanzadas como:

- Persistencia de datos en MySQL.
- Búsqueda dinámica de registros.
- Gestión de imágenes.
- Borrado lógico.
- Auditoría de usuarios.
- Validación de datos mediante ErrorProvider.
- Uso de interfaces para desacoplar la lógica de acceso a datos.

---

## Tecnologías Utilizadas

- Lenguaje: C#
- Framework: .NET Framework
- Windows Forms
- MySQL
- MySQL Connector para .NET
- Visual Studio
- Git
- GitHub

---

# Descripción General del Proyecto

La aplicación permite administrar un catálogo de productos almacenado en una base de datos.

Cada producto contiene la siguiente información:

- ID
- Nombre
- Precio
- Cantidad
- Imagen
- Usuario Responsable
- Fecha de Creación
- Fecha de Modificación
- Estado de Anulación

Todos los productos son visualizados mediante un DataGridView y administrados desde una interfaz gráfica amigable.

---

# Arquitectura del Proyecto

El sistema fue diseñado siguiendo principios de Programación Orientada a Objetos y separación de responsabilidades.

## Componentes Principales

### Form1

Contiene toda la lógica visual y la interacción con el usuario.

Responsabilidades:

- Mostrar productos.
- Capturar datos.
- Ejecutar búsquedas.
- Invocar operaciones CRUD.
- Validar información.
- Actualizar controles visuales.

### Producto

Clase de entidad encargada de representar la información de cada producto.

Atributos principales:

```text
- Id
- Nombre
- Precio
- Cantidad
- Imagen
- Anulado
- Usuario
- FechaCreacion
- FechaModificacion
```

### IProductoRepository

Define el contrato que debe implementar cualquier repositorio de productos.

Métodos:

```csharp
Insertar()
ObtenerTodos()
Actualizar()
Anular()
```

### Conexion

Implementa la interfaz `IProductoRepository` y contiene toda la lógica de acceso a MySQL.

Responsabilidades:

- Conexión a la base de datos.
- Inserción de registros.
- Consulta de productos.
- Actualización de información.
- Borrado lógico.

### ImagenHelper

Clase estática encargada de convertir imágenes para almacenarlas y recuperarlas desde la base de datos.

Responsabilidades:

```text
Image → Byte[]
Byte[] → Image
```

---

# Funcionalidades Implementadas

## Registro de Productos

Permite crear nuevos productos ingresando:

- Nombre
- Precio
- Cantidad
- Usuario
- Imagen

### Proceso

1. El usuario completa los campos.
2. Se validan los datos.
3. Se transforma la imagen a bytes.
4. Se almacena la información en MySQL.
5. El DataGridView se actualiza automáticamente.

---

## Consulta de Productos

Al iniciar la aplicación se cargan todos los productos activos.

La información mostrada incluye:

- ID
- Nombre
- Precio
- Cantidad
- Imagen
- Usuario
- Fecha de Modificación

Los datos son obtenidos directamente desde MySQL.

---

## Búsqueda Dinámica

El sistema permite localizar productos mediante un cuadro de búsqueda.

Los filtros incluyen:

- ID
- Nombre
- Usuario

La búsqueda se ejecuta automáticamente mientras el usuario escribe.

---

## Modificación de Productos

El usuario puede seleccionar un registro desde el DataGridView.

Al seleccionar una fila:

- Se cargan los datos en los controles.
- La imagen es mostrada en el PictureBox.
- Es posible modificar cualquier campo.

Posteriormente:

1. Se validan los datos.
2. Se actualiza el registro en la base de datos.
3. Se refresca la cuadrícula.

---

## Eliminación Lógica

El sistema no elimina físicamente los registros.

En su lugar:

```sql
UPDATE productos
SET anulado = 1
WHERE id = ?
```

### Ventajas

- Conservación del historial.
- Mayor seguridad de información.
- Recuperación futura de registros.

---

## Gestión de Imágenes

Cada producto puede almacenar una fotografía.

### Carga de Imagen

Se utiliza un OpenFileDialog para seleccionar:

```text
JPG
JPEG
PNG
BMP
```

### Conversión para Base de Datos

```csharp
Image → Byte[]
```

### Recuperación

```csharp
Byte[] → Bitmap
```

La imagen vuelve a mostrarse automáticamente dentro del PictureBox cuando se selecciona un registro.

---

# Validaciones Implementadas

La aplicación utiliza ErrorProvider para mostrar mensajes visuales sin interrumpir al usuario.

## Nombre

Valida que el campo no esté vacío.

```text
El nombre del producto es obligatorio.
```

## Usuario

Valida que exista un usuario responsable.

```text
Debe especificar el usuario operador.
```

## Precio

Valida que sea un valor decimal correcto.

```text
Ingrese un formato de precio decimal válido.
```

## Cantidad

Valida que sea un número entero.

```text
La cantidad debe ser un número entero válido.
```

---

# Principios de Programación Orientada a Objetos Aplicados

## Encapsulación

La información de los productos se encuentra encapsulada dentro de la clase:

```csharp
Producto
```

mediante propiedades.

---

## Abstracción

La interfaz:

```csharp
IProductoRepository
```

oculta los detalles internos de acceso a datos.

---

## Polimorfismo

La interfaz permite que diferentes implementaciones del repositorio puedan utilizarse sin modificar la lógica principal.

Ejemplo:

```csharp
private readonly IProductoRepository _repository;
```

---

## Inversión de Dependencias

La aplicación depende de una abstracción:

```csharp
IProductoRepository
```

y no directamente de la clase:

```csharp
Conexion
```

---

## Uso de Métodos Estáticos

La clase:

```csharp
ImagenHelper
```

implementa métodos auxiliares reutilizables para la conversión de imágenes.

---

# Capturas de Pantalla

## Pantalla Principal

<img width="904" height="730" alt="image" src="https://github.com/user-attachments/assets/7bd762de-f8a2-4133-9eeb-ba8d22d9dcd4" />


## Registro de Productos

<img width="898" height="734" alt="image" src="https://github.com/user-attachments/assets/b48e2c16-fda6-4d35-8878-1f4fc2299fe3" />


## Selección de Imagen

<img width="895" height="725" alt="image" src="https://github.com/user-attachments/assets/d3c37b07-edc1-4be4-8c6b-71da87805193" />


## Modificación de Registros

<img width="880" height="76" alt="image" src="https://github.com/user-attachments/assets/742ecdc3-85a1-4d48-9651-4465dd08c5d8" />


## Búsqueda de Productos

<img width="897" height="276" alt="image" src="https://github.com/user-attachments/assets/317455ef-6822-4846-9605-2c2083b554f1" />

---

# Estructura de Carpetas o Directorios

```plaintext
Laboratorio4/
│
├── Form1.cs
├── Form1.Designer.cs
│
├── Producto.cs
│
├── IProductoRepository.cs
│
├── Conexion.cs
│
├── ImagenHelper.cs
│
├── Properties/
│
├── images/
│   ├── pantalla-principal.png
│   ├── registro-productos.png
│   ├── cargar-imagen.png
│   ├── modificar-producto.png
│   └── busqueda-productos.png
│
└── README.md
```

---

# Base de Datos Utilizada

## Motor

```text
MySQL
```

## Base de Datos

```text
productosdb
```

## Tabla Principal

```text
productos
```

## Campos Utilizados

```text
id
nombre
precio
cantidad
imagen
usuario
anulado
fecha_creacion
fecha_modificacion
```

---

# Instrucciones de Ejecución / Uso

## 1. Clonar el repositorio

```bash
git clone [URL_DEL_REPOSITORIO]
```

## 2. Crear la base de datos MySQL

```sql
CREATE DATABASE productosdb;
```

## 3. Crear la tabla productos

Ejecutar el script correspondiente de la base de datos.

## 4. Configurar la cadena de conexión

Dentro del archivo:

```csharp
Conexion.cs
```

Modificar:

```csharp
Server=localhost;
Database=productosdb;
Uid=root;
Pwd=demo;
```

según las credenciales locales.

## 5. Abrir la solución

Abrir el proyecto en Visual Studio.

## 6. Compilar

```text
Build > Build Solution
```

## 7. Ejecutar

```text
F5
```

---

# Aprendizajes Obtenidos

Durante este laboratorio se reforzaron los siguientes conocimientos:

- Programación Orientada a Objetos.
- Interfaces.
- Principio de Inversión de Dependencias.
- Patrón Repository.
- CRUD con MySQL.
- Conexiones a Bases de Datos.
- Uso de DataGridView.
- Uso de PictureBox.
- Manejo de imágenes en bases de datos.
- Conversión Image ↔ Byte[].
- Validación de formularios.
- Uso de ErrorProvider.
- Borrado lógico.
- Auditoría de registros.
- Programación de aplicaciones empresariales en Windows Forms.

---

# Autor y Contexto

- Nombre: Johandry González
- Institución: Universidad Tecnológica de Panamá (UTP)
- Asignatura: Herramientas de programación aplicada III
- Laboratorio #4
- Fecha de Realización: 06/10/2026

---

# Referencias

- Microsoft Learn - Windows Forms
- Microsoft Learn - Programación Orientada a Objetos en C#
- Microsoft Learn - DataGridView
- Microsoft Learn - Interfaces en C#
- Documentación Oficial de MySQL
- MySQL Connector/NET
- Material proporcionado por el docente
