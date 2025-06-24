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

## 🗄️ Migraciones y base de datos

Si es la primera vez que ejecutas el proyecto:

```bash
dotnet ef database update
```

> Asegúrate de tener configurado el paquete `Pomelo.EntityFrameworkCore.MySql`.

---

## 🚀 Ejecutar el backend

```bash
dotnet run
```

El backend se ejecutará por defecto en:

```
https://localhost:7299
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

- Las rutas protegidas requieren el header:  
  `Authorization: Bearer {token}`

- El backend sigue principios SOLID y divide responsabilidades claramente entre controladores, servicios, modelos y DTOs.

---

## 🧑‍💻 Autor

Este backend fue desarrollado como parte de una prueba técnica para Tecnimática, integrando buenas prácticas de desarrollo, seguridad y diseño limpio.

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
