# Instala herramientas locales (dotnet-ef)
dotnet tool restore

# Descarga paquetes NuGet del proyecto
dotnet restore

# Aplica las migraciones existentes y crea la DB local si no existe
dotnet tool run dotnet-ef database update

# Crea una nueva migracion
dotnet tool run dotnet-ef migrations add <Modelo>

# Levanta la app para probar endpoints
dotnet run


