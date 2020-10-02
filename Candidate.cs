using System;

namespace entra21_tests
{
    public class Candidate
    {
        public Guid Id{ get; private set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public int Votes { get; set; }

        // CONSTRUTOR DA CLASSE CANDIDATE
        public Candidate(string name, string cpf)
        {
            Id = Guid.NewGuid();
            this.Name = name;
            this.Cpf = cpf;
            this.Votes = 0;
        }

        public void Vote()
        {
            Votes++;
        }
    }
}
