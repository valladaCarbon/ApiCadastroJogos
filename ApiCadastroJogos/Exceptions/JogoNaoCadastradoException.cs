using System;

namespace ApiCadastroJogos.Exceptions
{
    public class JogoNaoCadastradoException : Exception
    {
        public JogoNaoCadastradoException() : base("Este Jogo nãp está Cadastrado") {}
            
    }
}