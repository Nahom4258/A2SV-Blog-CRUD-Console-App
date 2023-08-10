using A2SV___Blog_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace A2SV___Blog_CRUD
{
    public class PostManager
    {
        private readonly A2svBackendLearningContext DbContext;

        public PostManager(A2svBackendLearningContext dbContext)
        {
            DbContext = dbContext;
        }

        public bool CreatePost(string title, string content)
        {
            var newPost = new Post
            {
                Title = title,
                Content = content,
                CreatedAt = DateTime.Now
            };

            DbContext.Posts.Add(newPost);
            DbContext.SaveChanges();

            return true;
        }

        public List<Post> ReadAllPosts()
        {
            var posts = DbContext.Posts.Include(p => p.Comments).ToList();

            System.Console.WriteLine();
            System.Console.WriteLine("==================");
            System.Console.WriteLine("\tPosts");
            System.Console.WriteLine("==================");
            foreach (var post in posts)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                System.Console.WriteLine($"ID: {post.Id}");
                System.Console.WriteLine($"Title: {post.Title}");
                System.Console.WriteLine($"Body: {post.Content}");
                System.Console.WriteLine($"Posted At: {post.CreatedAt}");

                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("\t*************************");
                System.Console.WriteLine("\t\tCOMMENTS");
                System.Console.WriteLine("\t*************************");

                var comments = post.Comments.ToList();
                foreach (var comment in comments)
                {
                    System.Console.WriteLine($"\tPost ID: {comment.Id}");
                    System.Console.WriteLine($"\tComment: {comment.Text}");
                    System.Console.WriteLine($"\tCommented At: {comment.CreatedAt}");
                    System.Console.WriteLine("\t$\t$\t$\t$\t$");
                }

                Console.ForegroundColor = ConsoleColor.White;
            }

            return posts;
        }

        public void ReadPost(int postId)
        {
            var post = DbContext.Posts.Include(p => p.Comments).FirstOrDefault(p => p.Id == postId);
            if (post != null)
            {
                System.Console.WriteLine($"ID: {post.Id}");
                System.Console.WriteLine($"Title: {post.Title}");
                System.Console.WriteLine($"Body: {post.Content}");
                System.Console.WriteLine($"Posted At: {post.CreatedAt}");

                System.Console.WriteLine("\t*************************");
                System.Console.WriteLine("\t\tCOMMENTS");
                System.Console.WriteLine("\t*************************");

                var comments = post.Comments.ToList();
                foreach (var comment in comments)
                {
                    System.Console.WriteLine($"\tPost ID: {comment.Id}");
                    System.Console.WriteLine($"\tComment: {comment.Text}");
                    System.Console.WriteLine($"\tCommented At: {comment.CreatedAt}");
                    System.Console.WriteLine("\t$\t$\t$\t$\t$");
                }

            }
        }

        public void UpdatePost(int postId, string newTitle, string newContent)
        {
            var postToUpdate = DbContext.Posts.Find(postId);
            if (postToUpdate != null)
            {
                postToUpdate.Title = newTitle;
                postToUpdate.Content = newContent;
                DbContext.SaveChanges();
            }
        }

        public void DeletePost(int postId)
        {
            var postToDelete = DbContext.Posts.Find(postId);
            if (postToDelete != null)
            {
                DbContext.Posts.Remove(postToDelete);
                DbContext.SaveChanges();
            }
        }
    }
}
