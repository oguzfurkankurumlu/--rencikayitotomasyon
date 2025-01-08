using System.Collections.Generic;
using summerschool.DMO;

public class DashboardViewModel
{
    public List<TableStudent> Students { get; set; }
    public List<TableLesson> Lessons { get; set; }
    public List<TableTeacher> Teachers { get; set; }
    public List<FormApply> FormApplies { get; set; }
}
