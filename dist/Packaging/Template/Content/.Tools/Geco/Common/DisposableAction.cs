namespace Geco.Common;

public readonly struct DisposableAction(Action? action) : IDisposable
{
   public void Dispose()
   {
      action?.Invoke();
   }
}