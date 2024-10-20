# Desarrollo de servicio web con ASP.NET Core y Angular

## Tecnologías Utilizadas
- ASP.NET Core:  Implementación de la lógica de negocio mediante clases que reflejan las tablas existentes y llamadas a procedimientos almacenados en la capa de datos.
- SQL Server: Base de datos que contiene las tablas Alumnos y AlumnoGradoInstruccion.
- Angular: Realiza solicitudes HTTP a las APIs del backend desplegadas en el servidor local IIS para obtener, agregar, actualizar o eliminar datos de los alumnos. Los datos recibidos se muestran en la interfaz de usuario organizada en tablas.

## Arquitectura del Proyecto
1. **Controlador**: 
   - Recibe las solicitudes del usuario y llama a los métodos del servicio correspondiente.
2. **Servicio**: 
   - Se encarga de la lógica de negocio y utiliza la capa de datos para interactuar con la base de datos, obteniendo o manipulando los datos necesarios.
3. **Capa de Datos**: 
   - Maneja la comunicación con la base de datos SQL Server, realizando las operaciones de creación, lectura, actualización y eliminación (CRUD).
4. **Respuesta al Usuario**: 
   - Los resultados de las operaciones son devueltos al controlador, que prepara la respuesta adecuada para el usuario.
