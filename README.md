# METRICA

| 1. /ARCHI --> Contiene el diseño y detalle a nivel de arquitectura de los componentes involucrados para el proyecto "Online Events".|
|------------|
* Realizado con la herramienta DrawIo.

| 2. /BE --> Contiene los componentes backends con las siguientes características: |
|------------|
* Tecnología NetCore 10 con ORM EntityFramefrork (EF), librerías necesarias:
  - dotnet add package Microsoft.EntityFrameworkCore --version 10.
  - dotnet add package Microsoft.EntityFrameworkCore.Design --version 10.
  - dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 10.
* Habilitación de redirección seguro https por componente
* Clean arquitecture (Ports & Adapters, Hexagonal)
* Producer y Consumers (eventos), integración mediante el Broker Kafka (topicos "event-topic","notification-topic")
* Persistencia de datos en motor PostgreSql
* Migraciones: Entidades → DbContext → Migración → Base de Datos → Tablas, librerías necesarias:
  - dotnet tool install --global dotnet-ef
  - dotnet ef migrations add eventMigration --project .\mic-event-api.csproj
  - dotnet ef database update eventMigration --project .\mic-event-api.csproj
 
| 3. /FE --> Contiene el componente cliente web frontend con las siguientes características: |
|------------|
* Tecnologías ReactJs 18x, NextJs 13x, NextAuth
* tailwindcss 3x, facilita:
  - Alta productividad
  - Diseño consistente
  - CSS sin archivos gigantes
  - Excelente integración con Next.js
* Autenticación federada (Social Login con Google IDP --> OAuth 2.0 / OIDC)
* Envío del idToken para su validación en backend (BFF o microservicio)

| 4. /DEPLOY --> Contiene los archivos compose .yaml para su despliegue en bloque: |
|------------|
* Tecnologías ReactJs 18x, NextJs 13x, NextAuth
  
    

