using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern_RH
{
    public class Receiver
    {
        CommandCrear commandCrear;
        FormRH formRH;

        public void setCommand(CommandCrear commandCrear)
        {
            this.commandCrear = commandCrear;
        }

        public void enviarTicketRH(FormRH formRH)
        {
            this.formRH = formRH;
        }

        public void enviarEstatus(int tipo_ticket,string estatus)
        {
            if (tipo_ticket == 1)
                this.formRH.ActualizarTI(estatus);
            else if (tipo_ticket == 2)
                this.formRH.ActualizarTargeta(estatus);
        }

        public string execute()
        {
            return this.commandCrear.execute("en_espera");
        }
    }
}
