using StreamingFlix.App;

// ============================================================
// StreamingFlix.App - Demonstração rápida do PlanoStreamingService
// (Os testes unitários parametrizados ficam no projeto StreamingFlix.Tests)
// ============================================================

PlanoStreamingService planoService = new PlanoStreamingService();

// Exemplo 1 (retorno string): classificação do plano por telas simultâneas
Console.WriteLine($"Plano com 1 tela:  {planoService.ObterClassificacaoPorQualidade(1)}");
Console.WriteLine($"Plano com 2 telas: {planoService.ObterClassificacaoPorQualidade(2)}");
Console.WriteLine($"Plano com 4 telas: {planoService.ObterClassificacaoPorQualidade(4)}");

// Exemplo 2 (retorno int): mensalidade com desconto por fidelidade
Console.WriteLine($"Mensalidade base 50, contrato de 1 mês:  {planoService.CalcularMensalidadeComDesconto(50, 1)} (sem desconto)");
Console.WriteLine($"Mensalidade base 50, contrato de 6 meses: {planoService.CalcularMensalidadeComDesconto(50, 6)} (10% de desconto)");
Console.WriteLine($"Mensalidade base 50, contrato de 12 meses: {planoService.CalcularMensalidadeComDesconto(50, 12)} (20% de desconto)");

// Exemplo 3 (retorno bool): acesso a conteúdo adulto
Console.WriteLine($"Acesso adulto (20 anos, controle parental desativado): {planoService.PodeAcessarConteudoAdulto(20, false)}");
Console.WriteLine($"Acesso adulto (20 anos, controle parental ativado):    {planoService.PodeAcessarConteudoAdulto(20, true)}");
Console.WriteLine($"Acesso adulto (16 anos, controle parental desativado): {planoService.PodeAcessarConteudoAdulto(16, false)}");
