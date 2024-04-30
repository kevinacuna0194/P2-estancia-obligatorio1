# Obligatorio 1 Programación 2 :bookmark_tabs:
~~~
Una estancia que se dedica a la compra y engorde de bovinos y ovinos nos solicita la creación 
de un sistema que ayude a sus empleados a gestionar y organizar las labores diarias del 
establecimiento. 
Para esto se nos encarga en primera instancia, la realización de una versión beta del sistema 
para poder probar funcionalidades básicas mediante una interfaz de consola. 
En reuniones con los encargados del establecimiento nos cuentan que tienen varios empleados 
de los cuales interesa registrar un email y contraseña de mínimo 8 caracteres (que utilizarán 
para acceder al sistema en futuras versiones), el nombre y la fecha de ingreso. Además, los 
empleados pueden ser de dos tipos: capataz o peón. De los capataces interesa guardar, 
además, la cantidad de personas a cargo que tiene. De los peones se debe conocer si son 
residentes en la estancia y las tareas que le han sido asignadas por los capataces. De estas 
tareas se debe conocer un identificador numérico auto incremental, una descripción, la fecha 
pactada para su realización, si la tarea fue completada o no, la fecha de cierre y un comentario 
que agregará el peón cuando la tarea sea finalizada. 
El establecimiento trabaja con ganado que adquiere joven y luego engorda para su venta. De 
cada animal se conoce el código identificador de su caravana (alfanumérico de 8 dígitos y 
único), el sexo (MACHO o HEMBRA), la raza (texto), la fecha de nacimiento, el costo de 
adquisición, el costo de alimentación, su peso actual y si es un híbrido o no. La estancia tiene 
ganado ovino y bovino. De los ovinos se sabe además el peso estimado de la lana, el precio por 
kilogramo de lana y el precio por kilogramo de ovino en pie (ambos comunes para todos los 
ovinos). De los bovinos se conoce, además de los datos básicos de todos los animales, el tipo 
de alimentación que recibe que puede ser a grano o pastura y el precio por kilogramo de 
bovino en pie, común a todos los animales de este tipo. 
Todos los animales también deben tener registro de todas las vacunaciones que han recibido. 
De cada tipo de vacuna que los animales necesitan se conoce el nombre, una descripción y el 
patógeno que previenen. Cuando un animal es vacunado, se debe registrar qué tipo de vacuna 
recibió, la fecha y el vencimiento de esta (siempre será un año después de administrada la 
vacuna). Un animal no puede recibir vacunas antes de los 3 meses de edad. 
Para organizar a todos los animales en el campo, se divide la superficie en varios potreros. De 
cada potrero se conoce un identificador numérico auto incremental, una descripción, la 
cantidad de hectáreas que abarca, la capacidad máxima de animales y la lista de todos los 
animales que pastan allí. En un potrero pueden convivir animales de distinto tipo, pero la 
cantidad de animales nunca puede superar la capacidad máxima del potrero. Una vez que el 
animal es asignado a un potrero no será movido durante todo el proceso de cría. Si un animal 
no ha sido aún asignado a un potrero, se lo considera como “libre”. 
Para determinar las ganancias estimadas de la venta de un potrero se debe obtener el precio 
estimado de venta del animal y restarle el costo total de su crianza. 
• El costo de crianza del animal se determina sumando el costo de adquisición más el 
costo de alimentación. 
• A dicho costo se le suman $200 por cada vacuna administrada. 
• El potencial precio de venta en ovinos se determina multiplicando el peso de lana 
estimada por el precio por kilogramo de lana. A esto se le suma el producto del precio 
por kilogramo de ovino en pie por el peso del animal. Además, si la raza es híbrida a 
este precio se le resta un 5%. 
• Para calcular el precio potencial de venta de un bovino se multiplica su peso por el 
precio por kilogramo de bovino. Si el bovino fue alimentado a grano se le agrega un 
30% y si además es hembra se le agrega otro 10%. 
Los encargados del establecimiento nos explican que, para esta primera etapa, no necesitan 
implementar el cálculo de ganancias por potrero, pero les interesa que sepamos cómo 
resolverlo porque será solicitado en futuras etapas.  
IMPORTANTE: Para esta entrega no se solicita realizar el método que calcula las ganancias de 
un potrero ni tampoco una funcionalidad de “Login” para los empleados. Solo se tomará en 
cuenta a nivel de diseño en el diagrama de clases. 
Se  pide: 
Punto 1: Diseño 
• Diseño de la realidad planteada. 
• Diagrama de clases completo del Dominio (Reglas del negocio) que modele la situación 
anterior. Se seguirá el estándar UML y debe ser presentado en formato Astah. 
Punto 2: Implementación 
Implementar al menos dos proyectos 1) biblioteca de clases y 2) aplicación de consola – que 
incluyan el código que corresponda - en Visual Studio 2022 usando .NET 8 y C# como lenguaje 
de programación, que incluya: 
1. Codificación de las clases del dominio necesarias para cumplir con todos los 
requerimientos del sistema solicitados para este obligatorio (atributos, propiedades, 
constructor/es, ToString). 
2. Precarga de datos en el sistema para que permita hacer pruebas con distintos 
escenarios. 
Se deberá implementar como mínimo precarga de: 
• Peón: Se deben crear al menos 10 peones con diferentes datos. 
• Tareas: Precargar al menos 15 tareas para cada peón en diferentes estados 
(completas o no) con diferentes fechas. 
• Capataz: Precarga de al menos 2 capataces 
• Ganado: Precarga de al menos 30 animales de cada tipo con diferentes 
características. Se valorará la calidad de los datos. 
• Vacunas: Se precargarán al menos 10 tipos de vacunas distintas  
• Vacunaciones: los registros de vacunación para cada animal. Puede haber 
animales aún sin vacunar. 
• Potreros: Crear al menos 10 potreros y asignar a ellos todos los animales 
precargados. 
Nota: Para la generación masiva de datos de precarga deberá utilizar ChatGPT o 
cualquier herramienta de IA generativa en al menos 3 ítems de precarga. Se deberá 
incluir el link y/o los prompts realizados y las respuestas generadas.  
Al momento de implementar los métodos de alta se deben realizar las validaciones 
definidas, mediante la implementación de una interfaz de validación. 
3. Desplegar un menú en consola que permita: 
a. Listado de todos los animales mostrando: 
i. Id de caravana 
ii. Raza
iii. Peso Actual
iv. Sexo 
b. Dados una cantidad de hectáreas y un número, mostrar todos los potreros con 
área mayor a dicha cantidad de hectáreas y una capacidad máxima superior al 
número dado. De cada potrero se debe mostrar su identificador, la descripción, 
la cantidad de hectáreas y la capacidad máxima. 
c. Establecer el precio por kilogramo de lana de los ovinos. 
d. Alta de ganado bovino. No es necesario crear sus registros de vacunación ni 
asignarlo a un potrero. No será posible ingresar dos animales con el mismo 
número de caravana. 
~~~
---
<p align="center" font-weight="bold">
      <img src="https://img.shields.io/badge/CSHARP-239120?style=for-the-badge&logo=csharp&logoColor=white">
      <br>
      <img src="https://img.shields.io/badge/ESTADO-EN%20DESARROLLO-blue?logo=csharp&logoColor=violet&logoSize=10px">
</p>