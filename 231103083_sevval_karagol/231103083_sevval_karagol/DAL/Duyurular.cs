using System;
using System.Collections.Generic;

namespace _231103083_sevval_karagol.DAL;

public partial class Duyurular
{
    public int Id { get; set; }

    public string? Baslik { get; set; }

    public DateTime? Tarih { get; set; }

    public string? Aciklama { get; set; }
}
