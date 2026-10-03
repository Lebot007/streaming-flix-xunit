using StreamingFlix.App;
using Xunit;

namespace StreamingFlix.Tests;

public class PlanoStreamingServiceTests
{
    private readonly PlanoStreamingService _service = new PlanoStreamingService();

    // Teste 1 (Classificacao de Planos)
    [Theory]
    [InlineData(1, "BÁSICO")]
    [InlineData(2, "PADRÃO")]
    [InlineData(4, "PREMIUM")]
    public void ObterClassificacaoPorQualidade_DeveRetornarClassificacaoCorreta(int telasSimultaneas, string classificacaoEsperada)
    {
        string resultado = _service.ObterClassificacaoPorQualidade(telasSimultaneas);
        Assert.Equal(classificacaoEsperada, resultado);
    }

    // Teste 2 (Calculo de Desconto)
    [Theory]
    [InlineData(50, 1, 50)]
    [InlineData(50, 6, 45)]
    [InlineData(50, 12, 40)]
    public void CalcularMensalidadeComDesconto_DeveRetornarValorFinalCorreto(int valorBase, int mesesContratados, int valorFinalEsperado)
    {
        int resultado = _service.CalcularMensalidadeComDesconto(valorBase, mesesContratados);
        Assert.Equal(valorFinalEsperado, resultado);
    }

    // Teste 3 (Validacao de Acesso)
    [Theory]
    [InlineData(20, false, true)]
    [InlineData(20, true, false)]
    [InlineData(16, false, false)]
    public void PodeAcessarConteudoAdulto_DeveValidarAcessoCorretamente(int idade, bool controleParentalAtivo, bool resultadoEsperado)
    {
        bool resultado = _service.PodeAcessarConteudoAdulto(idade, controleParentalAtivo);
        Assert.Equal(resultadoEsperado, resultado);
    }
}