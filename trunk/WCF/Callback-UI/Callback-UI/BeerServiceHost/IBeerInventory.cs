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
using System.ServiceModel;

namespace JeffBarnes.WCF.Samples.CallbackDemo.Service
{
    // NOTE: The use of one way service operations allows the callback to occur while
    //       still using the single concurrency mode rather than Reentrant or Multiple.

    /// <summary>
    /// Beer Inventory Service Operations
    /// </summary>
    [ServiceContract(
        Name = "BeerInventoryService",
        Namespace = "http://jeffbarnes.net/wcf/samples/client_callback/BeerInventoryService/",
        SessionMode = SessionMode.Required,
        CallbackContract = typeof(IBeerInventoryCallback))]
    public interface IBeerInventory
    {
        /// <summary>
        /// Guest arrived at the party for the sole purpose of drinking beer
        /// </summary>
        /// <param name="name">Name of the guest</param>
        /// <return>Number of available beers</return>
        [OperationContract()]
        int JoinTheParty(string guestName);

        /// <summary>
        /// Someone graciously brought beer to the party
        /// </summary>
        /// <param name="numberOfBeers">Number of beers brought</param>
        [OperationContract(IsOneWay = true)]
        void MakeBeerRun(string guestName, int numberOfBeers);

        /// <summary>
        /// Someone drank a beer
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void DrinkBeer(string guestName);

        /// <summary>
        /// You don't have to go home, but you can't stay here
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void LeaveTheParty(string guestName);
    }
}
