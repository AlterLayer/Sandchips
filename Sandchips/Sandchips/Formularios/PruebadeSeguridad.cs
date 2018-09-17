using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Sandchips.Formularios
{
    public partial class PruebadeSeguridad : Form
    {
        public PruebadeSeguridad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtcorreo.Text != "")
            {
                try
                {
                    var fromAddress = new MailAddress("sandchips.hotel.restaurant@gmail.com", "Sandchip's Hotel & Restaurant");
                    var toAddress = new MailAddress(txtcorreo.Text, "Usuario de prueba");
                    const string fromPassword = "sandchips2018";
                    const string subject = "Prueba de seguridad";
                    const string body = "La puerta de su habitación ha sido abierta, de haber sido usted hacer caso omiso a este mensaje.";
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }
                    MessageBox.Show("Correo enviado exitosamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
