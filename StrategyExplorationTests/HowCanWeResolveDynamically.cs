using Domain;
using Domain.Models;

namespace StrategyExplorationTests;
public class HowCanWeResolveDynamically
{
    [Fact]
    public void ResolveBasedOnContext()
    {
        var context = new Context(
            weight: 10,
            Warehouse: new Warehouse("123", Country.SE),
            destination: new Destination(Country.SE)
        );
        IBaseCostCalculator[] registeredBaseCostCalculators = 
             [
                new SwedishBaseCostCalculator(),
                new UKBaseCostCalculator()
            ];
        ILastMileCostCalculator[] registeredLastMileProviders = 
            [
                new DHLLastMileCost(),
                new UPSLastMileCost()
            ];

        var resolver = new CostCalculatorResolver(registeredBaseCostCalculators, registeredLastMileProviders);


        var baseCostsProviaders =  resolver.BaseCostCalculatorsFor(context);
        var lastMileCostsProviders = resolver.LastMileCostCalculatorsFor(context);

        Assert.All(baseCostsProviaders, x => x.AppliesToContext(context));
        Assert.All(lastMileCostsProviders, x => x.AppliesToContext(context));
        Assert.IsType<SwedishBaseCostCalculator>(baseCostsProviaders.FirstOrDefault());
        Assert.Contains(lastMileCostsProviders, x => x is DHLLastMileCost || x is UPSLastMileCost);
    }

    [Fact]
    public void ResolveBasedOnContextForUK()
    {
        var context = new Context(
            weight: 10,
            Warehouse: new Warehouse("123", Country.SE),
            destination: new Destination(Country.UK)
        );
        IBaseCostCalculator[] registeredBaseCostCalculators =
             [
                new SwedishBaseCostCalculator(),
                new UKBaseCostCalculator()
            ];
        ILastMileCostCalculator[] registeredLastMileProviders =
            [
                new DHLLastMileCost(),
                new UPSLastMileCost()
            ];

        var resolver = new CostCalculatorResolver(registeredBaseCostCalculators, registeredLastMileProviders);


        var baseCostsProviaders = resolver.BaseCostCalculatorsFor(context);
        var lastMileCostsProviders = resolver.LastMileCostCalculatorsFor(context);

        Assert.All(baseCostsProviaders, x => x.AppliesToContext(context));
        Assert.All(lastMileCostsProviders, x => x.AppliesToContext(context));
        Assert.IsType<SwedishBaseCostCalculator>(baseCostsProviaders.FirstOrDefault());
        Assert.Contains(lastMileCostsProviders, x => x is DHLLastMileCost || x is UPSLastMileCost);
    }
}

