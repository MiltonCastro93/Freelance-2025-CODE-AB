# 🧩 Freelance 2025 — CODE: AB

**Freelance 2025 — CODE: AB** es un **prototipo de videojuego técnico** desarrollado como **encargo freelance** bajo un **plazo muy corto (2 días)**.  
El objetivo fue crear una **experiencia jugable funcional** ambientada en un entorno desértico, destinada a **centros recreativos**, con un **sistema de combate entre tanques en tercera persona**.

---

## 💼 Contexto del Proyecto

El proyecto fue encargado con **tiempo limitado**, lo que implicó aprovechar **recursos de la Asset Store de Unity**, específicamente el paquete base [**Tanks! Complete Project**](https://assetstore.unity.com/packages/essentials/tutorial-projects/tanks-complete-project-46209?srsltid=AfmBOorbf30uj9smrCFxl1DXm4Zx46_lF8q9b6S7zOh_nR1YkqynYVMY).  
A partir de esa base, se desarrolló una **versión personalizada** con **nueva lógica, UI propia, efectos de sonido originales y comportamiento avanzado para enemigos.**

Debido a restricciones de licencia, algunos assets fueron **removidos** antes de su publicación en GitHub.
<div align="left">
  <img src="https://github.com/MiltonCastro93/Freelance-2025-CODE-AB/blob/main/d363096a-87c4-4067-a36d-3c1196383c71.webp" width="350" alt="Captura del proyecto CODE:AB"/>
</div>

---

## ⚙️ Detalles Técnicos

| Aspecto | Descripción |
|----------|-------------|
| 🧩 **Motor** | Unity 2022 |
| 💻 **Lenguaje** | C# |
| 🧠 **Tipo de Proyecto** | Freelance / Prototipo técnico |
| 🎮 **Perspectiva** | Tercera persona |
| 💣 **Género base** | Shooter de tanques |
| 🔉 **Audio** | Efectos de disparo y recarga creados manualmente |
| 🧱 **Estado** | Prototipo funcional |

---

## 🧠 Lógica Implementada

El enfoque principal fue **técnico y de gameplay**, logrando un sistema dinámico en poco tiempo.  
Entre las características implementadas se destacan:

- 💥 **Sistema de disparo con interfaz de proyectiles**, alternando entre munición **HE (alto explosivo)** y **AP (perforante)**.  
- 🎛️ **UI personalizada en Krita**, con indicadores visuales de recarga, tipo de munición y estado del tanque.  
- 🔊 **Efectos de sonido** propios para **disparo y recarga**, integrados con el sistema de animación.  
- 🤖 **Enemigos humanoides animados con Mixamo**, con roles diferenciados:
  - Uno **repara tanques enemigos**.
  - Otro **corre hacia el jugador y explota** al contacto, causando daño.  
- 🧭 **Lógica de tanques enemigos personalizada**, basada en **raycasts** en lugar de *NavMeshAgent*:
  - Patrullaje mediante **trayectorias rectas dinámicas**.
  - **Rotación autónoma** al encontrar obstáculos.
  - **Ataque estático** al detectar al jugador.  
- 🧨 **Efecto ragdoll** aplicado a las torretas, generando una **reacción física divertida** al ser destruidas.

---

## 🎨 Estilo Visual y HUD

El proyecto utiliza un **estilo low poly** con colores cálidos y contrastes fuertes que evocan un **entorno desértico caricaturesco**.  
El **HUD** presenta un diseño **minimalista y claro**, con barras de carga, indicadores visuales y una tipografía de fácil lectura, manteniendo coherencia con el estilo general.

La escena combina **modelos estilizados**, **animaciones de Mixamo** y **efectos de partículas suaves**, logrando una **presentación limpia y legible** incluso en un entorno con gran iluminación.

---

## 🎬 Captura del Proyecto

<div align="center">
  <img src="https://github.com/MiltonCastro93/Freelance-2025-CODE-AB/blob/main/Captura%20de%20pantalla%202025-11-05%20111857.png" width="350" alt="Captura del proyecto CODE:AB"/>
</div>

---

## 📄 Estado y Créditos

| Detalle | Información |
|----------|-------------|
| 📅 **Año** | 2025 |
| 💼 **Origen** | Encargo freelance |
| 🧾 **Duración de desarrollo** | 2 días |
| 🎨 **UI / HUD** | Creado en Krita |
| 🔊 **Audio** | Disparo y recarga producidos por el desarrollador |
| 👨‍💻 **Desarrollador** | Milton Castro |
| 🔓 **Autorización** | Proyecto modificado y publicado con fines demostrativos |

---

> 💬 *“Freelance-2025-CODE-AB” demuestra la capacidad de adaptación y desarrollo técnico bajo presión, integrando lógica personalizada, efectos de sonido y un sistema de combate dinámico en Unity en tiempo récord.*
