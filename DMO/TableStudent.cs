using System;
using System.Collections.Generic;

namespace summerschool.DMO;

public partial class TableStudent
{
    public int Stid { get; set; }

    public string? Stname { get; set; }

    public string? Stlastname { get; set; }

    public string? Stnumber { get; set; }

    public string? Stmail { get; set; }

    public string? Stpassword { get; set; }

    public decimal? Stbalance { get; set; }

    public virtual ICollection<FormApply> FormApplies { get; set; } = new List<FormApply>();
}
