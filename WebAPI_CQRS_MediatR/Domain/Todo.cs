namespace WebAPI_CQRS_MediatR.Domain
{
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
    }
}
