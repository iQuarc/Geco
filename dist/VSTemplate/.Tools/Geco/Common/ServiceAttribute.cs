using Microsoft.Extensions.DependencyInjection;

namespace Geco.Common;

/// <summary>
///    Represents a service to be registered in DI automatically
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class ServiceAttribute(Type contractType, ServiceLifetime lifetime = ServiceLifetime.Transient)
   : Attribute
{
   public Type            ContractType { get; } = contractType ?? throw new ArgumentNullException(nameof(contractType));
   public ServiceLifetime Lifetime     { get; } = lifetime;
}