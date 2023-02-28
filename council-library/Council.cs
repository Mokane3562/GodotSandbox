using System;
using System.Linq;
namespace Test_of_Councils
{
    class Person {
        public readonly string name;
        public Opinion opinion;
        public string thought;
        public Person(string name, Opinion opinion, string thought){
            this.name = name;
            this.opinion = opinion;
            this.thought = thought;
        }

        public void SwayOpposed(){
            switch(this.opinion){
                case Opinion.OPPOSED:
                    this.opinion = Opinion.STRONGLY_OPPOSED;
                    break;
                case Opinion.NEUTRAL:
                    this.opinion = Opinion.OPPOSED;
                    break;
                case Opinion.AGREE:
                    this.opinion = Opinion.NEUTRAL;
                    break;
                case Opinion.STRONGLY_AGREE:
                    this.opinion = Opinion.AGREE;
                    break;
            }
        }

        public void SwayAgree(){
            switch(this.opinion){
                case Opinion.STRONGLY_OPPOSED:
                    this.opinion = Opinion.OPPOSED;
                    break;
                case Opinion.OPPOSED:
                    this.opinion = Opinion.NEUTRAL;
                    break;
                case Opinion.NEUTRAL:
                    this.opinion = Opinion.AGREE;
                    break;
                case Opinion.AGREE:
                    this.opinion = Opinion.STRONGLY_AGREE;
                    break;
            }
        }
        public static readonly Person nobody = new Person("", Opinion.NEUTRAL, "");

        public bool isNobody(){
            return this == Person.nobody;
        }
    }

    class Relationship {
        public readonly Opinion opinion;
        public readonly Person source;
        public readonly Person destination;

        public Relationship(Person source, Person destination, Opinion opinion){
            this.source = source;
            this.destination = destination;
            this.opinion = opinion;
        }

        public bool swaysOppose(){
            return ((destination.opinion == Opinion.STRONGLY_OPPOSED && opinion >= Opinion.AGREE) ||           //Src likes Dest and Dest Strongly Opposes
                    (destination.opinion == Opinion.STRONGLY_AGREE   && opinion == Opinion.STRONGLY_OPPOSED)); //Src Hates Dest and Dest Strongly Agrees
        }

        public bool swaysAgree(){
            return ((destination.opinion == Opinion.STRONGLY_AGREE   && opinion >= Opinion.AGREE) ||           //Src likes Dest and Dest Strongly Agrees
                    (destination.opinion == Opinion.STRONGLY_OPPOSED && opinion == Opinion.STRONGLY_OPPOSED)); //Src Hates Dest and Dest Strongly Opposes
        }
    }

    public class Council {

        private Person[] councilMembers;
        private Relationship[] relationShips;

        public Council(string[] names, Opinion[] opinions, string[] thoughts){
            councilMembers = names.Zip(opinions, thoughts)
                                  .Select(tuple => new Person(tuple.First, tuple.Second, tuple.Third))
                                  .ToArray();
            relationShips = new Relationship[names.Length * (names.Length - 1)];
        }

        public bool ValidName(string name){
            var person = GetPersonByName(councilMembers, name);
            if (person.isNobody() && !name.Equals("Nobody")){
                return false;
            }
            return true;
        }

        public bool ValidOpinion(string opinion) {
            return opinion.Equals("Agree") || opinion.Equals("Oppose");
        }

        public bool ValidVote(string opinion) {
            return opinion.Equals("Agree") || opinion.Equals("Oppose") || opinion.Equals("Neutral");
        }

        public Opinion VoteFromString(string opinion){
            return (opinion.Equals("Agree")   ?  Opinion.AGREE    : 
                   (opinion.Equals("Oppose")  ?  Opinion.OPPOSED  :
                  /*opinion.Equals("Neutral") ?*/Opinion.NEUTRAL));
        }

        public Council InitRelationshipGraph(string[] sources, string[] destinations, Opinion[] feelings){
            /*  |   0    |   1    |   2    | ... | <- n-1 entries per row
             *  |  n-1   |   n    |  n+1   | ... |
             *  | 2(n-1) |  2(n)  | 2(n+1) | ... |
             *  ...
             *  |n-1(n-1)| n-1(n) |n-1(n+1)| ... | <- n rows
             */
            int n = sources.Length;
            for (int i = 0; i<n; i++) {
                for (int j = i*(n-1); j<((i+1)*(n-1)); j++){
                    relationShips[j] = new Relationship(
                        this.GetPersonByName(councilMembers, sources[i]), 
                        this.GetPersonByName(councilMembers, destinations[j]), 
                        feelings[j]
                    );
                }
            }
            return this;
        }

        Func<Person[], string, Person> GetPersonByName = (councilMembers, name) => {
            foreach (Person person in councilMembers) {
                if (person.name.Equals(name)) return person;
            }
            return Person.nobody;
        };


        public VoteResult TallyVote(Opinion playerOpinion){
            return councilMembers.Select(member => member.opinion.Vote())
                                 .Append(playerOpinion.Vote())
                                 .Aggregate((tally, next) => tally + next)
                                 .ToVoteResult();
        }
        
        public Council Converse(){
            //get all people who are being swayed in opposition
            var swayedOpposed = relationShips.Where(relationship => relationship.swaysOppose())
                                             .Select(relationship => relationship.source)
                                             .Distinct()
                                             .ToArray();
            //and all people being swayed to agree
            var swayedAgree = relationShips.Where(relationship => relationship.swaysAgree())
                                           .Select(relationship => relationship.source)
                                           .Distinct()
                                           .ToArray();
            //and find all those who are being swayed in both directions
            var unswayed = swayedOpposed.Intersect(swayedAgree);
            //remove unswayed people from the previous lists
            swayedOpposed = swayedOpposed.Where(person => !unswayed.Contains(person))
                                         .ToArray();
            swayedAgree = swayedAgree.Where(person => !unswayed.Contains(person))
                                     .ToArray();
            //apply the sway to their opinion
            foreach(Person p in swayedOpposed) { p.SwayOpposed(); }
            foreach(Person p in swayedAgree) { p.SwayAgree(); }
            return this;
        }

        public Council SwayPerson(String name, bool agree){
            if(agree) {
                this.GetPersonByName(councilMembers, name).SwayAgree();
            } else {
                this.GetPersonByName(councilMembers, name).SwayOpposed();
            }
            return this;
        }

    }
}