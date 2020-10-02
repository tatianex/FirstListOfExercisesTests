using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace entra21_tests
{
    public class ElectionTest
    {
        [Fact] // Test for incorrect password ok
        public void should_not_create_candidates_when_password_is_incorrect()
        {
            // Dado / Setup
            var election = new Election();
            var candidates = new List<Candidate>() { new Candidate("José", "879.458.217-53") };

            // Quando / Ação
            var created = election.CreateCandidates(candidates, "incorrect");

            // Deve / Asserções
            Assert.Null(election.Candidates);
            Assert.False(created);
        }

        [Fact] // Test for correct password ok
        public void should_create_candidates_when_password_is_correct()
        {
            // Dado / Setup

            // OBJETO election
            var election = new Election();
            var candidates = new List<Candidate>() { 
                new Candidate("José", "879.458.217-53") 
            };

            // Quando / Ação

            // Estamos acessando o MÉTODO CreateCandidates do OBJETO election
            var created = election.CreateCandidates(candidates, "Pa$$w0rd");

            // Deve / Asserções
            Assert.True(created);
            
            // Estamos acessando a PROPRIEDADE Candidates, que faz parte do ESTADO do OBJETO election
            Assert.True(election.Candidates.Count == 1);
            Assert.True(election.Candidates.ElementAt(0).Name == candidates.ElementAt(0).Name);
        }

        [Fact] // Test for ids ok
        public void should_not_generate_same_id_for_both_candidates()
        {
            // Dado / Setup

            // OBJETO election
            var election = new Election();

            var jose = new Candidate("José", "879.458.217-53");
            var ana = new Candidate("Ana", "678.951.374-55");

            var candidates = new List<Candidate>() { jose, ana };

            election.CreateCandidates(candidates, "Pa$$w0rd");
            
            // Quando / Ação
            var candidateJose = election.GetCandidateIdByName(jose.Name);
            var candidateAna = election.GetCandidateIdByName(ana.Name);

            // Deve / Asserções
            Assert.NotEqual(candidateAna, candidateJose);
        }

        [Fact] // Test for vote ok
        public void should_vote_twice_in_candidate_Fernando()
        {
            // Dado / Setup
            // OBJETO election

            var election = new Election();
            var fernando = new Candidate("Fernando", "954.786.234-96");
            var ana = new Candidate("Ana", "678.951.374-55");
            
            var candidates = new List<Candidate>() { fernando, ana };
            election.CreateCandidates(candidates, "Pa$$w0rd");

            var fernandoId = election.GetCandidateIdByName(fernando.Name);
            var anaId = election.GetCandidateIdByName(ana.Name);

            // Quando / Ação
            fernando.Vote();
            fernando.Vote();

            // Deve / Asserções
            // First é um método que busca a PRIMEIRA e somente a 1ª ocorrência
            var candidateFernando = election.Candidates.First(x => x.Id == fernandoId);
            var candidateAna = election.Candidates.First(x => x.Id == anaId);
            Assert.Equal(2, candidateFernando.Votes);
            Assert.Equal(0, candidateAna.Votes);
        }

        [Fact] // Test for other votes ok
        public void should_return_Ana_as_winner_when_only_Ana_receives_votes()
        {
            // Dado / Setup
            // OBJETO election

            var election = new Election();
            var fernando = new Candidate("Fernando", "954.786.234-96");
            var ana = new Candidate("Ana", "678.951.374-55");

            var candidates = new List<Candidate>() { fernando, ana };
            election.CreateCandidates(candidates, "Pa$$w0rd");
            
            // Quando / Ação
            // Estamos acessando o MÉTODO ShowMenu do OBJETO election
            ana.Vote();
            ana.Vote();

            var winners = election.GetWinners();

            // Deve / Asserções
            Assert.True(winners.Count == 1);
            Assert.Equal(ana.Id, winners[0].Id);
            Assert.Equal(2, winners[0].Votes);
        }

        [Fact] // Test for draw ok
        public void should_return_both_candidates_when_occurs_draw()
        {
            // Dado / Setup
            // OBJETO election
            var election = new Election();
            var fernando = new Candidate("Fernando", "954.786.234-96");
            var ana = new Candidate("Ana", "678.951.374-55");

            var candidates = new List<Candidate>() { fernando, ana };
            election.CreateCandidates(candidates, "Pa$$w0rd");
            
            // Quando / Ação
            // Estamos acessando o MÉTODO ShowMenu do OBJETO election

            fernando.Vote();
            ana.Vote();
            var winners = election.GetWinners();

            // Deve / Asserções
           
            Assert.Equal(1, fernando.Votes);
            Assert.Equal(1, ana.Votes);
        }
    
        [Fact] // Test for cpf search ok
        public void should_return_the_id_of_candidate_when_researched_by_cpf()
        {
            var election = new Election();

            var ana1 = new Candidate("Ana", "765.859.452-46");
            var ana2 = new Candidate("Ana", "678.951.374-55");
            var ana3 = new Candidate("Ana", "597.841.198-35");
            
            var candidates = new List<Candidate>() { ana1, ana2, ana3 };
            election.CreateCandidates(candidates, "Pa$$w0rd");

            var IdFound = election.GetCandidateIdByCPF(ana1.Cpf);

            Assert.Equal(ana1.Id, IdFound);
             
        }

        [Fact] // Test for list of people with same name
        public void should_return_a_list_of_candidates_with_same_name()
        {
            var election = new Election();

            var Ana1 = new Candidate("Ana", "765.859.452-46");
            var Thiago = new Candidate("Thiago", "764.859.451-45");
            var Ana2 = new Candidate("Ana", "678.951.374-55");
            var Paula = new Candidate("Paula", "731.859.452-43");
            var Ana3 = new Candidate("Ana", "597.841.198-35");
            var Jose = new Candidate("Maria", "577.842.198-25");
            
            var candidates = new List<Candidate> {Ana1, Ana2, Ana3, Thiago, Paula, Jose};
            election.CreateCandidates(candidates, "Pa$$w0rd");

            var namesFound = election.GetCandidatesByName("Ana");

            for (int i = 0; i < namesFound.Count; i++)
            {
                Assert.Equal("Ana", namesFound[i].Name);
            }

            Assert.Equal(3, namesFound.Count);                       
        }
    }
}