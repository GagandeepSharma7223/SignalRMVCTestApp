
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApplication.Repository
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}