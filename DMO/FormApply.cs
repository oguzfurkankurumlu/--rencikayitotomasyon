using System;
using System.Collections.Generic;

namespace summerschool.DMO;

public partial class FormApply
{
    public int Formid { get; set; }

    public int? Stid { get; set; }

    public int? Lsid { get; set; }

    public virtual TableLesson? Ls { get; set; }

    public virtual TableStudent? St { get; set; }
}
