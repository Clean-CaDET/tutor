// blasphemy
// Predlog: da se enumeracija nalazi u API projektu
// Pros: validacija podataka, automatski se vraca 400 ako se ne prosledi validna vrednost enuma
// Cons: import dto u modelu fuj ahahaha
// Cons: UnitEnrollment ima obrnut pristup
using Tutor.LanguageModel.API.Dtos;

namespace Tutor.LanguageModel.Core.Domain;

public class Chat
{
    public int Id { get; private set; }
    public int LearnerId { get; private set; }
    // KC id
    public int ContextId { get; private set; }
    //public ContextType ContextType { get; private set; }
    public string Content { get; internal set; }
}
