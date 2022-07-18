namespace _01_Bytebank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaGabriela = new ContaCorrente();
            contaGabriela.saldo = 300;

            ContaCorrente outraConta = new ContaCorrente();
            outraConta = contaGabriela;
            outraConta.saldo = 200;

            Console.WriteLine(contaGabriela.saldo); // 200
            contaGabriela.Sacar(500);
        }
    }
}