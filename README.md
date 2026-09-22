# POS_Nova 🧾

Sistema de Punto de Venta (POS) desarrollado con **.NET 8** bajo arquitectura limpia (Clean Architecture).

---

## Arquitectura del proyecto

El sistema está dividido en capas:

- **POS_Nova.Api** → Exposición de endpoints HTTP (Controllers)
- **POS_Nova.Application** → Lógica de aplicación (casos de uso)
- **POS_Nova.Domain** → Entidades y reglas de negocio puras
- **POS_Nova.Infrastructure** → Acceso a datos e integraciones externas
- **Database** → Scripts SQL del sistema

---

## Estructura de base de datos

Dentro de la carpeta `Database/` encontrarás los scripts necesarios para crear la BD:

Ejecutar los scripts en el orden indicado por su prefijo numérico.:

1. `01_Database.sql` --Crea la BD
2. `02_Schemas.sql`
3. `03_Core_Domain.sql`
4. `04_Reference_Geography.sql`
5. `05_Security.sql`
6. `06_Inventory.sql`
7. `07_Sales_Master.sql`
8. `08_Transactions.sql`

Ejecutar Script 09 para crear usuario admin y poder crear nuevos usuario (correo: admin@test.com / contraseña: 123456)

9. `09_Create_User_Update_Table_User`

## Tecnologías utilizadas

- .NET 8
- ASP.NET Core Web API
- SQL Server
- Entity Framework Core 


## Estado del proyecto

- [x] Estructura inicial creada
- [x] Scripts de base de datos definidos
- [x] Implementación de API
- [x] Integración con EF Core
- [x] Casos de uso (Application Layer)

FASE 1 — AUTH CORE

- [x] Login
- [x] BCrypt
- [x] JWT generation
- [x] Roles
- [x] Claims
- [x] Clean Architecture

FASE 2 — AUTH PROFESIONAL

- [x] JWT Authentication
- [x] Authorization
- [x] Swagger JWT
- [x] Exception middleware
- [x] CurrentUserService
- [x] Policies

FASE 3 — SECURITY ENTERPRISE

- [ ] Refresh Tokens
- [ ] Revoke tokens
- [ ] Email confirmation
- [ ] Reset password
- [ ] Rate limiting
- [ ] 2FA


