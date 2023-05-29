

### Introduccion
Usualmente cuando se esta realizando un proyecto es necesario tener en cuenta como se puede realizar este mismo de una forma en la cual pueda ser tolerante a fallas, pero una forma de poder simular fallas directamente es realizado propias caidas del sistem utilizando Chaos Engineering, en vez de provocar o similar errores dentro del propio sistema lo que puede provocar son errores directos en los pods para ver como se podra comportar el sistema ante estas situaciones.

### Contenido

Lo primero que se debe de realizar para empezar a usar cheeky monkey es realizar los pasos iniciales mencionados en el Reamde:
```
git clone https://github.com/richstokes/cheekymonkey
cd cheekymonkey
py -m pip install -r requirements.txt
py -m cheekymonkey.py
```
![pip install](./assets/1%20py%20install.png)

posteriormente se puede configurar las constantes las cuales usara cheeky monkey en constars.py, donde por motivos de recursos y resolucion, bajare el tamaño de la ventana e incrementare la vida de los pods.

``` python
# Size of the window
SCREEN_WIDTH = 800
SCREEN_HEIGHT = 800

# How many hits can the containers take before being destroyed?
CONTAINER_HEALTH = 5
```
posteriormente para la ejecucion de cheeky monkey se utilizan todos los namespaces y se tienen que excluir, asi que en mi caso hice suficientes excepciones para solo dejar el namespace default para cheeky monkey
```
py -m cheekymonkey.py --exclude istio-system kube-node-lease kube-system  kube-public 
```
![Ejecucion](./assets/2%20cheeky%20monkey.png)

posteriormente lo que queda es observar los contenedores y ver como cheekymonkey borra los pods y ver como esto le afecta a los pods.

![Pods](./assets/3%20pods.png)

ver lo que tarda en levantarse el servicio, que en un servicio de cloud computing tardan aproximadamente 9 segundos en volver a estar activas

![kube pods](./assets/4%20kubectl%20pods.png)

Esto sin afectar el servicio

![servicio](./assets/5%20servicio.png)

### Conclusion
El poder tener un programa que nos permite generar fallas en otro programa nos permite demostrar la disposicion de la disponibilidad que poseemos actualmente considerando que actualmente de las arquitecturas mas usadas se basan en microservicios aun mas que basarse en apis unicas para modificar todo, siendo esto que permite poder seccionar los programas en entornos diferentes, que aunque falle una parte del programa todo lo demas sigue funcionando, y aun asi con las tecnologias que se tienen como lo es k8s permite poder hacer que una caida de 9s en una unica seccion en vez de la totalidad del sistema ni siquiera se note.