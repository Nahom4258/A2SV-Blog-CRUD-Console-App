using A2SV___Blog_CRUD;
using A2SV___Blog_CRUD.Models;

namespace A2SV___Blog_Console_App
{
    public class Program
    {
        public static void Main()
        {
            using (var db = new A2svBackendLearningContext())
            {
                PostManager postManager = new PostManager(db);
                CommentManager commentManager = new CommentManager(db);

                int choice = 1;
                while (choice != 0)
                {
                    System.Console.WriteLine("-----------------");
                    System.Console.WriteLine("My Blog App");
                    System.Console.WriteLine("-----------------");
                    System.Console.WriteLine();
                    System.Console.WriteLine("1. Add Post");
                    System.Console.WriteLine("2. Update Post");
                    System.Console.WriteLine("3. View Posts");
                    System.Console.WriteLine("4. View a single Post");
                    System.Console.WriteLine("5. Delete Post");
                    System.Console.WriteLine("6. Add Comment to Post");
                    System.Console.WriteLine("7. Update Comment on Post");
                    System.Console.WriteLine("8. Delete Comment from Post");
                    System.Console.WriteLine("0. Exit");
                    System.Console.WriteLine();

                    choice = UserInputHandler.ReadInt("Enter your choice: ");
                    if (choice == 0)
                        break;

                    else if (choice == 1)
                    {
                        // Add Post
                        postManager.CreatePost(
                            UserInputHandler.ReadString("Enter title: "),
                            UserInputHandler.ReadString("Enter content: ")
                        );
                    }
                    else if (choice == 2)
                    {
                        // Update Post
                        postManager.UpdatePost(
                            UserInputHandler.ReadInt("Enter post id: "),
                            UserInputHandler.ReadString("Enter title: "),
                            UserInputHandler.ReadString("Enter content: ")
                        );
                    }
                    else if (choice == 3)
                    {
                        // View Posts
                        postManager.ReadAllPosts();
                    }
                    else if (choice == 4)
                    {
                        // View a single Post
                        postManager.ReadPost(
                            UserInputHandler.ReadInt("Enter post id: ")
                        );
                    }
                    else if (choice == 5)
                    {
                        // Delete Post
                        postManager.DeletePost(
                            UserInputHandler.ReadInt("Enter post id: ")
                        );
                    }
                    else if (choice == 6)
                    {
                        postManager.ReadAllPosts();
                        // Add Comment to Post
                        commentManager.AddCommentToPost(
                            UserInputHandler.ReadInt("Enter post id: "),
                            UserInputHandler.ReadString("Enter comment: ")
                        );
                    }
                    else if (choice == 7)
                    {
                        postManager.ReadAllPosts();
                        // Update Comment on Post
                        commentManager.UpdateCommentOnPost(
                            UserInputHandler.ReadInt("Enter post id: "),
                            UserInputHandler.ReadInt("Enter comment id: "),
                            UserInputHandler.ReadString("Enter comment: ")
                        );
                    }
                    else if (choice == 8)
                    {
                        postManager.ReadAllPosts();
                        // Delete Comment from Post
                        commentManager.DeleteCommentFromPost(
                            UserInputHandler.ReadInt("Enter post id: "),
                            UserInputHandler.ReadInt("Enter comment id: ")
                        );
                    }
                    else
                    {
                        System.Console.WriteLine("Incorrect choice!!");
                    }
                }
            }
        }
    }
}