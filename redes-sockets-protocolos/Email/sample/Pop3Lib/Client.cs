/*
 * This is example for article: 
 * http://kbyte.ru/ru/Programming/Articles.aspx?id=65&mode=art
 * (only russian language)
 * Author: Aleksey S Nemiro
 * http://aleksey.nemiro.ru
 * http://kbyte.ru
 * August 27, 2011
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections;

namespace Pop3Lib
{
  public class Client
  {
    
    private Socket _Socket = null;
    private string _Host = String.Empty;
    private int _Port = 110;
    private string _UserName = String.Empty;
    private string _Password = String.Empty;

    private Result _ServerResponse = new Result();
    private int _Index = 0;

    public int MessageCount = 0;
    public int MessagesSize = 0;
    
    public Client(string host, string userName, string password) : this(host, 110, userName, password) { }
    public Client(string host, int port, string userName, string password)
    {
      // validation
      if (String.IsNullOrEmpty(host)) throw new Exception("Pop3-server is required.");
      if (String.IsNullOrEmpty(userName)) throw new Exception("User name is required.");
      if (String.IsNullOrEmpty(password)) throw new Exception("Password is required.");
      if (port <= 0) port = 110;
      // --

      this._Host = host;
      this._Password = password;
      this._Port = port;
      this._UserName = userName;


      this.Connect();
    }

    /// <summary>
    /// The method connects to the mail server
    /// </summary>
    public void Connect()
    {
      // get server IP
      IPHostEntry myIPHostEntry = Dns.GetHostEntry(_Host);

      if (myIPHostEntry == null || myIPHostEntry.AddressList == null || myIPHostEntry.AddressList.Length <= 0)
      {
        throw new Exception("IP adress not found.");
      }

      // get end pint by IP
      IPEndPoint myIPEndPoint = new IPEndPoint(myIPHostEntry.AddressList[0], _Port);

      // create socket
      _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
      _Socket.ReceiveBufferSize = 512; // 512 byte

      // connect
      WriteToLog("Connecting to server {0}:{1}", _Host, _Port);
      _Socket.Connect(myIPEndPoint);
      // receive a response
      ReadLine();

      // authorization
      Command(String.Format("USER {0}", _UserName));
      ReadLine();

      Command(String.Format("PASS {0}", _Password));
      _ServerResponse = ReadLine();
      // check on the errors
      if (_ServerResponse.IsError)
      {
        throw new Exception(_ServerResponse.ServerMessage);
      }

      // get stat
      Command("STAT");
      _ServerResponse = ReadLine();
      if (_ServerResponse.IsError)
      {
        throw new Exception(_ServerResponse.ServerMessage);
      }

      _ServerResponse.ParseStat(out this.MessageCount, out this.MessagesSize);
    }

    /// <summary>
    /// The method closed the connection to the mail server
    /// </summary>
    public void Close()
    {
      if (_Socket == null) { return; }
      Command("QUIT");
      ReadLine();
      _Socket.Close();
    }

    /// <summary>
    /// The function returns the headers of the said letter
    /// </summary>
    /// <param name="index">Letter index, start with 1</param>
    public Dictionary<string ,object> GetMailHeaders(int index)
    {
      if (index > this.MessageCount)
      {
        throw new Exception(String.Format("The index must be between 1 and {0}", this.MessageCount));
      }
      Command(String.Format("TOP {0} 0", index));
      _ServerResponse = ReadToEnd();
      if (_ServerResponse.IsError)
      {
        throw new Exception(_ServerResponse.ServerMessage);
      }
      MailItem m;
      _ServerResponse.ParseMail(out m);
      return m.Headers;
    }

    /// <summary>
    /// Next letter
    /// </summary>
    public bool NextMail(out MailItem m)
    {
      m = null;
      _Index++;
      if (_Index > this.MessageCount) return false;// no more letters
      Command(String.Format("RETR {0}", _Index));
      _ServerResponse = ReadToEnd();
      if (_ServerResponse.IsError)
      {
        throw new Exception(_ServerResponse.ServerMessage);
      }
      _ServerResponse.ParseMail(out m);
      return true;
    }

    /// <summary>
    /// Mark current letter for remove
    /// </summary>
    public void Delete()
    {
      Delete(_Index);
    }

    /// <summary>
    /// Mark letter for remove
    /// </summary>
    public void Delete(int index)
    {
      if (index > this.MessageCount)
      {
        throw new Exception(String.Format("The index must be between 1 and {0}", this.MessageCount));
      }
      Command(String.Format("DELE {0}", index));
      _ServerResponse = ReadLine();
      if (_ServerResponse.IsError)
      {
        throw new Exception(_ServerResponse.ServerMessage);
      }
    }

    /// <summary>
    /// The method sends a command to the mail server
    /// </summary>
    /// <param name="cmd">Команда</param>
    public void Command(string cmd)
    {
      if (_Socket == null) throw new Exception("No server connection. Please use the Connect method.");
      WriteToLog("Команда: {0}", cmd);// логирование
      byte[] b = System.Text.Encoding.ASCII.GetBytes(String.Format("{0}\r\n", cmd));
      if (_Socket.Send(b, b.Length, SocketFlags.None) != b.Length)
      {
        throw new Exception("Sorry, error...");
      }
    }

    /// <summary>
    /// Read first line on the server response
    /// </summary>
    public string ReadLine()
    {
      byte[] b = new byte[_Socket.ReceiveBufferSize];
      StringBuilder result = new StringBuilder(_Socket.ReceiveBufferSize);
      int s = 0;
      while (_Socket.Poll(1000000, SelectMode.SelectRead) && (s = _Socket.Receive(b, _Socket.ReceiveBufferSize, SocketFlags.None)) > 0)
      {
        result.Append(System.Text.Encoding.ASCII.GetChars(b, 0, s));
      }

      WriteToLog(result.ToString().TrimEnd("\r\n".ToCharArray()));// log

      return result.ToString().TrimEnd("\r\n".ToCharArray());
    }

    /// <summary>
    /// Read all server response
    /// </summary>
    public string ReadToEnd()
    {
      byte[] b = new byte[_Socket.ReceiveBufferSize];
      StringBuilder result = new StringBuilder(_Socket.ReceiveBufferSize);
      int s = 0;
      while (_Socket.Poll(1000000, SelectMode.SelectRead) && ((s = _Socket.Receive(b, _Socket.ReceiveBufferSize, SocketFlags.None)) > 0))
      {
        result.Append(System.Text.Encoding.ASCII.GetChars(b, 0, s));
      }

      // log
      if (result.Length > 0 && result.ToString().IndexOf("\r\n") != -1)
      {
        WriteToLog(result.ToString().Substring(0, result.ToString().IndexOf("\r\n")));
      }
      // --

      return result.ToString();
    }

    // log
    private void WriteToLog(string msg, params object[] args)
    {
      Console.WriteLine("{0}: {1}", DateTime.Now, String.Format(msg, args));
    }
  }
}
