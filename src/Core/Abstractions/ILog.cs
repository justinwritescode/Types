using Microsoft.Extensions.Logging;

namespace JustinWritesCode.Abstractions;

/// <summary>
/// Marker interface for a class that has a reference to an <see cref="ILogger"/>.
/// </summary>
public interface ILog
{
    ILogger Logger { get; }
}
