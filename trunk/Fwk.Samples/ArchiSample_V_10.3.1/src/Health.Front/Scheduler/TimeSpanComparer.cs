using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Health.Back.BE;
using Health.Entities;
using Health.BE;
using Health.BE.Enums;

namespace Health.Front.Scheduler
{
    public class SchedulerHelper
    {

        internal static string  GetImageStatusKey(AppoimantsStatus_SP status )
        {
            //this.imageList2.Images.SetKeyName(0, "AppoimentStatus_Reserved.ICO");
            //this.imageList2.Images.SetKeyName(1, "AppoimentStatusWaiting.png");
            //this.imageList2.Images.SetKeyName(2, "AppoimentStatusInAttention.png");
            //this.imageList2.Images.SetKeyName(3, "AppoimentStatusClosed.png");
            //this.imageList2.Images.SetKeyName(4, "AppoimentStatusCanceled.png");
            //this.imageList2.Images.SetKeyName(5, "AppoimentStatus_FreeToUse.png");
            //this.imageList2.Images.SetKeyName(6, "AppoimentStatus_Expiro.png");
            switch (status)
            {
                case AppoimantsStatus_SP.Reservado:
                    return "AppoimentStatus_Reserved.ICO";
                case AppoimantsStatus_SP.EnEspera:
                    return "AppoimentStatusWaiting.png";

                case AppoimantsStatus_SP.EnAtencion:
                    return "AppoimentStatusInAttention.png";
                case AppoimantsStatus_SP.Cerrado:
                    return "AppoimentStatusClosed.png";

                case AppoimantsStatus_SP.Cancelado:
                    return "AppoimentStatusCanceled.png";
                    
                case AppoimantsStatus_SP.Expirado:
                    return "AppoimentStatus_Expiro.png";
            }
            return "AppoimentStatus_FreeToUse.png";
        }
    }

    /// <summary>
    /// Comparer para ordenar HH:MM:SS
    /// y mas grande -1
    /// x mas grande 1
    /// </summary>
    public class TimeSpanComparer : IComparer<TimespamView>
    {
        public int Compare(TimespamView x, TimespamView y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                  
                    //return x.Time.CompareTo(y.Time);
                    int retval = x.Time.CompareTo(y.Time);
                    if (retval == 0)
                    {
                        if (x.Appointment != null)
                        {
                            if (x.IsExceptional && !y.IsExceptional)

                                return 0;
                            if (!x.IsExceptional && y.IsExceptional)
                                return 1;
                        }
                    }

                    return retval;
                    //if (retval != 0)
                    //{
                    //    // If the strings are not of equal length,
                    //    // the longer string is greater.
                    //    //
                    //    return retval;
                    //}
                    //else
                    //{
                    //    // If the strings are of equal length,
                    //    // sort them with ordinary string comparison.
                    //    //
                    //    return x.Time.CompareTo(y.Time);
                    //}
                }
            }
        }
    }
}
