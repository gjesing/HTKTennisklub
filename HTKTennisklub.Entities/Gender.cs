using System.ComponentModel;

namespace HTKTennisklub.Entities
{
    public enum Gender
    {
        [Description("Kvinde")]
        Female = 'f',
        [Description("Mand")]
        Male = 'm',
        [Description("Ukendt")]
        Unknown = 'u'
    }
}
