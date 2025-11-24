MicroServicioMarketing — Backend
Descripción del proyecto

El backend de MicroServicioMarketing es un microservicio REST construido con ASP.NET Core 8 y Entity Framework Core.
Su objetivo es gestionar la información de estudiantes de manera eficiente, permitiendo crear, leer, actualizar y eliminar registros (CRUD) en una base de datos SQL Server.

Este servicio es consumido por un frontend desarrollado en React, que interactúa con la API para mostrar y modificar la información de estudiantes en tiempo real.

Funcionalidades principales

Crear estudiantes: Registrar nuevos estudiantes con nombre, celular y email.

Obtener lista de estudiantes: Consultar todos los estudiantes ordenados por nombre.

Actualizar estudiantes: Modificar nombre, celular y email de un estudiante específico.

Eliminar estudiantes: Borrar un registro de estudiante de la base de datos.

Timestamps automáticos: Cada registro incluye la fecha de última actualización (FechaActualizacion).

Tecnologías utilizadas

ASP.NET Core 8: Framework principal para el backend.

Entity Framework Core: ORM para interactuar con SQL Server.

SQL Server: Base de datos relacional para almacenamiento persistente.

Docker: Contenedores para ejecutar la base de datos y el backend de forma aislada y reproducible.

Swagger: Documentación automática de la API y testing de endpoints.

Estructura del proyecto

Controllers/EstudianteController.cs: Contiene todos los endpoints para CRUD de estudiantes.

Data/EstudianteContext.cs: Contexto de Entity Framework para conectar con la base de datos.

Modelo/Estudiante.cs: Modelo que define la entidad estudiante con sus propiedades.

Program.cs: Configuración del servidor, conexión a la base de datos, CORS y Swagger.

Dockerfile: Permite crear una imagen del backend lista para correr en Docker.

docker-compose.yml: Configura contenedores para SQL Server y el backend.

Cómo se desarrolló

Modelo de datos
Se creó la clase Estudiante con las propiedades:

Id: Identificador único.

Nombre: Nombre del estudiante.

Celular: Número de contacto.

Email: Correo electrónico.

FechaActualizacion: Fecha de la última modificación.

Contexto de EF Core
EstudianteContext define el DbSet de estudiantes y se conecta a la base de datos SQL Server usando una cadena de conexión configurable.

Controlador REST
EstudianteController implementa endpoints para:

GET: /api/Estudiante y /api/Estudiante/{id}

POST: /api/Estudiante

PUT: /api/Estudiante/{id}/contact

DELETE: /api/Estudiante/{id}

Dockerización

SQL Server y el backend se ejecutan en contenedores separados.

Se define una red interna (micro-red) para que los contenedores se comuniquen entre sí.

Docker permite desplegar el backend de forma consistente en cualquier máquina.

Cómo ejecutar el backend

Con Docker

docker-compose up --build


Esto levanta dos contenedores:

db: SQL Server con la base de datos StudentDB.

backend: Microservicio ASP.NET Core corriendo en el puerto 5272.

Sin Docker (opcional)

Configurar la cadena de conexión en Program.cs o appsettings.json.

Ejecutar el proyecto en Visual Studio o usando CLI:

dotnet restore
dotnet build
dotnet run


Acceder a Swagger para probar la API

http://localhost:5272/swagger

Objetivo del proyecto

El backend permite centralizar la lógica de negocio y persistencia de la información de estudiantes, ofreciendo:

Seguridad en el manejo de datos.

Interoperabilidad con cualquier frontend o microservicio que consuma la API.

Escalabilidad mediante contenedores y Docker.

Este microservicio es ideal para aprender la arquitectura de aplicaciones modernas con microservicios, REST APIs, y Docker