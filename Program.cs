using System.Net.Http.Json;
using System.Text.Json;
using Eleicao;

var jsonOptions = new JsonSerializerOptions()
{
    PropertyNameCaseInsensitive = true
};

using var httpClient = new HttpClient();

while (true)
{
    var result = await httpClient.GetFromJsonAsync<Resultado>("https://resultados.tse.jus.br/oficial/ele2022/544/dados-simplificados/br/br-c0001-e000544-r.json");

    Console.WriteLine($"{result.Pst} das seções totalizadas\n");

    foreach (var candidato in result.Cand)
    {
        Console.WriteLine($"Candidato: {candidato.Nm} Votos: {candidato.NVap:n0} Percentual: {candidato.Pvap}% \n");
    }

    Console.WriteLine(
        $"Diferença entre {result.Cand[0].Nm} e {result.Cand[1].Nm}: {(result.Cand[0].NVap - result.Cand[1].NVap):n0} ({(result.Cand[0].NPvap - result.Cand[1].NPvap):0.00}%) \n");

    await Task.Delay(60000);
}