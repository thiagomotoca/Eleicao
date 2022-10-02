namespace Eleicao;

public class Resultado
{
    public string Pst { get; set; }
    public Candidatos[] Cand { get; set; }
}

public class Candidatos
{
    public string Nm { get; set; }
    public string Vap { get; set; }
    public long NVap
    {
        get
        {
            return long.Parse(Vap);
        }
    }
    public string Pvap { get; set; }
    public double NPvap
    {
        get
        {
            return double.Parse(Pvap);
        }
    }
}