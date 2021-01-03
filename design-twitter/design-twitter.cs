    public void PostTweet(int userId, int tweetId) {
        if(!tweets.ContainsKey(userId))
        {
            tweets.Add(userId,new LinkedList<Tweet>());
        }
        tweets[userId].AddFirst(new Tweet(tweetId,time++));
        Follow(userId,userId);
        
    }
    
    /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
    public IList<int> GetNewsFeed(int userId) {
        IList<int> res = new List<int>(10);
            sortedSet.Clear();
        
        if(!followed.ContainsKey(userId))
        {
            return res;
        }
        
         var followees = followed[userId];
        foreach(var id in followees)
        {
            if(tweets.ContainsKey(id))
            {
                sortedSet.Add(tweets[id].First);
            }
        }
        
        while(res.Count!=10 && sortedSet.Count>0)
        {
            var first = sortedSet.First();
            sortedSet.Remove(first);
            res.Add(first.Value.tweetid);
            var next = first.Next;
            if(next!=null)
            {
                sortedSet.Add(next);
            }
        }
        return res;
        
    }
