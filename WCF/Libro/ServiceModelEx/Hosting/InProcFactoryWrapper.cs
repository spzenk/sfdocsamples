// © 2008 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.ServiceModel;
using System.Diagnostics;
using ServiceModelEx;


public abstract class InProcFactoryWrapper<S,I> : IDisposable where I : class 
                                                              where S : class,I
{
   protected I Proxy
   {get;private set;}

   protected InProcFactoryWrapper()
   {
      Proxy = InProcFactory.CreateInstance<S,I>();
   }
   void IDisposable.Dispose()
   {
      InProcFactory.CloseProxy(Proxy);
   }
}