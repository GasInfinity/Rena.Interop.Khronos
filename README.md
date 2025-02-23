# 🔗 Rena.Interop.Khronos

Almost type-safe, modern and raw .NET interop bindings for numerous Khronos APIs.

## ❓ How to use the generator

I recommend cloning the repo for now and running it from there, until a .NET tool is published.

The generator supports currently generating Vulkan, OpenGL (ES Included!) and WGL bindings with support for almost all extensions (as I cannot test all of them). It maintains 'type-safety' to an extend by making use of the 'group' attribute in OpenGL enums. However, the gl.xml spec from Khronos doesn't have group attributes for every element and command parameter so if something doesn't have a group it will end up in an 'Ungrouped' enum.

It currently generates everything in a self contained file with all the declarations inside a `static class`. All functions are stored as C# unmanaged function pointers so the only overhead is that of the instantiation of the Loader (e.g: <ClassName>.Commands in OpenGL based ones) and P/Invoke stubs // GC Transitions.

The bindings are generated on a 'per-device basis', that is: It is recommended to maintain different instantiations of `Commands` per context for OpenGL. Vulkan already mandates a different `DeviceCommands` instantiation per device.

The main CLI arguments are:
```bash
--spec <GL|Vulkan|WGL> --apis <API> <Version> [<API> <Version> ...] --namespace <Namespace> --class-name <ClassName> --output <Output> --extensions [<GL_...> <GL_...> ...]
```
