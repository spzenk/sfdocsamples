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
    /// Beer Inventory Callback Service Operations
    /// </summary>
    /// <remarks>
    /// The ServiceContract attribute is not explicitly required for the callback interface.
    /// 
    /// By specifying IBeerInventoryCallback as the CallbackContract in IBeerInventory, 
    /// an implicit ServiceContract attribute is applied to this interface.
    /// </remarks>
    public interface IBeerInventoryCallback
    {
        /// <summary>
        /// Notifies the client that a guest has joined the party
        /// </summary>
        /// <param name="guestName">Name of the guest</param>
        [OperationContract(IsOneWay = true)]
        void NotifyGuestJoinedParty(string guestName);

        /// <summary>
        /// Notifies the client that beer inventory has changed
        /// </summary>
        /// <param name="guestName">Name of the guest</param>
        /// <param name="numberOfBeers">Number of beers that were drank or brought</param>
        [OperationContract(IsOneWay = true)]
        void NotifyBeerInventoryChanged(string guestName, int numberOfBeers);

        /// <summary>
        /// Notifies the client that a guest has left the party
        /// </summary>
        /// <param name="guestName">Name of the guest</param>
        [OperationContract(IsOneWay = true)]
        void NotifyGuestLeftParty(string guestName);
    }
}
