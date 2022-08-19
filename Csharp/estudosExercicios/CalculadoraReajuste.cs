namespace estudos
{
    public class CalculadoraReajuste
    {
        public float calcular(Reajuste reajuste, float salario)
        {
            if (salario < 1700)
            {
                salario = reajuste.calcular(salario + 300);
            }
            else
            {
                salario = reajuste.calcular(salario + 200);
            }
            return salario;
        }
    }
}
