using System;
using System.Collections.Generic;

namespace summerschool.DMO;

public partial class TableTeacher
{
    public int Tchrid { get; set; }

    public string? Tchnamelastname { get; set; }

    public int? Tchrbranch { get; set; }

    public virtual TableLesson? TchrbranchNavigation { get; set; }
}
