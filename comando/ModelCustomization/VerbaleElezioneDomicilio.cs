using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comando 
{
    [MetadataType(typeof(VerbaleElezioneDomicilio))]
    public partial class VerbaleElezioneDomicilio : Comando.BaseVerbale
    {
    }

    [MetadataType(typeof(Trasgressore))]
    public partial class Trasgressore : comando.Attore
    {
    }

    [MetadataType(typeof(Proprietario))]
    public partial class Proprietario : comando.Trasgressore
    {
    }

}