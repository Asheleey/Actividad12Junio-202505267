# Actividad de Investigación 
## Balanceo Compuesto en Árboles AVL y Exposición de Estructuras vía Web APIs

---

# Parte 1: Investigación Teórica y Análisis de Casos

## 1. El Límite de las Rotaciones Simples y Desbalanceo en "Zig-Zag"

### El Problema Cruzado

Las rotaciones simples funcionan correctamente cuando el desbalance ocurre en una sola dirección. Por ejemplo:

- Caso Izquierda-Izquierda (LL)
- Caso Derecha-Derecha (RR)

Sin embargo, existen situaciones donde el crecimiento del árbol ocurre de forma cruzada, generando una estructura conocida como **Zig-Zag**.

Un ejemplo clásico es la inserción de los valores:

```text
30
/
10
 \
 20
```

En este escenario:

- 30 actúa como abuelo.
- 10 actúa como hijo izquierdo.
- 20 actúa como nieto derecho.

Si se aplica únicamente una rotación simple, el árbol continúa desbalanceado o simplemente cambia la inclinación hacia el lado contrario.

Por esta razón se requiere una **Rotación Doble Izquierda-Derecha (RID)**.

### Condiciones Matemáticas para una RID

La rotación RID se ejecuta cuando:

```text
FE(Padre) = -2
FE(Hijo Izquierdo) = +1
```

Donde:

- FE = Factor de Equilibrio.
- El nodo padre presenta un desbalance hacia la izquierda.
- El hijo izquierdo presenta un desbalance hacia la derecha.

Este patrón indica que existe una configuración cruzada Izquierda-Derecha y debe corregirse mediante una rotación compuesta.

### Resultado de la Rotación RID

Antes:

```text
    30
   /
 10
   \
   20
```

Después:

```text
    20
   /  \
 10   30
```

El árbol queda perfectamente balanceado.

Factores de equilibrio finales:

```text
FE(20) = 0
FE(10) = 0
FE(30) = 0
```

---

## Principio DRY (Don't Repeat Yourself)

El principio DRY establece que una funcionalidad no debe implementarse varias veces cuando puede reutilizarse.

En el caso de las rotaciones AVL, las operaciones compuestas:

- Rotación Izquierda-Derecha (RID)
- Rotación Derecha-Izquierda (RDI)

pueden construirse reutilizando las rotaciones simples existentes:

- Rotación Simple Izquierda
- Rotación Simple Derecha

### Ventajas

1. Menor cantidad de código.
2. Menor probabilidad de errores en la manipulación de punteros.
3. Mayor facilidad de mantenimiento.
4. Mejor reutilización de componentes.
5. Código más legible y modular.

Por ejemplo:

```text
RID =
Rotación Izquierda sobre el hijo
+
Rotación Derecha sobre el abuelo
```

De esta manera se evita volver a programar toda la reasignación de referencias desde cero.

---

# 2. Fundamentos de Arquitectura Web y Protocolo HTTP

## El Modelo Cliente-Servidor

El modelo Cliente-Servidor es una arquitectura donde dos componentes principales interactúan:

### Cliente

Es la aplicación que solicita información.

Ejemplos:

- Navegador web
- Aplicación móvil
- Aplicación de escritorio
- Herramientas como Postman

### Servidor

Es la aplicación encargada de procesar solicitudes y devolver respuestas.

Ejemplos:

- ASP.NET Core
- Node.js
- Spring Boot
- Django

### Flujo de Comunicación

#### Request (Petición)

El cliente envía una solicitud al servidor.

Contiene información como:

- Método HTTP (GET, POST, PUT, DELETE)
- URL
- Encabezados
- Datos opcionales

Ejemplo:

```http
GET /api/arbol HTTP/1.1
Host: localhost:5000
```

#### Response (Respuesta)

El servidor procesa la petición y devuelve un resultado.

Contiene:

- Código de estado
- Encabezados
- Datos solicitados

Ejemplo:

```http
HTTP/1.1 200 OK
Content-Type: application/json
```

Datos:

```json
[
  {
    "id": 30,
    "etiqueta": "Nodo Raíz"
  }
]
```

### Representación General

```text
Cliente
   |
   | Request
   v
Servidor
   |
   | Response
   v
Cliente
```

---

## Semántica de Operaciones HTTP

### Método GET

El método GET se utiliza para recuperar información almacenada en el servidor.

Características:

- No modifica datos.
- Es seguro.
- Se utiliza para consultas.
- Puede ejecutarse múltiples veces sin alterar el estado del sistema.

Ejemplo:

```http
GET /api/arbol
```

Resultado:

```json
[
  {
    "id": 30,
    "etiqueta": "Nodo Raíz"
  }
]
```

---

### Método POST

El método POST se utiliza para enviar información al servidor y generar cambios en los datos almacenados.

Características:

- Inserta nuevos datos.
- Modifica el estado del sistema.
- Generalmente recibe información en formato JSON.

Ejemplo:

```http
POST /api/arbol/insertar
```

Cuerpo:

```json
{
  "id": 20,
  "etiqueta": "Nieto Derecho"
}
```

Resultado esperado:

```json
{
  "mensaje": "Rotación RID ejecutada con éxito."
}
```

---

## Diferencia Técnica entre GET y POST

| Característica | GET | POST |
|----------------|------|------|
| Recupera datos | Sí | No principalmente |
| Inserta datos | No | Sí |
| Modifica información | No | Sí |
| Envía datos en cuerpo | Normalmente no | Sí |
| Uso principal | Consulta | Creación o modificación |

### Conclusión

- **GET** está diseñado para recuperar la estructura de datos existente.
- **POST** está diseñado para insertar, modificar o mutar elementos dentro del sistema.

---

# Referencias

1. Material de la Sesión 10: Rotaciones Dobles en Árboles AVL.
2. Documentación oficial de ASP.NET Core Minimal APIs.
3. Documentación oficial del protocolo HTTP.
4. Principio DRY (Don't Repeat Yourself) aplicado al desarrollo de software.
