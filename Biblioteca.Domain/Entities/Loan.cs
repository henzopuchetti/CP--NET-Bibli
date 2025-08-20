namespace Biblioteca.Domain.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Borrower { get; set; } = "";
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Book? Book { get; set; }
    }
}
