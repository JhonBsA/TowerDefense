<H1>🛡️ Tower Defense - Proyecto Final 🛡️</h1>

<br>
<strong>Descripción del Proyecto 🎮</strong>

Este proyecto es un juego de tipo Tower Defense desarrollado en Unity, donde el jugador tiene la tarea de colocar torres estratégicamente para defender su base de oleadas de enemigos. El objetivo principal es utilizar patrones de diseño para hacer que el juego sea funcional, extensible y fácil de mantener. El juego permite al jugador colocar torres fuera del camino, mientras que gestiona su dinero para optimizar su defensa.

<br>
<strong>Características Principales 🚀</strong>

<b>Única línea de defensa:</b> Los enemigos siguen un único camino, y el jugador puede colocar torres alrededor del mismo.

<b>Sistema de dinero:</b> El jugador gana dinero al eliminar enemigos y puede gastarlo en colocar nuevas torres.

<br>
<b>Patrones de diseño implementados:</b>

<b>Singleton:</b> Gestión del estado global del juego (puntuación, recursos, etc.).

<b>Factory Method:</b> Creación dinámica de torres y enemigos.

<b>Observer:</b> Actualización en tiempo real de la UI y del estado del juego.

<b>Strategy:</b> Comportamientos de ataque de las torres y movimientos de los enemigos.

<b>State:</b> Manejo de los diferentes estados de los enemigos (moviéndose, atacando, muriendo).

<b>Composite:</b> Gestión de grupos de torres y enemigos.

<br>
<strong>Estructura del Proyecto 📂</strong>

    /Assets
        /Scripts
            /Managers
            /Towers
            /Enemies
            /Patterns
            /Utilities
        /Prefabs
        /Scenes
        /UI
        /Audio
        /Materials
        /Textures

<br>
<strong>🛠️ Carpetas importantes:</strong>

<b>Scripts:</b> Código fuente del juego, dividido en Managers, Towers, Enemies y patrones de diseño.

<b>Prefabs:</b> Modelos y objetos reutilizables, como torres, enemigos y zonas de colocación.

<b>Scenes:</b> Escenas del juego, como el menú principal y la escena de juego.

<b>UI:</b> Elementos visuales de la interfaz de usuario.

<b>Audio:</b> Archivos de sonido para efectos en el juego.

<b>Materials y Textures:</b> Materiales y texturas visuales.

<br>
<strong>Requisitos del Sistema 🖥️</strong>

<b>Unity:</b> Versión 2022 o superior.

<b>Visual Studio:</b> Con soporte para C#.

<b>SDK:</b> .NET 8.0 para compatibilidad con scripts.

<br>
<strong>Instalación y Configuración ⚙️</strong>

1. Clona este repositorio en tu máquina local:

       git clone https://github.com/tu-usuario/TowerDefense

2. Abre el proyecto con Unity Hub y selecciona la versión adecuada.
   
3. Asegúrate de que Visual Studio esté configurado como el editor de código en Unity.

4. Ejecuta el proyecto desde Unity y empieza a construir tu estrategia.
