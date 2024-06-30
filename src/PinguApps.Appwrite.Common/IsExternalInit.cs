using System.ComponentModel;

namespace System.Runtime.CompilerServices;

#if !NET5_0_OR_GREATER

[EditorBrowsable(EditorBrowsableState.Never)]
internal static class IsExternalInit { }

#endif // !NET5_0_OR_GREATER
