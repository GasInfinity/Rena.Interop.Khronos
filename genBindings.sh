#! /bin/sh

# OpenGL 4.6 Core + OpenGL ES 3.2
dotnet run --project "Rena.Interop.Khronos.Generator/Rena.Interop.Khronos.Generator.csproj" -- --spec GL --apis GL 4.6 GLES2 3.2 --profile Core --output Rena.Interop.OpenGL/GL.g.cs --class-name GL --namespace Rena.Interop.OpenGL

# OpenGL 4.6 Core Only
dotnet run --project "Rena.Interop.Khronos.Generator/Rena.Interop.Khronos.Generator.csproj" -- --spec GL --apis GL 4.6 --profile Core --output Rena.Interop.OpenGL/GLCore.g.cs --class-name GLCore --namespace Rena.Interop.OpenGL

# OpenGL 4.6 Compatibility Only
dotnet run --project "Rena.Interop.Khronos.Generator/Rena.Interop.Khronos.Generator.csproj" -- --spec GL --apis GL 4.6 --profile Compatibility --output Rena.Interop.OpenGL/GLCompat.g.cs --class-name GLCompat --namespace Rena.Interop.OpenGL

# OpenGL ES 3.2 Only
dotnet run --project "Rena.Interop.Khronos.Generator/Rena.Interop.Khronos.Generator.csproj" -- --spec GL --apis GLES2 3.2 --output Rena.Interop.OpenGL/GLES2.g.cs --class-name GLES2 --namespace Rena.Interop.OpenGL

# OpenGL ES 1.1 Only
dotnet run --project "Rena.Interop.Khronos.Generator/Rena.Interop.Khronos.Generator.csproj" -- --spec GL --apis GLES1 1.1 --output Rena.Interop.OpenGL/GLES1.g.cs --class-name GLES1 --namespace Rena.Interop.OpenGL

# TODO: EGL 1.5
# dotnet run --project "Rena.Interop.Khronos.Generator/Rena.Interop.Khronos.Generator.csproj" -- --spec EGL --apis EGL 1.5 --output Rena.Interop.EGL/EGL.g.cs --class-name EGL --namespace Rena.Interop.EGL
