using System;

namespace entra21_tests
{
    public class Candidate
    {
        public Guid Id{ get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public int Votes { get; set; }

        // CONSTRUTOR DA CLASSE CANDIDATE
        public Candidate(string name, string cpf)
        {
            Id = Guid.NewGuid();
            Name = name;
            Cpf = cpf;
            Votes = 0;
        }

    }
}
