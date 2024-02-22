using System;
using System.Collections.Generic;

namespace PracticeDummy_WebClient.Models;

public partial class DummyMaster
{
    public int MasterId { get; set; }

    public string MasterName { get; set; } = null!;

    public virtual ICollection<DummyDetail> DummyDetails { get; set; } = new List<DummyDetail>();
}
