#! /bin/sh

# OpenGL 4.6 Core + OpenGL ES 3.2
dotnet run --project "Rena.Interop.OpenGL.Generator/Rena.Interop.OpenGL.Generator.csproj" -- --api GL    --gl-apis GL GLES2      --gl-versions 4.6 3.2 --profile Core          --output Rena.Interop.OpenGL/GL/        --class-name GL       --namespace Rena.Interop.OpenGL

# OpenGL 4.6 Core Only
dotnet run --project "Rena.Interop.OpenGL.Generator/Rena.Interop.OpenGL.Generator.csproj" -- --api GL    --gl-apis GL            --gl-versions 4.6     --profile Core          --output Rena.Interop.OpenGL/GLCore/    --class-name GLCore   --namespace Rena.Interop.OpenGL

# OpenGL 4.6 Compatibility Only
dotnet run --project "Rena.Interop.OpenGL.Generator/Rena.Interop.OpenGL.Generator.csproj" -- --api GL    --gl-apis GL            --gl-versions 4.6     --profile Compatibility --output Rena.Interop.OpenGL/GLCompat/  --class-name GLCompat --namespace Rena.Interop.OpenGL

# OpenGL ES 3.2 Only
dotnet run --project "Rena.Interop.OpenGL.Generator/Rena.Interop.OpenGL.Generator.csproj" -- --api GL    --gl-apis GLES2         --gl-versions 3.2                             --output Rena.Interop.OpenGL/GLES2/     --class-name GLES2    --namespace Rena.Interop.OpenGL

# OpenGL ES 1.1 Only
dotnet run --project "Rena.Interop.OpenGL.Generator/Rena.Interop.OpenGL.Generator.csproj" -- --api GL    --gl-apis GLES1         --gl-versions 1.1                             --output Rena.Interop.OpenGL/GLES1/     --class-name GLES1    --namespace Rena.Interop.OpenGL

# EGL 1.5
dotnet run --project "Rena.Interop.OpenGL.Generator/Rena.Interop.OpenGL.Generator.csproj" -- --api EGL                                                                         --output Rena.Interop.EGL/              --class-name EGL      --namespace Rena.Interop.EGL     --api-version 1.5