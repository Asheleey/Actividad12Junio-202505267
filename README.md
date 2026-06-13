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

## EVIDENCIA
<img width="528" height="314" alt="image" src="https://github.com/user-attachments/assets/01173af2-a6aa-4ae0-9e7f-7e4dbbd78449" />
<img width="745" height="767" alt="image" src="https://github.com/user-attachments/assets/2d516368-df8d-467d-afb5-9f0c686ea499" />


