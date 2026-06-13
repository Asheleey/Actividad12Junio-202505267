# Actividad AVL API

Este proyecto implementa una simulación de balanceo compuesto en árboles AVL usando ASP.NET Core Minimal APIs.

## Endpoints

GET /api/arbol

Permite consultar el estado actual del árbol.

POST /api/arbol/insertar

Permite insertar un nodo y simular una rotación RID cuando se inserta el nodo 20.

## Ejemplo de POST

{
  "id": 20,
  "etiqueta": "Nieto Derecho"
}

## Resultado esperado

El nodo 20 pasa a ser la nueva raíz balanceada.
