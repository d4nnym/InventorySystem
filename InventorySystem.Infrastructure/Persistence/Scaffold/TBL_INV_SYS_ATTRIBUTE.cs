using System;
using System.Collections.Generic;

namespace InventorySystem.Infrastructure.Persistence.Scaffold;

public partial class TBL_INV_SYS_ATTRIBUTE
{
    public Guid ID { get; set; }

    public string ATRIBUTE_NAME { get; set; } = null!;

    public virtual ICollection<TBL_INV_SYS_ATTRIBUTE_VALUE> TBL_INV_SYS_ATTRIBUTE_VALUEs { get; set; } = new List<TBL_INV_SYS_ATTRIBUTE_VALUE>();
}
