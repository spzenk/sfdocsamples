using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;
using System.Timers;

using System.Data.Common;
using System.IO;
using System.Diagnostics;


namespace Performance_Timer_Tasks
{
    public  class Processor
    {
        Random random = new Random();
        
        public event IncidentHandler IncidentEvent;


        Timer _Timer;
        public int RefreshTime = 0;
        
        public int ProcessorId { get; set; }
        private void _Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _Timer.Stop();

            try
            {


                Task t = Task.Factory.StartNew(() => DoWork());
                //DoWork();
                

            }

           
            catch (Exception ex)
            {
                _Timer.Stop();
                this.Stop();
                return;
            }
            finally
            {
                _Timer.Start();
            }
        }

        private void DoWork()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i <= 5; i++)
            {
                insert(ProcessorId,i);
            }
            stopwatch.Stop();
            IncidentEvent(this.ProcessorId, stopwatch.ElapsedMilliseconds);
            
        }
        private void insert(int id,int i)
        {
            try
            {

                using (DataContext dc = new DataContext())
                {
                    Product p = new Product();
                    int randomNumber = random.Next(1, 503);
                    int pid = Engine.ProductIdList[randomNumber];
                    var p_bd = dc.Products.Where(t => t.ProductID.Equals(pid)).FirstOrDefault();


                    p.Name = string.Concat("BG-", id.ToString(), "i-", i.ToString(), "id-" + id).ToString();
                    p.ProductLine = p_bd.ProductLine;
                    p.ProductModelID = p_bd.ProductModelID                          ;
                    p.ProductNumber = string.Concat("BG-", id.ToString(),"i-",i.ToString(),"id-" + id).ToString();
                    p.ListPrice = p_bd.ListPrice;
                    p.ReorderPoint = Convert.ToInt16(i);
                    p.StandardCost = Convert.ToInt16(i);
                    p.StandardCost = Convert.ToDecimal(1.23 * id * i);
                    p.DaysToManufacture = i+1;
                    p.SellEndDate = null;
                    p.DiscontinuedDate = null;
                    p.SellStartDate = System.DateTime.Now;
                    p.ModifiedDate = System.DateTime.Now;
                    p.ProductSubcategoryID = p_bd.ProductSubcategoryID;
                    p.ReorderPoint = p_bd.ReorderPoint;
                    p.Style = p_bd.Style;
                    p.Size = p_bd.Size;
                    p.SizeUnitMeasureCode = p_bd.SizeUnitMeasureCode;
                    p.Weight = p_bd.Weight;
                    p.rowguid = Guid.NewGuid();
                    p.SafetyStockLevel = p_bd.SafetyStockLevel;
                    dc.Products.InsertOnSubmit(p);
                    
                    dc.SubmitChanges();
                }

            }
            catch (Exception ex)
            {
                _Timer.Stop();
                this.Stop();
                return;
            }
        }


        public virtual void Start()
        {
            if (this.RefreshTime > 0)
            {
                _Timer = new Timer(this.RefreshTime * 1000 );
                _Timer.Elapsed += new ElapsedEventHandler(_Timer_Elapsed);
                _Timer.Start();
            }
        }
        public virtual void Stop()
        {
            if (_Timer != null)
            {
                _Timer.Stop();
                _Timer.Elapsed -= new ElapsedEventHandler(_Timer_Elapsed);
                _Timer.Dispose();
            }
        }


    }

}
