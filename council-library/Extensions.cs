namespace Test_of_Councils
{
    public static class Extensions {
        public static int Vote(this Opinion opinion){
            var vote = 0;
            switch(opinion){
                case Opinion.STRONGLY_OPPOSED: 
                    vote = -1;
                    break;
                case Opinion.OPPOSED: 
                    vote = -1;
                    break;
                case Opinion.NEUTRAL: 
                    vote = 0;
                    break;
                case Opinion.AGREE: 
                    vote = 1;
                    break;
                case Opinion.STRONGLY_AGREE: 
                    vote = 1;
                    break;
            }
            return vote;
        }
        public static VoteResult ToVoteResult(this int vote){
            if(vote > 0){
                return VoteResult.PASSED;
            } else if (vote < 0) {
                return VoteResult.FAILS;
            } else {
                return VoteResult.TIE;
            }
        }
    }
}