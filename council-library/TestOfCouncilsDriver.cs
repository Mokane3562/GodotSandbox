using System.Data;
using System.Runtime.CompilerServices;

namespace Test_of_Councils
{
    public class TestOfCouncilsDriver
    {
        //A council of the player plus 5 people
        public static void run(){
            Council council = new Council(
                new string[] {
                    "Bob", 
                    "Mary", 
                    "Sue", 
                    "Jeff", 
                    "Kyle"
                }, 
                new Opinion[] {
                    Opinion.STRONGLY_OPPOSED, 
                    Opinion.NEUTRAL, 
                    Opinion.STRONGLY_AGREE, 
                    Opinion.AGREE, 
                    Opinion.NEUTRAL
                },
                new string[] {
                    "We cannnot allow this to happen in our town!",
                    "I don't really know; Bob and Sue both make good points.",
                    "If we don't do this what does that say about who we are?!",
                    "It's probably a good idea, but I don't know enough to argue with Bob.",
                    "Bob and Sue are too wound up about this in my opinion; and Bob's being kinda of an asshole. I wonder what Jeff thinks of all this?"
                }
            );
            council.InitRelationshipGraph(
                new string[] {
                    "Bob", 
                    "Mary", 
                    "Sue", 
                    "Jeff", 
                    "Kyle"
                }, 
                new string[] {
                    "Mary", "Sue", "Jeff", "Kyle",
                    "Bob", "Sue", "Jeff", "Kyle",
                    "Bob", "Mary", "Jeff", "Kyle",
                    "Bob", "Mary", "Sue", "Kyle",
                    "Bob", "Mary", "Sue", "Jeff"
                }, 
                new Opinion[] {
                    Opinion.AGREE,              Opinion.STRONGLY_OPPOSED,   Opinion.NEUTRAL,            Opinion.NEUTRAL,
                    Opinion.AGREE,              Opinion.AGREE,              Opinion.AGREE,              Opinion.NEUTRAL,
                    Opinion.STRONGLY_OPPOSED,   Opinion.NEUTRAL,            Opinion.NEUTRAL,            Opinion.NEUTRAL,
                    Opinion.AGREE,              Opinion.NEUTRAL,            Opinion.NEUTRAL,            Opinion.NEUTRAL,
                    Opinion.OPPOSED,            Opinion.NEUTRAL,            Opinion.NEUTRAL,            Opinion.AGREE
                }
            );

            Console.WriteLine("How will you vote?");
            Console.WriteLine("Options: \"Agree\", \"Neutral\", or \"Oppose\"");
            string? userInput = Console.ReadLine();
            while(userInput == null || !council.ValidVote(userInput)){
                Console.WriteLine("Invalid vote. Please choose one of the given options. Do not include the '\"' or the ',' characters");
                Console.WriteLine("Options: \"Agree\" or \"Oppose\"");
                userInput = Console.ReadLine();
            }
            Opinion playerOpinion = council.VoteFromString(userInput);

            Console.WriteLine("Who will you try to sway?");
            Console.WriteLine("Options: \"Bob\", \"Mary\", \"Sue\", \"Jeff\", \"Kyle\", and \"Nobody\"");
            userInput = Console.ReadLine();
            while(userInput == null || !council.ValidName(userInput)){
                Console.WriteLine("Invalid name. Please choose one of the given options. Do not include the '\"' or the ',' characters");
                Console.WriteLine("Options: \"Bob\", \"Mary\", \"Sue\", \"Jeff\", \"Kyle\", and \"Nobody\"");
                userInput = Console.ReadLine();
            }
            string nameOfSwayedPerson = userInput;

            bool playerSwayingAgree = true;
            if(!nameOfSwayedPerson.Equals("Nobody")){
                Console.WriteLine("How will you try to sway?");
                Console.WriteLine("Options: \"Agree\" or \"Oppose\"");
                userInput = Console.ReadLine();
                while(userInput == null || !council.ValidOpinion(userInput)){
                    Console.WriteLine("Invalid direction. Please choose one of the given options. Do not include the '\"' or the ',' characters");
                    Console.WriteLine("Options: \"Agree\" or \"Oppose\"");
                    userInput = Console.ReadLine();
                }
                playerSwayingAgree = userInput.Equals("Agree");
            }

            VoteResult result = council.SwayPerson(nameOfSwayedPerson, playerSwayingAgree)
                                       .Converse()
                                       .TallyVote(playerOpinion);

            if(result == VoteResult.TIE) {
                Console.WriteLine("This vote is a tie. The issue is tabled until next meeting");
            } else if(result == VoteResult.PASSED) {
                Console.WriteLine("This ayes have it!");
            } else {
                Console.WriteLine("This motion is stricken down!");
            }
            Console.WriteLine("Enter to exit");
            userInput = Console.ReadLine();
        }
    }
}