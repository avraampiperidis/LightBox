﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Firedump
{
    using System;
    using System.Collections.Generic;

    public partial class schedule_save_locations
    {
        public long id { get; set; }
        public Nullable<long> schedule_id { get; set; }
        public Nullable<long> service_type { get; set; }
        public Nullable<long> backup_location_id { get; set; }

        public virtual backup_locations backup_locations { get; set; }
        public virtual schedules schedules { get; set; }
    }
}
