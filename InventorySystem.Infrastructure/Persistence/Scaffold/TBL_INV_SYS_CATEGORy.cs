
namespace InventorySystem.Infrastructure.Persistence.Scaffold;

public partial class TBL_INV_SYS_CATEGORy
{
    public Guid ID { get; set; }

    public string CATEGORY_NAME { get; set; } = null!;

    public virtual ICollection<TBL_INV_SYS_MODEL> TBL_INV_SYS_MODELs { get; set; } = new List<TBL_INV_SYS_MODEL>();
}
