// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable UnusedMember.Global
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Geco.Tests.Model
{
    [GeneratedCode("Geco", "1.0.3.0")]
    public partial class OrderTracking
    {
        // Key Properties
        public int OrderTrackingID { get; set; }

        // Scalar Properties
        public int SalesOrderID { get; set; }
        public string CarrierTrackingNumber { get; set; }
        public int TrackingEventID { get; set; }
        public string EventDetails { get; set; }
        public DateTime EventDateTime { get; set; }

    }
}