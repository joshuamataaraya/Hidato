# Hidato
Instituto Tecnológico de Costa Rica 

Escuela de Computación 

Ingeniería en computación 

Lenguajes de Programación 

Joshua Mata Araya 2014079095

##Análisis de Resultados
Selección de celdas A
Generación del hidato A
Cantidad de hints A
Se permite jugar el hidato A
Undo E, no fue implementado
Sugerencia, no fue implementado
NOTA: el juego no cuenta con verificaciones a la hora de jugar, por lo cual el usuario puede cometer muchos errores, ya que es necesario seleccionar el siguiente numero aunque este sea un hint, sin embargo se permite jugar el hidato siempre y cuando no se trate de romper una regla de juego.
##Manual de usuario
Desde una ventana de workspace se debe de ejecutar lo siguiente para usar el programa.
1. Hidato AcercaDe. -> Esto funciona para desplegar el acerca de, es necesario ejecutarlo con alt-p para que se imprima en el workspace la información.

2. Hidato Ayuda. -> Esto funciona para desplegar la ayuda, es necesario ejecutarlo con alt-p para que se imprima en el workspace la información.

3. Hidato DefinirCasillas. -> esto se debe de ejecutar con alt-d para que el usuario pueda definir las casillas en las que desea crear el hidato, es importante siempre seleccionar la casilla de arriba a la izquierda. Ya que a partir de esta se genera el hidato.

4. Hidato crearHidato: NUM. -> esto se debe de ejecutar con alt-d para que el programa genere el hidato y el usuario pueda jugar. Es importante a la hora de jugar seleccionar toda casilla al ingresar un numero, inclusive si esta es un hint.

5. Hidato revisarHidato. -> esto se debe de ejecutar con alt-p esto para que el programa imprima en el work space si el usuario ganó o no.

##Diccionario de clases
Se crearon tres clases:
1. Square: es un botón con el cual se hacen las operaciones de insertar un numero, estas son botones que simulan las casillas, pero con atributos extra para permitir la funcionalidad

2. Matriz: es una matriz de botones que implementa la lógica del juego

3. Hidato: se encarga de llamar las funciones específicas del juego, estas funciones están como métodos estáticos, por lo cual no es necesario guardar una instancia en una variable.

##Algoritmo de generación
Es un algoritmo de backtracking que usar la matriz como si cada elemento es un vértice de un grafo, y trata de buscar una solución en donde recorra todos los vértices. Este algoritmo es capaz de encontrar todos los posibles recorridos, sin embargo al encontrar el primer recorrido, se detiene la recursión. Para mayor dificultad del juego se debe de empezar el algoritmo desde cualquier vértice, pero está implementado para que inicie desde el vértice de izquierda y arriba de la matriz.
