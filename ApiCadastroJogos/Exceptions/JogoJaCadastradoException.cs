using System;

namespace ApiCadastroJogos.Exceptions
{
    public class JogoJaCadastradoException : Exception
    {
        public JogoJaCadastradoException() : base("Este Jogo Já está Cadastrado") {}
        
    }
}