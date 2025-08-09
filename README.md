# 🐄 Obligatorio 1 – Programación 2

> Desarrollo de un sistema para la gestión de tareas y animales en una estancia dedicada al engorde de bovinos y ovinos.  
> Esta primera versión se implementa como una **aplicación de consola** en C# (.NET 8), con enfoque en diseño de clases y precarga de datos.

---

## 🧠 Descripción del Proyecto

Una estancia ganadera solicita un sistema para organizar las labores diarias de sus empleados.  
El sistema debe permitir modelar empleados, tareas, animales, vacunas y potreros, con una lógica clara y validaciones específicas.

---

## 👥 Empleados

- **Datos comunes**: email (mínimo 8 caracteres), contraseña, nombre, fecha de ingreso.
- **Tipos**:
  - **Peón**: residente o no, tareas asignadas.
  - **Capataz**: cantidad de personas a cargo.

---

## 📋 Tareas

- ID numérico auto incremental.
- Descripción, fecha pactada, estado (completa o no), fecha de cierre, comentario de cierre.

---

## 🐑🐂 Animales

- **Datos comunes**: caravana (alfanumérico, único), sexo, raza, fecha de nacimiento, costos, peso, híbrido.
- **Ovinos**: peso estimado de lana, precio por kg de lana, precio por kg en pie.
- **Bovinos**: tipo de alimentación (grano/pastura), precio por kg en pie.
- **Vacunaciones**: tipo de vacuna, fecha, vencimiento (1 año). No se vacunan antes de los 3 meses.

---

## 🌾 Potreros

- ID auto incremental, descripción, hectáreas, capacidad máxima, lista de animales.
- No se permite superar la capacidad ni mover animales una vez asignados.
- Animales no asignados se consideran “libres”.

---

## 💰 Cálculo de Ganancias (Diseño, no implementación)

> Aunque no se implementa en esta entrega, se debe modelar en el diseño de clases.

- **Costo de crianza** = adquisición + alimentación + $200 por vacuna.
- **Ovinos**: lana + peso en pie – 5% si híbrido.
- **Bovinos**: peso × precio, +30% si grano, +10% si hembra.

---

## 📌 Requisitos de la Entrega

### 🧩 Punto 1: Diseño

- Diagrama de clases completo del dominio (UML, formato Astah).

### 💻 Punto 2: Implementación

- Proyecto de biblioteca de clases + aplicación de consola (.NET 8, Visual Studio 2022).
- Implementación de clases con atributos, propiedades, constructores y `ToString`.
- Precarga de datos con calidad y variedad.

#### 🔄 Precarga mínima

| Entidad     | Cantidad | Detalles |
|-------------|----------|----------|
| Peones      | 10       | Residentes y no residentes |
| Tareas      | 15/peón  | Completas e incompletas |
| Capataces   | 2        | Con personas a cargo |
| Animales    | 30/tipo  | Bovinos y ovinos |
| Vacunas     | 10       | Tipos distintos |
| Vacunaciones| —        | Algunos animales sin vacunar |
| Potreros    | 10       | Todos los animales asignados |

> ⚠️ Se debe usar IA generativa (como ChatGPT) en al menos 3 ítems de precarga.  
> Incluir los prompts y respuestas generadas.

---

### 🧪 Validaciones

- Implementar interfaz de validación para métodos de alta.
- No permitir animales con caravana duplicada.
- Validar edad mínima para vacunación.

---

### 📋 Menú en Consola

- Listado de animales (caravana, raza, peso, sexo).
- Filtrado de potreros por hectáreas y capacidad.
- Establecer precio por kg de lana.
- Alta de bovino (sin vacunación ni asignación inicial).

---

<p align="center">
  <img src="https://img.shields.io/badge/CSHARP-239120?style=for-the-badge&logo=csharp&logoColor=white">
  <img src="https://img.shields.io/badge/.NET-8.0-blueviolet?style=for-the-badge&logo=dotnet&logoColor=white">
  <br>
  <img src="https://img.shields.io/badge/ESTADO-EN%20DESARROLLO-blue?style=for-the-badge&logo=github&logoColor=white">
</p>
