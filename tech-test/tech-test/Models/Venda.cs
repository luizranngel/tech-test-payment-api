namespace tech_test.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public int IdVendedor { get; set; }
        public DateTime Data { get; set; }
        public int IdPedido { get; set; }
        public EnumStatus Status { get; set; }
        public List<string> ItensVendidos { get; set; }
    }
}
