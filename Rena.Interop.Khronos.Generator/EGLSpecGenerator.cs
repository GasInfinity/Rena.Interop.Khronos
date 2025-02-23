// using System.CodeDom.Compiler;
// using static Rena.Interop.Khronos.Generator.Generation;
//
// namespace Rena.Interop.Khronos.Generator;
//
// public sealed class EGLSpecGenerator : GLSpecGeneratorBase
// {
//     public override string Prefix
//         => "egl";
//
//     public EGLSpecGenerator(Registry registry, GeneratorOptions options) : base(registry, options)
//     {
//     }
//
//     protected override void WriteRequiredFields(IndentedTextWriter writer)
//     {
//         base.WriteRequiredFields(writer);
//
//         if (!includedConstants.Any(e => e.Name is "EGL_EXTENSIONS"))
//             writer.WriteLine("internal const int EGL_EXTENSIONS = 0x3055;");
//     }
//
//     protected override void WriteLoadingStatements(IndentedTextWriter writer)
//     {
//         base.WriteLoadingStatements(writer);
//
//         writer.WriteLine("delegate* unmanaged<void*, int, byte*> eglQueryString;");
//         GenerateFixedLoadStatement(writer, FunctionToUtf8FunctionName("eglQueryString"), "eglQueryString", "delegate* unmanaged<void*, int, byte*>");
//
//         writer.WriteLine("delegate* unmanaged<int> eglGetError;");
//         GenerateFixedLoadStatement(writer, FunctionToUtf8FunctionName("eglGetError"), "eglGetError", "delegate* unmanaged<int>");
//
//         writer.WriteLine("if(eglQueryString is null || eglGetError is null) return;");
//
//         if (!IncludedApis.IsDefaultOrEmpty)
//         {
//             writer.WrtLine("var version = eglQueryString((void*)EGL_NO_DISPLAY, EGL_VERSION);")
//                   .WrtLine("_ = eglGetError();")
//                   .WrtLine("if(version == null) (Major, Minor) = (1, 0);")
//                   .WrtLine("else if(!TryParseVersion(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(version), out Major, out Minor)) return;");
//         }
//
//         if (IncludedExtensions != null)
//         {
//             writer.WrtLine("static bool IsExtensionSupported(ReadOnlySpan<byte> allExtensions, ReadOnlySpan<byte> extension)")
//                   .AddIndentation()
//                     .WrtLine("=> extensions.IndexOf(extension) != -1;")
//                   .RemoveIndentation()
//                   .WrtLine()
//                   .WrtLine("var allExtensionsPointer = eglQueryString(null, EGL_EXTENSIONS);")
//                   .WrtLine("ReadOnlySpan<byte> allExtensions = allExtensionsPointer != null ? MemoryMarshal.CreateReadOnlySpanFromNullTerminated(allExtensionsPointer) : default;");
//
//             foreach (var extension in IncludedExtensions)
//                 writer.WriteLine($"{extension.Key} = IsExtensionSupported(allExtensions, {ExtensionToUtf8ExtensionName(extension.Key)});");
//         }
//     }
//
//     protected override bool IsExtensionIncluded(KeyValuePair<string, Extension> extension)
//         => extension.Value.Supported.Contains(KhronosApi.EGL);
//
//     protected override bool IsApiIncluded(Feature feature)
//         => feature.Apis.Contains(KhronosApi.EGL) && options.Data.Version.IsIncluded(feature.Number);
// }
