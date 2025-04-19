# Aplicación Full Stack: ASP.NET Core, SQL Server, IIS y Angular

## Tecnologías
- **ASP.NET Core:** Implementación de la lógica de negocio a través de clases que representan entidades y llamadas a procedimientos almacenados.
- **SQL Server:** Base de datos que contiene las tablas *Alumnos* y *GradoInstruccion*.
- **IIS (Internet Information Services)**: Despliegue local del backend para exponer las APIs REST.
- **Angular:** Interfaz de usuario que consume las APIs mediante solicitudes HTTP para realizar operaciones CRUD.

## Arquitectura
- **Controller (Controlador):** Expone los endpoints de la API y recibe las solicitudes HTTP del frontend, las procesa y delega las operaciones a la lógica de negocio.
- **Business (Lógica de negocio):** Se encarga de validar, transformar o coordinar los datos antes de enviarlos a la capa de datos o devolver una respuesta al controlador.
- **Data (Capa de datos):** Realiza las operaciones mediante procedimientos almacenados y devuelve los resultados a la lógica de negocio.
