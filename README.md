# VeiderSoft.AgileTools
Aplicación WPF con útiles herramientas para agilizar el desarrollo de software empresarial


## PowerShell
- **Abrir PowerShell**: Desde del explorador de windows en File existe una opcion de abrir PS con root en la carpeta actual.

- **Importar los comandos de una library**
	```
    PS> Import-Module PowerShellModuleInCSharp.dll
    PS> Import-Module PowerShellModuleInCSharp.dll -Force
    ```
    
- **Mostrar los comandos del modulo**
	```
	PS> Get-Command -module PowerShellModuleInCSharp
	```

- **Mostrar ayuda sobre un comando en particular**
	```
	PS> Get-Help Get-NetworkAdapter -full
	```