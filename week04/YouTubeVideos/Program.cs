using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Cooking food #1", "food cooker", 3763);
        video1.AddComment(new Comment("Nice food!", "foodlover314"));
        video1.AddComment(new Comment("good food", "foodenjoyer415"));
        video1.AddComment(new Comment("make a sandwich next.", "sandwichcrafter53"));
        videos.Add(video1);

        
        Video video2 = new Video("Running around outside", "runningman43", 2351);
        video2.AddComment(new Comment("i used to do that... when i was yougner", "aolderman"));
        video2.AddComment(new Comment("stop running!", "angryperson32"));
        video2.AddComment(new Comment("make a sandwich next.", "sandwichcrafter53"));
        videos.Add(video2);

        
        Video video3 = new Video("going for a walk", "markjohnson", 620);
        video3.AddComment(new Comment("where is that stop light at?", "leakyground934"));
        video3.AddComment(new Comment("that didn't look very fun", "pilloweater34"));
        video3.AddComment(new Comment("make a sandwich next.", "sandwichcrafter53"));
        videos.Add(video3);

        
        Video video4 = new Video("my travel to work", "food cooker", 1463);
        video4.AddComment(new Comment("that's a very long commute!", "treehugger23"));
        video4.AddComment(new Comment("actually that's not very long of a commute I commute to work 13 hours a day", "workcommuter12"));
        video4.AddComment(new Comment("make a sandwich next.", "sandwichcrafter53"));
        videos.Add(video4);


        foreach (Video video in videos) 
        {
            Console.WriteLine($"\nTitle: {video.Title}\nAuthor: {video.Author}\nLength: {video.LengthInSeconds}\nFormatted time: {video.GetFormattedTime()}\nComment Count: {video.GetCommentCount()}\nComments:\n\n");
            foreach(Comment comment in video.GetComments()) 
            {
                Console.WriteLine($"{comment.CommenterName}:\n{comment.Text}\n");
            }

        }
    }
}


