using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{ 
public partial class TblPermission
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string License { get; set; }
}
}