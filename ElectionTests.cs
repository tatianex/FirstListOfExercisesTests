using System.Collections.Generic;
using Xunit;

namespace entra21_tests
{
    public class ElectionTest
    {
        [Fact]
        public void should_not_create_candidates_when_password_is_incorrect()
        {
            // Dado / Setup
            var election = new Election();
            var candidates = new List<(string, string) > {("José", "879.458.217-53")};

            // Quando / Ação
            var created = election.CreateCandidates(candidates, "incorrect");

            // Deve / Asserções
            Assert.Null(election.Candidates);
            Assert.False(created);
        }

        [Fact]
        public void should_create_candidates_when_password_is_correct()
        {
            // Dado / Setup

            // OBJETO election
            var election = new Election();
            (string name, string cpf) candidate = ("José", "879.458.217-53");
            var candidates = new List<(string name, string cpf) > {candidate};

            // Quando / Ação

            // Estamos acessando o MÉTODO CreateCandidates do OBJETO election
            var created = election.CreateCandidates(candidates, "Pa$$w0rd");

            // Deve / Asserções
            Assert.True(created);
            
            // Estamos acessando a PROPRIEDADE Candidates, que faz parte do ESTADO do OBJETO election
            Assert.True(election.Candidates.Count == 1);
            Assert.True(election.Candidates[0].name == candidate.name);
        }

        [Fact]
        public void should_not_generate_same_id_for_both_candidates()
        {
            // Dado / Setup

            // OBJETO election
            var election = new Election();
            (string name, string cpf) Jose = ("José", "879.458.217-53");
            (string name, string cpf) Ana = ("Ana", "678.951.374-55");
            var candidates = new List<(string, string) > {Jose, Ana};
            election.CreateCandidates(candidates, "Pa$$w0rd");
            
            // Quando / Ação
            var candidateJose = election.GetCandidateIdByName(Jose.name);
            var candidateAna = election.GetCandidateIdByName(Ana.name);

            // Deve / Asserções
            Assert.NotEqual(candidateAna, candidateJose);
        }

        [Fact]
        public void should_vote_twice_in_candidate_Fernando()
        {
            // Dado / Setup
            // OBJETO election
            var election = new Election();
            (string name, string cpf) Fernando = ("Fernando", "954.786.234-96");
            (string name, string cpf) Ana = ("Ana", "678.951.374-55");
            var candidates = new List<(string, string) > {Fernando, Ana};
            election.CreateCandidates(candidates, "Pa$$w0rd");
            var fernandoId = election.GetCandidateIdByName(Fernando.cpf);
            var anaId = election.GetCandidateIdByName(Ana.cpf);

            // Quando / Ação
            // Estamos acessando o MÉTODO ShowMenu do OBJETO election
            election.Vote(fernandoId);
            election.Vote(fernandoId);

            // Deve / Asserções
            var candidateFernando = election.Candidates.Find(x => x.id == fernando.id);
            var candidateAna = election.Candidates.Find(x => x.id == anaId);
            Assert.Equal(2, candidateFernando.votes);
            Assert.Equal(0, candidateAna.votes);
        }

        [Fact]
        public void should_return_Ana_as_winner_when_only_Ana_receives_votes()
        {
            // Dado / Setup
            // OBJETO election
            var election = new Election();
            (string name, string cpf) Fernando = ("Fernando", "954.786.234-96");
            (string name, string cpf) Ana = ("Ana", "678.951.374-55");
            var candidates = new List<(string, string) > {Fernando, Ana};
            election.CreateCandidates(candidates, "Pa$$w0rd");
            var anaId = election.GetCandidateIdByName(Ana.name);
            
            // Quando / Ação
            // Estamos acessando o MÉTODO ShowMenu do OBJETO election
            election.Vote(anaId);
            election.Vote(anaId);
            var winners = election.GetWinners();

            // Deve / Asserções
            Assert.True(winners.Count == 1);
            Assert.Equal(anaId, winners[0].id);
            Assert.Equal(2, winners[0].votes);
        }

        [Fact]
        public void should_return_both_candidates_when_occurs_draw()
        {
            // Dado / Setup
            // OBJETO election
            var election = new Election();
            (string name, string cpf) Fernando = ("Fernando", "954.786.234-96");
            (string name, string cpf) Ana = ("Ana", "678.951.374-55");
            var candidates = new List<(string, string) > {Fernando, Ana};
            election.CreateCandidates(candidates, "Pa$$w0rd");
            var fernandoId = election.GetCandidateIdByName(Fernando.name);
            var anaId = election.GetCandidateIdByName(Ana.name);
            
            // Quando / Ação
            // Estamos acessando o MÉTODO ShowMenu do OBJETO election
            election.Vote(anaId);
            election.Vote(fernandoId);
            var winners = election.GetWinners();

            // Deve / Asserções
            var candidateFernando = winners.Find(x => x.id == fernandoId);
            var candidateAna = winners.Find(x => x.id == anaId);
            Assert.Equal(1, candidateFernando.votes);
            Assert.Equal(1, candidateAna.votes);
        }
    
        [Fact]
        public void should_return_a_list_of_candidates_with_same_name()
        {
            var election = new Election();
            (string name, string cpf) Ana1 = ("Ana", "765.859.452-46");
            (string name, string cpf) Ana2 = ("Ana", "678.951.374-55");
            (string name, string cpf) Ana3 = ("Ana", "597.841.198-35");
            
            var candidates = new List<(string name, string cpf) > {Ana1, Ana2, Ana3};
            election.CreateCandidates(candidates, "Pa$$w0rd");

            var IdFound = election.GetCandidateIdByCPF(Ana1.cpf);

            Assert.Equal(election.Candidates[0].id, IdFound);
             
        }
    }
}