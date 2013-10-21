// <copyright file="Template1.partial.cs" company="">
//  Copyright © . All Rights Reserved.
// </copyright>

namespace Fwk.T4Gen
{
    
    using System;
    using T4Toolbox;

    public partial class Template1
    {
        
        public System.Type _type;
        protected override void Validate()
        {
            this.Warning("Template properties have not been validated");
        }
    }
}
