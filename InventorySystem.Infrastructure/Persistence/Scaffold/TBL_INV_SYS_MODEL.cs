using System;
using System.Collections.Generic;

namespace InventorySystem.Infrastructure.Persistence.Scaffold;

public partial class TBL_INV_SYS_MODEL
{
    public Guid ID { get; set; }

    public Guid CATEGORY_ID { get; set; }

    public Guid BRAND_ID { get; set; }

    public string MODELS_NAME { get; set; } = null!;

    public virtual TBL_INV_SYS_BRAND BRAND { get; set; } = null!;

    public virtual TBL_INV_SYS_CATEGORy CATEGORY { get; set; } = null!;

    public virtual ICollection<TBL_INV_SYS_PRODUCT> TBL_INV_SYS_PRODUCTs { get; set; } = new List<TBL_INV_SYS_PRODUCT>();
}
