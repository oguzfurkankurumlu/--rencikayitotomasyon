using System;
using System.Collections.Generic;

namespace summerschool.DMO;

public partial class TableLesson
{
    public int Lsid { get; set; }

    public string? Lsname { get; set; }

    public byte? Lsmaxquota { get; set; }

    public byte? Lsminquota { get; set; }

    public virtual ICollection<FormApply> FormApplies { get; set; } = new List<FormApply>();

    public virtual ICollection<TableTeacher> TableTeachers { get; set; } = new List<TableTeacher>();
}
