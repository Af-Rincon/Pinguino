# Pinguino

## Integrante

Andrés Rincón

## Introducción

Este proyecto es un juego elaborado en Unity, cuyo desarrollo cubre la mayoria de temas que se vieron a lo largo del curso.
En primera instancia, el concepto del juego gira en torno al control de un pingüino, es decir, que hay interacción de parte del usuario. 
Para maniobrar el pingüino se utilizo el sistema de fisicas que tiene Unity, de forma que se definieron unas reglas para que este personaje
se desplazara, girara y saltara. Asimismo, se utilizó el manejo de camaras para seguir al pingüino y cambiar el angulo de visión con el movimiento del mouse. 
Además, se construyó un escenario en el cual el personaje se va a desplazar. Para su construcción se utilizaron 
varias figuras primitivas, que en conjunto formaron estructuras más complejas. Adicionalmente, a estos objetos se le aplicaron texturas para añadir detalle
a la escena, la cual esta ambientada en el Ártico. Por ultimo, se utilizaron efectos especiales (VFX) para que el pingüino dejara un rastro por los lugares por los cuales iba pasando 
y asi simular el deslizamiento sobre la nieve. 

## Assets y Paquetes

- CinemaMachine
- ProBuilder
- 4 Snow Materials
- Low Poly Winter Pack

## Instrucciones para la ejecución

1. Clonar el repositorio.
2. Abrir la carpeta del repositorio en UnityHub.
3. Abrir la escena SampleScene y darle al boton de Play.
4. Utilizar los botones de AWSD para desplazarse, la barra espaciadora para saltar y
las letras J y K para realizar maniobras. Además, puede mover la camara con el mouse.

### Errores conocidos
En ocasiones el pingüino va muy rapido y su collider logra atravesar el plano que representa el suelo del juego. En estos casos hay que reiniciar el juego.
