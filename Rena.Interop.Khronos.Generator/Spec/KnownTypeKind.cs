using System.Collections.Frozen;
using System.Diagnostics;

namespace Rena.Interop.Khronos.Generator;

public enum KnownTypeKind : byte
{
    Unknown,
    Void,
    UInt8,
    Int8,
    UInt16,
    Int16,
    UInt32,
    Int32,
    UInt64,
    Int64,
    Single,
    Double,
    IntPtr,
    UIntPtr,
}

public static class KnownTypeKindExtensions
{
    public static string ToTypeString(this KnownTypeKind kind)
        => kind switch
        {
            KnownTypeKind.Void => "void",
            KnownTypeKind.UInt8 => "byte",
            KnownTypeKind.Int8 => "sbyte",
            KnownTypeKind.UInt16 => "ushort",
            KnownTypeKind.Int16 => "short",
            KnownTypeKind.UInt32 => "uint",
            KnownTypeKind.Int32 => "int",
            KnownTypeKind.UInt64 => "ulong",
            KnownTypeKind.Int64 => "long",
            KnownTypeKind.Single => "float",
            KnownTypeKind.Double => "double",
            KnownTypeKind.UIntPtr => "nuint",
            KnownTypeKind.IntPtr => "nint",
            _ => throw new UnreachableException() 
        };

    public static KnownTypeKind Parse(ReadOnlySpan<char> type)
    {
        return ReallyKnownTypes.TryGetValue(type.ToString(), out KnownTypeKind kind) ? kind : KnownTypeKind.Unknown;
    }

    private static readonly FrozenDictionary<string, KnownTypeKind> ReallyKnownTypes = new Dictionary<string, KnownTypeKind>()
    {
        { "void", KnownTypeKind.Void },
        { "char", KnownTypeKind.UInt8 },
        { "unsigned char", KnownTypeKind.UInt8 },
        { "unsigned short", KnownTypeKind.UInt16 },
        { "int", KnownTypeKind.Int32 },
        { "unsigned int", KnownTypeKind.UInt32 },
        
        { "uint8_t", KnownTypeKind.UInt8 },
        { "int8_t", KnownTypeKind.Int8 },
        { "uint16_t", KnownTypeKind.UInt16 },
        { "int16_t", KnownTypeKind.Int16 },
        { "uint32_t", KnownTypeKind.UInt32 },
        { "int32_t", KnownTypeKind.Int32 },
        { "uint64_t", KnownTypeKind.UInt64 },
        { "int64_t", KnownTypeKind.Int64 },
        { "size_t", KnownTypeKind.UIntPtr },
        { "float", KnownTypeKind.Single },
        { "double", KnownTypeKind.Double },

        { "khronos_uint8_t", KnownTypeKind.UInt8 },
        { "khronos_int8_t", KnownTypeKind.Int8 },
        { "khronos_uint16_t", KnownTypeKind.UInt16 },
        { "khronos_int16_t", KnownTypeKind.Int16 },
        { "khronos_uint32_t", KnownTypeKind.UInt32 },
        { "khronos_int32_t", KnownTypeKind.Int32 },
        { "khronos_uint64_t", KnownTypeKind.UInt64 },
        { "khronos_int64_t", KnownTypeKind.Int64 },
        { "khronos_size_t", KnownTypeKind.UIntPtr },
        { "khronos_ssize_t", KnownTypeKind.IntPtr },
        { "khronos_uintptr_t", KnownTypeKind.UIntPtr },
        { "khronos_intptr_t", KnownTypeKind.IntPtr },
        { "khronos_float_t", KnownTypeKind.Single },

        // HACK: Needed
        { "GLboolean", KnownTypeKind.UInt8 },
        { "GLbitfield", KnownTypeKind.UInt32 },
        { "GLenum", KnownTypeKind.UInt32 },
        { "GLfloat", KnownTypeKind.Single },
        { "GLint", KnownTypeKind.Int32 },
        { "GLsizei", KnownTypeKind.Int32 },
        { "GLuint", KnownTypeKind.UInt32 },
        { "GLushort", KnownTypeKind.UInt16 },
        { "GLhandleARB", KnownTypeKind.IntPtr },

        // Windows types
        { "BOOL", KnownTypeKind.Int32 },
        { "CHAR", KnownTypeKind.Int8 },
        { "DWORD", KnownTypeKind.UInt32 },
        { "COLORREF", KnownTypeKind.UInt32 },
        { "FLOAT", KnownTypeKind.Single },
        { "HANDLE", KnownTypeKind.IntPtr },
        { "HDC", KnownTypeKind.IntPtr },
        { "HENHMETAFILE", KnownTypeKind.IntPtr },
        { "LPGLYPHMETRICSFLOAT", KnownTypeKind.IntPtr },
        { "HINSTANCE", KnownTypeKind.IntPtr },
        { "HWND", KnownTypeKind.IntPtr },
        { "HGLRC", KnownTypeKind.IntPtr },
        { "INT", KnownTypeKind.Int32 },
        { "INT32", KnownTypeKind.Int32 },
        { "INT64", KnownTypeKind.Int64 },
        { "PROC", KnownTypeKind.IntPtr },
        { "RECT", KnownTypeKind.Void }, // TODO
        { "LPCSTR", KnownTypeKind.IntPtr },
        { "UINT", KnownTypeKind.UInt32 },
        { "LPVOID", KnownTypeKind.IntPtr },
        { "USHORT", KnownTypeKind.UInt16 },
        { "VOID", KnownTypeKind.Void },

        // Vulkan extern types
        { "xcb_connection_t", KnownTypeKind.Void },
        { "xcb_visualid_t", KnownTypeKind.UInt32 },
        { "xcb_window_t", KnownTypeKind.UInt32 },
        { "Display", KnownTypeKind.Void },
        { "Visual", KnownTypeKind.Void },
        { "VisualID", KnownTypeKind.UInt32 },
        { "Window", KnownTypeKind.IntPtr },
    }.ToFrozenDictionary();
}
