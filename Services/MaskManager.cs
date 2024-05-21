namespace Sistema_de_lojista.Services
{
    public class MaskManager
    {
        public static string RemoverMascara(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                return string.Empty;
            }

            return new string(valor.Where(char.IsDigit).ToArray());
        }

    }
}
