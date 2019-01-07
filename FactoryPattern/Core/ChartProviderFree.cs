using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPattern.Core
{
    public class ChartProviderFree : IChartProvider
    {
        public IChart GetChart()
        {
            IChart chart = new BarChart();
            return chart;
        }
    }
}
