using KubeClient;
using Ocelot.DependencyInjection;
using Ocelot.Provider.Kubernetes;
using Ocelot.ServiceDiscovery;
using Ocelot.ServiceDiscovery.Providers;
using Ocelot.Values;

namespace Web.Gw.Extensions;

public static class OcelotBuilderExtensions
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
            return this.serviceDiscoveryProvider.Get();
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
            return this.serviceDiscoveryProvider.Get();
        }
    }
}