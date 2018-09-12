using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SingleResponsibilityPrinciple.Core
{
    public class CustomerDataExporter
    {
        public static string ExportToCSV(List<Customer> data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in data)
            {
                sb.AppendFormat("{0}, {1}, {2}, {3}",
                    item.CustomerID,
                    item.CompanyName,
                    item.ContactName,
                    item.Country);

                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static string ExportToXML(List<Customer> data)
        {
            throw new NotImplementedException();
        }

        public static string ExportToPDF(List<Customer> data)
        {
            throw new NotImplementedException();
        }
    }
}