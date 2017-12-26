using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Comando 
{
    [MetadataType(typeof(VerbaleElezioneDomicilio))]
    public partial class VerbaleElezioneDomicilio : Comando.BaseVerbale
    {
    }

    [MetadataType(typeof(Trasgressore))]
    public partial class Trasgressore : Comando.Attore
    {
    }

    [MetadataType(typeof(Proprietario))]
    public partial class Proprietario : Comando.Trasgressore
    {
    }

}