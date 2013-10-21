// <copyright file="Generator1.cs" company="">
//  Copyright © . All Rights Reserved.
// </copyright>

namespace Fwk.T4Gen
{
    using System;
    using T4Toolbox;

    public partial class Generator1 : Generator
    {
        protected override void RunCore()
        {

        }

        protected override void Validate()
        {
            this.Warning("Generator properties have not been validated");
        }
    }
}
