namespace DigiBank.Classses
{
    public class ContaCorrente : Conta
    {
        public ContaCorrente()
        {
            this.NumeroConta = "00" + Conta.NumeroDaContaSequencial;
        }
    }
}
