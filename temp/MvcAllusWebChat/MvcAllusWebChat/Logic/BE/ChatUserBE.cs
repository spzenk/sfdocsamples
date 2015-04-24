//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a allus Code Generator.
//     Runtime Version: 1.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
//</auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Fwk.Bases;

namespace WebChat.Common.BE
{
   
	[XmlRoot("ChatUserList"), SerializableAttribute]
    public class ChatUserList :Entities<ChatUserBE>
    {}
    
    [XmlInclude(typeof(ChatUserBE)), Serializable]
    public class ChatUserBE:Entity
    {
        #region [Private Members]
                   private System.Int32 _ChatUserId;

           private System.String _ChatUserPhone;

           private System.String _ChatUserName;

           private System.String _ChatUserEmail;

           private System.DateTime _ChatUserCreated;

           private System.DateTime? _ChatUserModifiedDate;


        #endregion
             
        #region [Properties]
        	#region [ChatUserId]
	public System.Int32 ChatUserId
	{
		get { return _ChatUserId; }
		set { _ChatUserId = value;}
	}
	#endregion


	#region [ChatUserPhone]
	public System.String ChatUserPhone
	{
		get { return _ChatUserPhone; }
		set { _ChatUserPhone = value;}
	}
	#endregion


	#region [ChatUserName]
	public System.String ChatUserName
	{
		get { return _ChatUserName; }
		set { _ChatUserName = value;}
	}
	#endregion


	#region [ChatUserEmail]
	public System.String ChatUserEmail
	{
		get { return _ChatUserEmail; }
		set { _ChatUserEmail = value;}
	}
	#endregion


	#region [ChatUserCreated]
	public System.DateTime ChatUserCreated
	{
		get { return _ChatUserCreated; }
		set { _ChatUserCreated = value;}
	}
	#endregion


	#region [ChatUserModifiedDate]
	public System.DateTime? ChatUserModifiedDate
	{
		get { return _ChatUserModifiedDate; }
		set { _ChatUserModifiedDate = value;}
	}
	#endregion



        #endregion
 
    }
    

}
         

   