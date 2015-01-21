using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Fwk.Bases;

namespace WebChat.Common.BE
{
   
	[XmlRoot("ChatMailSenderList"), SerializableAttribute]
    public class ChatMailSenderList :Entities<ChatMailSenderBE>
    {}

    [XmlInclude(typeof(ChatMailSenderBE)), Serializable]
    public class ChatMailSenderBE:Entity
    {
        #region [Private Members]
           private System.Int32 _ChatMailSenderId;

           private System.String _Email;

           private System.String _Password;

           private System.String _UserName;

           private System.String _SMTPServer;

           private System.Int32 _SMTPPort;

           private System.Boolean _EnableSSL;

           private System.Boolean _ActiveFlag;

           private System.DateTime _CreatedRow;

           private System.String _TagStartWith;
        
           private System.String _TagEndWith;

        #endregion
             
        #region [Properties]
        	#region [ChatMailSenderId]
	public System.Int32 ChatMailSenderId
	{
		get { return _ChatMailSenderId; }
		set { _ChatMailSenderId = value;}
	}
	#endregion


	#region [Email]
	public System.String Email
	{
		get { return _Email; }
		set { _Email = value;}
	}
	#endregion


	#region [Password]
	public System.String Password
	{
		get { return _Password; }
		set { _Password = value;}
	}
	#endregion


	#region [UserName]
	public System.String UserName
	{
		get { return _UserName; }
		set { _UserName = value;}
	}
	#endregion


	#region [SMTPServer]
	public System.String SMTPServer
	{
		get { return _SMTPServer; }
		set { _SMTPServer = value;}
	}
	#endregion


	#region [SMTPPort]
	public System.Int32 SMTPPort
	{
		get { return _SMTPPort; }
		set { _SMTPPort = value;}
	}
	#endregion


	#region [EnableSSL]
	public System.Boolean EnableSSL
	{
		get { return _EnableSSL; }
		set { _EnableSSL = value;}
	}
	#endregion


	#region [ActiveFlag]
	public System.Boolean ActiveFlag
	{
		get { return _ActiveFlag; }
		set { _ActiveFlag = value;}
	}
	#endregion


	#region [CreatedRow]
	public System.DateTime CreatedRow
	{
		get { return _CreatedRow; }
		set { _CreatedRow = value;}
	}
	#endregion


    #region [TagStartWith]
    public System.String TagStartWith
    {
        get { return _TagStartWith; }
        set { _TagStartWith = value; }
    }
    #endregion

    #region [TagEndWith]
    public System.String TagEndWith
    {
        get { return _TagEndWith; }
        set { _TagEndWith = value; }
    }
    #endregion
        #endregion
 
    }
    

}
         

   
