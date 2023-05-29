# APIControllersyEFCoreySeguridad

## Actividad ETAPA 4 - Crear controller para Account 
A continuación se describe la actividad que deberás realizar.

### Objetivo
Deberás construir un controller para el modelo Account.

### Instrucciones
- Crea un controller para el modelo **Account** (llamado **AccountController**):
  - Crea los métodos para procesar las solicitudes **GET** (**GetAll** y **GetByID**).  
  - Crea el método para procesar la solicitud **POST**:
    - Recuerda que tanto **Id** como **RegDate** se asignan automáticamente después del INSERT (no debes proporcionar esos campos en el objeto de la solicitud).
    - Si el valor del campo **ClientId** no existe en la BD, deberás generar un **Bad Request (400 status)**.
  - Crea el método para procesar la solicitud **PUT**:
    - Si el valor del campo **ClientId** no existe en la BD (si se quiere asignar la cuenta a otro cliente), deberás generar un **Bad Request (400 status)**.
  - Crea el método para procesar la solicitud **DELETE**.
- Deberás generar también la clase **AccountService**, en la carpeta **Service**. Ahí realizarás las operaciones adecuadas en el **contexto**; el controller va a consumir este servicio.

## Actividad ETAPA 5 - Crear controller para BankTransaction 
A continuación se describe la actividad que deberás realizar.

### Objetivo
Deberás construir un controller para el modelo **BankTransaction**; que deberá estar restringido por JWT. Los registros de **Client** podrán interactuar con el controller para 1) Consultar todas sus cuentas. 2) Realizar retiros de sus cuentas. 3) Realizar depósitos a sus cuentas. 4) Eliminar sus cuentas.

### Instrucciones
- Modifica la tabla **Client**: agrega una nueva columna llamada **Pwd** para almacenar la contraseña del cliente. Notas:
  - La columna **Pwd** puede ser simplemente un **varchar**, aunque puedes encriptar el valor si así lo deseas.
  - Este cambio va a requerir que **actualizes tu modelo** en el código.
- Genera un proceso para autenticar a los registros de **Client**:
  - Puedes trabajar con el **LoginController** que ya definimos (pero enfocado al modelo **Client**) o puedes crear otro controller.
- Genera un JWT con los **claims** del registro de **Client**. Así como en el tutorial, puedes incluir solamente las propiedades **Name** e **Email**.
- Crea un controller para el modelo **BankTransaction**. En este controller, los clientes podrán:
  1. **Consultar todas sus cuentas**. Ojo, un cliente sólamente debe poder ver sus cuentas, no las de otros clientes.  
  2. **Realizar retiros de sus cuentas**. Los retiros podrán ser vía transferencia (asociados a cuentas externas o propias) o en efectivo (sin cuentas externas asociadas).
  3. **Realizar depósitos a sus cuentas**. Los depósitos sólo podrán ser en efectivo (sin cuentas asociadas).
  4. **Eliminar sus cuentas**. Una cuenta sólo podrá ser eliminada si ya no dispone de dinero.
- El controller deberá estar **restringido al token** que acabas de crear.
- Deberás conservar el token para la autenticación de los registros de **Administrator**. Por lo que tu API trabajará con **dos tokens**:
  - Investiga el tema de **Policies** para la autorización en ASP.NET Core.
  - Puedes consultar la respuesta aceptada de [esta pregunta de GitHub](https://stackoverflow.com/questions/49694383/use-multiple-jwt-bearer-authentication).

### Forma de entrega
- Sube el código de tu proyecto a un repositorio público en tu cuenta de GitHub y comparte el enlace en la vía indicada.
