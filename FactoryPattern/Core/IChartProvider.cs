using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPattern.Core
{
    public interface IChartProvider
    {
        IChart GetChart();
    }
}
