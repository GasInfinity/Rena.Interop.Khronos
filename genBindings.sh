#! /bin/sh

dotnet run --project "Rena.Interop.OpenGl.Generator/Rena.Interop.OpenGl.Generator.csproj" -- --api Gl --profile Core --output Rena.Interop.OpenGl/Gl --class-name "Gl" --namespace Rena.Interop.OpenGl --api-version 4.5
dotnet run --project "Rena.Interop.OpenGl.Generator/Rena.Interop.OpenGl.Generator.csproj" -- --api Gl --profile Compatibility --output Rena.Interop.OpenGl/GlCompat --class-name "GlCompat" --namespace Rena.Interop.OpenGl --api-version 4.5
dotnet run --project "Rena.Interop.OpenGl.Generator/Rena.Interop.OpenGl.Generator.csproj" -- --api Gles2 --output Rena.Interop.OpenGl/Gles2 --class-name "Gles2" --namespace Rena.Interop.OpenGl --api-version 3.2
dotnet run --project "Rena.Interop.OpenGl.Generator/Rena.Interop.OpenGl.Generator.csproj" -- --api Egl --output Rena.Interop.Egl/ --class-name "Egl" --namespace Rena.Interop.Egl --api-version 1.5