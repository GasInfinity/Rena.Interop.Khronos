#! /bin/sh

dotnet run --project "Rena.Interop.OpenGL.Generator/Rena.Interop.OpenGL.Generator.csproj" -- --api GL    --profile Core          --output Rena.Interop.OpenGL/GL       --class-name GL       --namespace Rena.Interop.OpenGL --api-version 4.6
dotnet run --project "Rena.Interop.OpenGL.Generator/Rena.Interop.OpenGL.Generator.csproj" -- --api GL    --profile Compatibility --output Rena.Interop.OpenGL/GLCompat --class-name GLCompat --namespace Rena.Interop.OpenGL --api-version 4.6
dotnet run --project "Rena.Interop.OpenGL.Generator/Rena.Interop.OpenGL.Generator.csproj" -- --api GLES2                         --output Rena.Interop.OpenGL/GLES2    --class-name GLES2    --namespace Rena.Interop.OpenGL --api-version 3.2
dotnet run --project "Rena.Interop.OpenGL.Generator/Rena.Interop.OpenGL.Generator.csproj" -- --api EGL                           --output Rena.Interop.EGL/            --class-name EGL      --namespace Rena.Interop.EGL    --api-version 1.5