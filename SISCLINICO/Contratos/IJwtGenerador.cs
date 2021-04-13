using SisClinico.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISCLINICO.Contratos
{
  public  interface IJwtGenerador
    {
        string CrearToken(Usuario usuario//, List<string> roles
//, List<string> listRoles
);
    }
}
