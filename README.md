# HospitalNSC (Hospital Ultimate)

Sistema de escritorio de turnos y sala de espera para las clínicas del Hospital Nuestra Señora del Carmen (Cobán, Alta Verapaz), hecho en VB.NET con WPF.

## Contexto

- Año: 2019.
- Tercera iteración de la idea, después de [Tickets](https://github.com/thealejandro/Tickets) (2018) y [Hospital-Repair](https://github.com/thealejandro/Hospital-Repair) (2018). Fue el primer sistema de turnos que desarrollé para el hospital, siendo estudiante, y la versión más completa de las tres.
- Proyecto histórico, sin mantenimiento. Lo conservo como registro de mi trayectoria; la versión actual de esta idea son xaCare y xaSeguros, en https://xacode.dev.

## Funcionalidades observadas en el código

- Inicio de sesión con roles Administrador, Doctor y Secretaria contra MySQL (base `dbturnos`).
- Secretaria: genera tickets por doctor (hasta 10 clínicas), ve qué ticket está en atención en cada clínica, abre el panel de sala de espera, configura su video (URL en línea o archivo local) y el texto del banner, y puede eliminar tickets.
- Doctor: lista de pacientes en espera para su clínica, llamar al siguiente, marcar atendido y cambiar su estado conectado/desconectado.
- Administrador: alta, actualización y baja de usuarios.
- Panel de sala de espera: muestra los tickets llamados por doctor, banner en marquesina y video (YouTube vía CefSharp o archivo local con MediaElement).
- Registro de errores en archivo (`Dialogs/Log.vb`).

## Tecnologías

- VB.NET, WPF, .NET Framework 4.7.2.
- MaterialDesignThemes, MySql.Data 8.0, CefSharp.Wpf (Chromium embebido).

## Cómo abrirlo

1. Abrir `HospitalNSC.sln` en Visual Studio 2019 y restaurar los paquetes NuGet.
2. Tener un servidor MySQL con la base `dbturnos` (el esquema no está incluido en el repositorio).
3. Ajustar la cadena de conexión `Server` en `Hospital Ultimate/App.config` (configuración `My.Settings`). No deben usarse credenciales reales en el código.

## Estado

Proyecto histórico, sin mantenimiento. No incluye archivo de licencia.
