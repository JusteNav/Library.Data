using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Library.Data
{
    public enum GenreEnum
    {
        [XmlEnum("Fantasy")]
        Fantasy,
        [XmlEnum("ScienceFiction")]
        ScienceFiction,
        [XmlEnum("Mystery")]
        Mystery,
        [XmlEnum("Horror")]
        Horror,
        [XmlEnum("Romance")]
        Romance
    }
}
