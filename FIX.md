# Retroalimentación - Entrega 1

Hola Enzo,

Recibimos tu **Entrega 1** y el aviso de que el grupo cambió de composición. Ya la revisamos: **está aprobada**. Cumplís el alcance de la entrega —la solución compila, respeta la arquitectura de referencia y Swagger levanta con el CRUD completo de Product y Category en memoria—, pero encontramos un error que hace que la categoría de un producto no se guarde. Te lo detallamos abajo porque conviene resolverlo antes de meter Entity Framework.

## Lo que está bien

- La arquitectura está bien separada y fiel a la referencia: `Domain.Model`, `DTOs`, `Data`, `Application.Services` y `WebAPI`.
- Modelaste seis entidades (Product, Category, Order, Table, User, Price), no solo las dos que pedía la entrega. El modelo está pensado más allá del mínimo.
- Los tipos de datos están bien elegidos: `decimal` para dinero, `DateTime` para fechas y `enum` para todos los estados (`ProductState`, `CategoryState`, `OrderState`, `UserType`). Es un detalle que se paga caro cuando llega Entity Framework, y vos ya lo tenés resuelto.
- El encapsulamiento está bien aplicado: `private set` más un método `set...` por atributo.
- **Price como histórico** es una buena decisión de diseño: Product guarda una lista de precios con su fecha y la propiedad `Price` devuelve el vigente. Te va a servir para los reportes de la entrega final.
- Los endpoints capturan `ArgumentException` y devuelven 400, dejando propagar el resto. Es exactamente el criterio correcto.
- El repositorio está prolijo: `.gitignore` completo, sin `bin`, `obj` ni archivos `.user` versionados. Es lo que pide la consigna.

## A tener en cuenta para la siguiente entrega

### La respuesta del POST queda incompleta
Devuelve `state: null`, mientras que el GET del mismo producto devuelve `"Listed"`. Conviene armar el DTO de respuesta a partir de la entidad ya guardada, igual que hacés en el GET.

## Comentario sobre el modelo

Order con su lista de productos y de mesas es justo el caso que pide la consigna para el CRUD maestro/detalle. Lo que le falta es la **entidad de línea de pedido** (producto, cantidad y precio al momento del pedido) — y ahí es donde el histórico de precios que ya armaste se vuelve útil. 

User con `UserType` (Client, Waiter, Admin) ya cubre el requisito de dos tipos de usuario con permisos distintos.

---

**Te pedimos que apliques estos puntos en la Entrega 2: los vamos a mirar cuando la corrijamos.**

Saludos,

**Sebastián**