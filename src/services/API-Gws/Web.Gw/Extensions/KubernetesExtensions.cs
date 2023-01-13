//---------------------------------------------------------------------------
// <copyright file="OcelotBuilderExtensions.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Web.Gw.Extensions;

using KubeClient;
using Ocelot.DependencyInjection;
using Ocelot.Provider.Kubernetes;
using Ocelot.ServiceDiscovery;
using Ocelot.ServiceDiscovery.Providers;
using Ocelot.Values;

/// <summary>
/// Helper extensions to support ApiGW services discovery within K8s cluster.
/// </summary>
public static class KubernetesExtensions
{
    private static readonly ServiceDiscoveryFinderDelegate FixedKubernetesProviderFactoryGet = (provider, config, reroute) =>
    {
        var serviceDiscoveryProvider = KubernetesProviderFactory.Get(provider, config, reroute);

        if (serviceDiscoveryProvider is KubernetesServiceDiscoveryProvider)
        {
            serviceDiscoveryProvider = new Kube(serviceDiscoveryProvider);
        }
        else if (serviceDiscoveryProvider is PollKubernetes)
        {
            serviceDiscoveryProvider = new PollKube(serviceDiscoveryProvider);
        }

        return serviceDiscoveryProvider;
    };

    public static IOcelotBuilder AddKubernetesFixed(this IOcelotBuilder builder, bool usePodServiceAccount = true)
    {
        builder.Services.AddSingleton(FixedKubernetesProviderFactoryGet);
        builder.Services.AddKubeClient(usePodServiceAccount);

        return builder;
    }

    private class Kube : IServiceDiscoveryProvider
    {
        private readonly IServiceDiscoveryProvider serviceDiscoveryProvider;

        public Kube(IServiceDiscoveryProvider serviceDiscoveryProvider)
        {
            this.serviceDiscoveryProvider = serviceDiscoveryProvider;
        }

        public Task<List<Service>> Get()
        {
            return serviceDiscoveryProvider.Get();
        }
    }

    private class PollKube : IServiceDiscoveryProvider
    {
        private readonly IServiceDiscoveryProvider serviceDiscoveryProvider;

        public PollKube(IServiceDiscoveryProvider serviceDiscoveryProvider)
        {
            this.serviceDiscoveryProvider = serviceDiscoveryProvider;
        }

        public Task<List<Service>> Get()
        {
            return serviceDiscoveryProvider.Get();
        }
    }
}