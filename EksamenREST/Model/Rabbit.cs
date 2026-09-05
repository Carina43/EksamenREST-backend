namespace EksamenREST.Model
{
    public class Rabbit
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public double? Weight { get; set; }
        public int? MotherId { get; set; }

        public override string ToString()
        {
            return $"Kanin Id: {Id}, Navn: {Name}, Farve: {Color}, Vægt: {Weight}, Mors id: {MotherId}";
        }


    }
}
