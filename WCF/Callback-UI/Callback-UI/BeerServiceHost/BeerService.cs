//===============================================================================
// Jeff Barnes - 02/16/2007
// WCF Callback Sample
// http://blog.jeffbarnes.net
// http://jeffbarnes.net/portal/blogs/jeff_barnes/contact.aspx
//
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;

namespace JeffBarnes.WCF.Samples.CallbackDemo.Service
{
    /// <summary>
    /// Beer Service Implementation
    /// </summary>
    /// <remarks>
    /// Single is the default concurrency mode, but it never hurts to be explicit.
    /// Note the single threading model still functions properly with use of one way methods for callbacks 
    /// since they are marked as one way on the contract.
    /// </remarks>
    [ServiceBehavior(        ConcurrencyMode = ConcurrencyMode.Single,         InstanceContextMode = InstanceContextMode.PerCall)]
    public class BeerService : IBeerInventory
    {
        // NOTE: The variables for storing callbacks and beer inventory are static.
        //       This is necessary since the service is using PerCall instancing.
        //       An instance of the service will be created each time a service method is invoked by a client.
        //       Consequently, the state must be persisted somewhere in between calls.
        private static List<IBeerInventoryCallback> _callbackList = new List<IBeerInventoryCallback>();
        private static int _beerInventory = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["InitialBeerInventory"]);

        public BeerService() {}

        public int JoinTheParty(string guestName)
        {
            // Subscribe the guest to the beer inventory
            IBeerInventoryCallback guest = OperationContext.Current.GetCallbackChannel<IBeerInventoryCallback>();

            if (!_callbackList.Contains(guest))
            {
                _callbackList.Add(guest);
            }            

            _callbackList.ForEach(delegate(IBeerInventoryCallback callback)
                { callback.NotifyGuestJoinedParty(guestName); });

            return _beerInventory;
        }

        public void MakeBeerRun(string guestName, int numberOfBeers)
        {
            _beerInventory += numberOfBeers;

            // Notify the guests more beer has arrived
            // Use an anonymous delegate and generics to do our dirty work.
            _callbackList.ForEach(delegate(IBeerInventoryCallback callback)
                    { callback.NotifyBeerInventoryChanged(guestName, numberOfBeers); });
        }

        public void DrinkBeer(string guestName)
        {
            _beerInventory--;

            // Notify the guests beer has been consumed.
            // Use an anonymous delegate and generics to do our dirty work.
            _callbackList.ForEach(delegate(IBeerInventoryCallback callback)
            {
                callback.NotifyBeerInventoryChanged(guestName, -1);
            });
        }

        public void LeaveTheParty(string guestName)
        {
            // Unsubscribe the guest from the beer inventory
            IBeerInventoryCallback guest = OperationContext.Current.GetCallbackChannel<IBeerInventoryCallback>();

            if (_callbackList.Contains(guest))
            {
                _callbackList.Remove(guest);
            }

            // Notify everyone that guest has arrived.
            // Use an anonymous delegate and generics to do our dirty work.
            _callbackList.ForEach(delegate(IBeerInventoryCallback callback)
                    {
                        callback.NotifyGuestLeftParty(guestName);
                    });            
        }
    }
}
