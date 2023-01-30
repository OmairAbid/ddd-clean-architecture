using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.QueryEntities;
public partial class ConnectionProvider1
{
    public List<ConnectionProviderParameter> ConnectionProviderParameter { get; set; }
    public List<ConnectionProviderDetail> ConnectionProviderDetail { get; set; }
    public List<string> Purposes { get; set; }
}
