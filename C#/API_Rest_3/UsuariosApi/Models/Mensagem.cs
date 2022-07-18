using MimeKit;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UsuariosApi.Models
{
    public class Mensagem
    {
        public List<MailboxAddress> Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }

        public Mensagem(IEnumerable<string> destinatario, string assunto, int id, string codigo)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatario.Select(destinatarios => new MailboxAddress(destinatarios)));
            Assunto = assunto;
            Conteudo = $"http://localhost:6000/ativa?UsuarioId={id}&CodigoDeAtivacao={codigo}";
        }
    }
}
