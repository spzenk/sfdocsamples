using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestPerformanceLinQ.BackEnd.BE;
namespace TestPerformanceLinQ.BackEnd
{
    public class SalesDAC
    {
        /// <summary>
        /// Usa la clase en Sales.Datails.dbml
        /// Usa LinQ
        /// </summary>
        public static IEnumerable<SalesOrderHeader> BuscarVentasByParams(int pCustomerID)
        {
            SalesDataContext dc = new SalesDataContext();

            IEnumerable<SalesOrderHeader> detalles = from sales in dc.SalesOrderHeaders where sales.CustomerID == pCustomerID select sales;

            return detalles;
        }


        /// <summary>
        /// Usa la clase en Sales.Datails.dbml
        /// Usa LinQ
        /// </summary>
        public static IEnumerable<DetailsView> BuscarDetallesIEnumerable(int pCustomerID)
        {
            SalesDataContext dc = new SalesDataContext();

            IEnumerable<DetailsView> detallesView = from sales in dc.SalesOrderDetails
                               where sales.SalesOrderHeader.CustomerID == pCustomerID
                               select (new DetailsView
                               {
                                   SalesOrderID = sales.SalesOrderID,
                                   ProductID = sales.ProductID,
                                   CarrierTrackingNumber = sales.CarrierTrackingNumber,
                                   OrderDate = sales.SalesOrderHeader.OrderDate
                               });

            
            return detallesView;
        }
        /// <summary>
        /// Usa la clase en Sales.Datails.dbml
        /// Usa LinQ
        /// </summary>
        public static IEnumerable<DetailsView> BuscarDetallesIEnumerableTodos(out int count)
        {
            SalesDataContext dc = new SalesDataContext();
            
            IEnumerable<DetailsView> detallesView = from sales in dc.SalesOrderDetails
                                                    
                                                    select (new DetailsView
                                                    {
                                                        SalesOrderID = sales.SalesOrderID,
                                                        ProductID = sales.ProductID,
                                                        CarrierTrackingNumber = sales.CarrierTrackingNumber,
                                                        OrderDate = sales.SalesOrderHeader.OrderDate
                                                    });


            
            count = detallesView.Count<DetailsView>();
            return detallesView;
        }
        /// <summary>
        /// Usa la clase en Sales.Datails.dbml
        /// Usa LinQ
        /// </summary>
        public static List<DetailsView> BuscarDetallesToList(int pCustomerID)
        {
            SalesDataContext dc = new SalesDataContext();

            var detallesView = from sales in dc.SalesOrderDetails
                                                    where sales.SalesOrderHeader.CustomerID == pCustomerID
                                                    select (new DetailsView
                                                    {
                                                        SalesOrderID = sales.SalesOrderID,
                                                        ProductID = sales.ProductID,
                                                        CarrierTrackingNumber = sales.CarrierTrackingNumber,
                                                        OrderDate = sales.SalesOrderHeader.OrderDate
                                                    });

            
            return detallesView.ToList<DetailsView>();
        }

    }

    public class DetailsView
    {
        public int ProductID{get;set;}
        public string CarrierTrackingNumber { get; set; }
        public int SalesOrderID { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
