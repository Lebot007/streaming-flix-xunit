namespace StreamingFlix.App;

/// <summary>
/// Serviço responsável pelas regras de negócio do StreamingFlix:
/// classificação do plano por quantidade de telas simultâneas, cálculo da
/// mensalidade com desconto por fidelidade e validação de acesso ao
/// conteúdo adulto.
/// </summary>
public class PlanoStreamingService
{
    /// <summary>
    /// (Retorno string) Classifica o plano conforme o número de telas
    /// simultâneas contratadas:
    /// "BÁSICO" para 1 tela, "PADRÃO" para 2 telas e "PREMIUM" para 4 ou mais.
    /// Observação: a lista não define o caso de 3 telas; por continuidade da
    /// regra, 3 telas também é classificado como "PADRÃO".
    /// </summary>
    /// <param name="telasSimultaneas">Quantidade de telas simultâneas do plano.</param>
    /// <returns>
    /// Nome da classificação do plano em maiúsculas.
    /// Exemplos: 1 retorna "BÁSICO"; 2 retorna "PADRÃO"; 4 retorna "PREMIUM".
    /// </returns>
    public string ObterClassificacaoPorQualidade(int telasSimultaneas)
    {
        if (telasSimultaneas <= 1)
        {
            return "BÁSICO";
        }

        if (telasSimultaneas <= 3)
        {
            return "PADRÃO";
        }

        return "PREMIUM";
    }

    /// <summary>
    /// (Retorno int) Calcula o valor final da mensalidade aplicando o
    /// desconto por fidelidade:
    /// 10% de desconto para contratos de 6 a 11 meses e 20% para 12 meses
    /// ou mais. Abaixo de 6 meses não há desconto.
    /// </summary>
    /// <param name="valorBase">Valor original da mensalidade em reais.</param>
    /// <param name="mesesContratados">Duração do contrato em meses.</param>
    /// <returns>
    /// Valor final da mensalidade após o desconto.
    /// Exemplos: (50, 1) retorna 50; (50, 6) retorna 45; (50, 12) retorna 40.
    /// </returns>
    public int CalcularMensalidadeComDesconto(int valorBase, int mesesContratados)
    {
        int percentualDesconto = 0;

        if (mesesContratados >= 12)
        {
            percentualDesconto = 20;
        }
        else if (mesesContratados >= 6)
        {
            percentualDesconto = 10;
        }

        int valorDoDesconto = (valorBase * percentualDesconto) / 100;
        return valorBase - valorDoDesconto;
    }

    /// <summary>
    /// (Retorno bool) Verifica se o usuário pode acessar conteúdo adulto.
    /// Regra: retorna true apenas se a idade for igual ou maior que 18 E o
    /// controle parental estiver desativado (false).
    /// </summary>
    /// <param name="idade">Idade do usuário em anos.</param>
    /// <param name="controleParentalAtivo">Indica se o controle parental está ativo.</param>
    /// <returns>
    /// true somente quando maior de idade e sem controle parental.
    /// Exemplos: (20, false) retorna true; (20, true) retorna false; (16, false) retorna false.
    /// </returns>
    public bool PodeAcessarConteudoAdulto(int idade, bool controleParentalAtivo)
    {
        return idade >= 18 && !controleParentalAtivo;
    }
}
