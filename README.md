
# Backend - Tecnimática Fullstack Test

Este es el backend del proyecto fullstack para Tecnimática, desarrollado con ASP.NET Core 8.0 siguiendo principios de arquitectura limpia y buenas prácticas. Permite gestionar usuarios, autenticación con JWT, buscar películas vía OMDb y guardar películas favoritas.

---

## 🧱 Tecnologías y Librerías

- ASP.NET Core 8.0
- Entity Framework Core
- Pomelo.EntityFrameworkCore.MySql
- BCrypt.Net-Next (hash de contraseñas)
- Autenticación JWT (Bearer Token)
- Swashbuckle (Swagger)
- OMDb API (https://www.omdbapi.com/)

---

## 📁 Estructura general del proyecto

```
be-movies/
├── Controllers/
├── DTOs/
├── Models/
├── Services/
├── Helpers/
├── Middleware/
├── Program.cs
├── appsettings.json
└── be-movies.csproj
```

---

## ⚙️ Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [MySQL Server](https://dev.mysql.com/downloads/)
- Tu propia [API Key de OMDb](https://www.omdbapi.com/apikey.aspx)

---

## 🛠️ Configuración inicial

1. Clonar el repositorio:

```bash
git clone https://github.com/tu-usuario/tu-repo-backend.git
cd be-movies
```

2. Crear la base de datos en MySQL (ejemplo `be_movies_db`).

3. Configurar tu cadena de conexión en `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=be_movies_db;user=root;password=tu_password"
}
```

4. Añadir tu API Key de OMDb en el archivo `appsettings.json`:

```json
"OmdbApi": {
  "BaseUrl": "https://www.omdbapi.com/",
  "ApiKey": "tu_api_key_aqui"
}
```

---

## 🚀 Ejecutar el backend

```bash
dotnet run
```

El backend se ejecutará por defecto en:

```
https://localhost:5151
```

---

## 🧪 Documentación Swagger

Puedes acceder a la documentación interactiva en:

```
https://localhost:7299/swagger
```

---

## 🔐 Endpoints disponibles

### Autenticación

- `POST /auth/register` → Registro de nuevo usuario
- `POST /auth/login` → Login y retorno de JWT

### Películas (OMDb)

- `GET /movies/search?title=Batman`
- `GET /movies/details/{imdbId}`

### Favoritos

- `POST /favorites` → Agregar película favorita
- `GET /favorites/{userId}` → Listar favoritas
- `DELETE /favorites/{id}` → Eliminar favorita

---

## 🧾 Notas

- El backend sigue principios SOLID y divide responsabilidades claramente entre controladores, servicios, modelos y DTOs.

---

## 🛠️ Problemas comunes y solución aplicada

### ❌ Error: Conflicting assets with the same target path 'css/site[...].css'

Este error se presentó debido a un conflicto interno con archivos estáticos duplicados al compilar (`site.css`). Aunque no había duplicación explícita en el `.csproj`, el sistema generó archivos temporales en caché que causaban el conflicto.

### ✅ Solución aplicada

1. Se eliminaron manualmente las carpetas generadas automáticamente por el build:

```
bin/
obj/
.vs/
```

2. Luego, se ejecutaron los siguientes comandos para reconstruir el proyecto desde cero:

```bash
dotnet clean
dotnet build
dotnet run
```

Esto resolvió completamente el conflicto de archivos duplicados y permitió que la aplicación corriera correctamente con Swagger funcionando.

---

## 📌 Justificación del Stack Tecnológico

Se eligió el stack ASP.NET Core + MySQL + React por las siguientes razones:

- **ASP.NET Core 8.0**: Framework moderno, multiplataforma y altamente eficiente para desarrollar APIs RESTful con rendimiento robusto y soporte empresarial.
- **Entity Framework Core con Pomelo + MySQL**: ORM potente y flexible que permite mapear modelos a tablas relacionales. Se escogió MySQL por ser un motor liviano, ampliamente adoptado y fácil de configurar.
- **JWT + BCrypt**: Para asegurar sesiones autenticadas con tokens seguros y proteger contraseñas mediante hashing.
- **OMDb API**: Permite acceder rápidamente a información de películas con un consumo sencillo vía HTTP.
- **Swagger**: Documentación interactiva que facilita pruebas y validación de endpoints.

---

## 🧩 Tablas en la Base de Datos

### 📄 Tabla: `Users`

| Campo        | Tipo       | Descripción                        |
|--------------|------------|------------------------------------|
| `Id`         | INT        | Identificador primario             |
| `Username`   | VARCHAR    | Nombre de usuario                  |
| `Password`   | VARCHAR    | Contraseña hasheada con BCrypt     |

---

### 📄 Tabla: `Favorites`

| Campo        | Tipo       | Descripción                        |
|--------------|------------|------------------------------------|
| `Id`         | INT        | Identificador primario             |
| `UserId`     | INT        | Clave foránea hacia `Users`        |
| `ImdbId`     | VARCHAR    | ID único de la película en OMDb    |
| `Title`      | VARCHAR    | Título de la película              |

> La relación entre `Users` y `Favorites` es de **uno a muchos**: un usuario puede tener varias películas favoritas.

---
